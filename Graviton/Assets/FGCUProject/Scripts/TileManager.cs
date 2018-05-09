using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public AppleUpdate appleUpdate;
    private bool word;

    //Tiles you can use
    public List<GameObject> tiles;
    public List<GameObject> terrains;

    public GameObject score;

    //Safe Zone for deleting tiles
    public float safeZone;
    public float terrainSafe;

    //Amount of tiles on screen
    public int tilesOnScreen;
    public int terrainOnScreen;

    //Lnegth of tiles
    public float tileLength;
    public float terrainLength;

    //List of Game Objects
    private List<GameObject> activeTiles;
    private List<GameObject> activeTerrains;

    //player transform
    private Transform playerTrans;

    //location on z where to spawn tile
    private float Zspawn = 0.0f;
    private float tzspawn = 0.0f;

    //incremented index
    private int lastIndex =0;
    private int lastTdex = 0;

    private int addTilecounter = 0;
    private int maxTileAdd;

  
	// Use this for initialization
	void Start () {
        word = appleUpdate.wordProblem;
        activeTiles = new List<GameObject>();//instantiates list
        activeTerrains = new List<GameObject>();

        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;//find the player object
        //spawns tile at start for the amount of tiles
        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 2)
            {
                //Spawns the tiles at index 0
                SpawnTile(0);
            }
            else
            {
                //Spawns a random tile
                SpawnTile();
               
            }
           
        }

        for (int i = 0; i < terrainOnScreen; i++)
        {
            //spawns the first tile of the barn as well as a straight path after
            if(i == 0)
            {
                SpawnTerrain(0);
            }
            else
            {
                SpawnTerrain();
            }
            
        }
    }
	
	// Update is called once per frame
	 void Update () {
        //Used to spawn tiles and delete tiles as player moves a certain distance
		if(playerTrans.position.z - safeZone > (Zspawn - tilesOnScreen * tileLength))
        {
            SpawnTile();
            delTile();
        }

        if (playerTrans.position.z - terrainSafe > (tzspawn - terrainOnScreen * terrainLength))
        {
            SpawnTerrain();
            delTerrain();
        }

        addExtraTile();

	}

    private void addExtraTile()
    {
        if (!word)
        {
            if (score.GetComponent<ManageScore>().score >= 100)
            {

                if (addTilecounter == 0)
                {

                    tiles.Add(Resources.Load("AppleSet4", typeof(GameObject)) as GameObject);
                    tiles.Add(Resources.Load("AppleSet5", typeof(GameObject)) as GameObject);

                    addTilecounter++;


                }


            }
        }

    }

    //Method to spawn tiles
    private void SpawnTerrain(int prefabIndex = -1)
    {
        
        GameObject go;//creates gameobject
        if (prefabIndex == -1)
        {
            go = Instantiate(terrains[1]) as GameObject;//creates the 2nd element tile
        }
        else
        {
            go = Instantiate(terrains[0]) as GameObject;//creates the first tile
        }

        go.transform.SetParent(transform);//sets the parent
        go.transform.position = Vector3.forward * tzspawn;//location of where to spawn
        tzspawn += terrainLength;//adds the coordinates for next location to spawn tile
        activeTerrains.Add(go);//add's to list of tiles
    }

    private void delTerrain()
    {
        Destroy(activeTerrains[0]);//deletes the last tile from screen
        activeTerrains.RemoveAt(0);//removes the tile from list
    }


    //Method to spawn tiles
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;//creates gameobject
        if (prefabIndex == -1)
        {
            go = Instantiate(tiles[RandomFab()]) as GameObject;//creates on screen
        }
        else
        {
            go = Instantiate(tiles[prefabIndex]) as GameObject;//creates a random tile
        }
        
        go.transform.SetParent(transform);//sets the parent
        go.transform.position = Vector3.forward * Zspawn;//location of where to spawn
        Zspawn += tileLength;//adds the coordinates for next location to spawn tile
        activeTiles.Add(go);//add's to list of tiles
    }

    private void delTile()
    {
        Destroy(activeTiles[0]);//deletes the last tile from screen
        activeTiles.RemoveAt(0);//removes the tile from list
    }

    private int RandomFab()
    {
        if(tiles.Count <= 1)
        {
            return 0;
        }

        int randomNum = lastIndex;
        while(randomNum == lastIndex)
        {
            randomNum = UnityEngine.Random.Range(0, tiles.Count);
        }
        lastIndex = randomNum;
        return randomNum;
    }
}
