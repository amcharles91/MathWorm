using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class DataBase{

    private IDbConnection dbconn;
    private IDbCommand dbcmd;
    private string dataPath;


    public DataBase(String path)
    {
        this.dataPath = path;
        dbconn = (IDbConnection)new SqliteConnection(path);
    }

    public void insertUser(String user, int score)
    {
        Debug.Log("Did it make it here?");
        using (dbconn = new SqliteConnection(dataPath))
        {
            dbconn.Open();

            using(dbcmd = dbconn.CreateCommand())
            {
                String query = String.Format("INSERT INTO Scores(Player, Score) VALUES(\"{0}\",\"{1}\")", user, score); //VALUES('" + user + "', " + score + ")"

                dbcmd.CommandText = query;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }
    }


    public void insertQuestion(String Question, String A, String B, String C)
    {
        using (dbconn = new SqliteConnection(dataPath))
        {
            dbconn.Open();

            using (dbcmd = dbconn.CreateCommand())
            {
                String query = String.Format("INSERT INTO Questions(Question, AnswerA, AnswerB, AnswerC) " +
                    "VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", Question, A,B,C);

                dbcmd.CommandText = query;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }
    }


    public void deleteUser(String user)
    {
        dbconn.Open(); //Open connection to the database.
        dbcmd = dbconn.CreateCommand();

        String query = "DELETE FROM Scores WHERE player = '" + user +"'";
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();
    }

    public void updateRecord(String user, int score)
    {
        dbconn.Open(); //Open connection to the database.
        dbcmd = dbconn.CreateCommand();

        String query = " UPDATE Scores SET Score = "+ score + " WHERE Player = '" + user + "'";
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();
    }

    public List<String> readAll()
    {
        dbconn.Open(); //Open connection to the database.
        dbcmd = dbconn.CreateCommand();
        List<String> p = new List<String>();
        string sqlQuery = "SELECT ID,Player,Score " + "FROM Scores";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int ID = reader.GetInt32(0);
            string name = reader.GetString(1);
            int score = reader.GetInt32(2);

            p.Add(name);
            Debug.Log("ID= " + ID + "  name =" + name + "  score =" + score);
        }
        dbconn.Close();
        reader.Close();
        return p;
    }

    public List<Questions> readAllQuestion()
    {
        List<Questions> temp = new List<Questions>();
        using (dbconn = new SqliteConnection(dataPath))
        {
            dbconn.Open();

            using (dbcmd = dbconn.CreateCommand())
            {
                String query = "Select * from Questions";

                dbcmd.CommandText = query;
                using(IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                                                                 //GetString(0) is id
                        string Question = reader.GetString(1);  //Question
                        string answA = reader.GetString(2);     //Answer A
                        string answB = reader.GetString(3);     //Answer B
                        string answC = reader.GetString(4);     //Answer C

                        Debug.Log(Question + " " + answA + " " +answB+ " " +answC + " ");
                        temp.Add(new Questions(Question, answA, answB, answC));
                    }
                    
                }
                dbconn.Close();
            }
        }

        return temp;
    }

    public int readCurrentUser(String user)
    {
        dbconn.Open(); //Open connection to the database.
        dbcmd = dbconn.CreateCommand();
        
        String query = "SELECT ID,Player, Score FROM Scores where Player = '"+user + "'";
        
        dbcmd.CommandText = query;
        IDataReader reader = dbcmd.ExecuteReader();
        int score =0;
        while (reader.Read())
        {
            score = reader.GetInt32(2);
        }

        dbcmd.Dispose();
        dbcmd = null;
        //dbconn.Close();
        //dbconn = null;

        return score;

    }

    public void close()
    {
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

}
