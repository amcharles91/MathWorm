using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class FirstEditModeTest{

    private DataBase db;
    private string conn = "URI=file:" + Application.dataPath + "/HighScores.db"; //Path to database.;

    [Test]
    public void dataBaseInsert()
    {

        db = new DataBase(conn);
        db.deleteUser("bob");
        db.insertUser("bob", 70);

        if (db.readCurrentUser("bob") != 0)
        {
            // db.close();
            Assert.Pass();
        }
        else
        {
            //db.close();
            Assert.Fail();
        }
    }

    //[Test]
    //public void databaseUpdate()
    //{
    //    db = new DataBase(conn);
    //    int currentValue = db.readCurrentUser("Nancy");

    //    db.updateRecord("Nancy", UnityEngine.Random.Range(0, 50));

    //    int newValue = db.readCurrentUser("Nancy");
    //   // db.close();

    //    Assert.AreNotEqual(currentValue, newValue);
    //}

    [Test]
    public void readCurrentUSer()
    {
       db = new DataBase(conn);
        int value = db.readCurrentUser("Druaga");
        //db.close();

        Assert.AreEqual(30, value);
    }

    [Test]
    public void readAllQuestions()
    {
        db = new DataBase(conn);
        int value = db.readCurrentUser("Druaga");
        //db.close();

        Assert.AreEqual(30, value);
    }

    [Test]
    public void dataBaseReadAll()
    {
        
        db = new DataBase(conn);
        List<string> r = db.readAll();
        //db.close();
        List<string> shouldBe = new List<string>();
        shouldBe.Add("Nancy");
        shouldBe.Add("Druaga");
        shouldBe.Add("Bill");
        shouldBe.Add("bain");
        foreach (string p in r)
        {
            Debug.Log(p);
        }
        CollectionAssert.AreEqual(shouldBe, r);

    }



}
