using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; protected set; }

    Dictionary<Tile, GameObject> tileGameObjectMap;

    //The raw map created for the game represented in intigers
    public Map map;

    //The object to store the tiles for the map int
    //GameObject mapTiles;

    //The width and height of the map capped to ranges
    [Range(50, 350)]
    public int width;
    [Range(50, 350)]
    public int height;

    //Just a temporary sprite for the floor
    public Sprite[] floorSprites;
    public Sprite[] groundSprites;
    public Sprite[] rockSprites;
    //public Sprite[] mineralSprites;

    //Room sprites
    //public Sprite[] treasureRoomSprites;
    //public Sprite[] bedRoomSprites;
    //public Sprite[] farmRoomSprites;
    //public Sprite[] trainingRoomSprites;
    //public Sprite[] libraryRoomSprites;

    //The range for the filling of the map
    [Range(0, 100)]
    public int fillMap;

    //The range for the smoothing passes to be done
    [Range(0, 10)]
    public int smoothAmount;

    //If the map should use a random seed
    public bool useRandomSeed;

    //The random seed to use if the userandomseed is false
    public int seed;

    // Use this for initialization
    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("There should never be more than one world controller at one point in time ");
        }
        Instance = this;

        map = new Map(width, height);

        //Instantiate our dictionary that track the link between the tile an=d it's game object
        tileGameObjectMap = new Dictionary<Tile, GameObject>();

        //Create a game object for each of our tile so they can show visualy.
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile tile_data = map.GetTileAt(x, y);

                //Create a tile object
                GameObject tile_go = new GameObject();

                // Add the tile and connected game object pair to the dictionary
                tileGameObjectMap.Add(tile_data, tile_go);

                //Give the tile object a name
                tile_go.name = "Tile(" + x + ", " + y + ") " + tile_data.Type;
                //Set the position of the game object of the tile to the tiles actual position
                tile_go.transform.position = new Vector3(tile_data.X, tile_data.Y, 0);

                //Make MapManager the parrent of the tile to save space in inspector 
                tile_go.transform.SetParent(this.transform, true);

                SpriteRenderer tile_sr = tile_go.AddComponent<SpriteRenderer>();
                //Set the sorting layer on the tiles to ground so that they are always under the player and gfx
                tile_sr.sortingLayerName = "Ground";
                //NOTE: RE ENABLE THIS FOR FOW
                //TODO: Make it so that fog of war can be toggled from the inspector
                //tile_sr.color = new Color(0f, 0f, 0f);

                BoxCollider2D tile_Boxcol = tile_go.AddComponent<BoxCollider2D>();
                tile_Boxcol.size = Vector2.one;
                //Set the tile leayer to the obstacle layer to work with the FOW
                tile_go.layer = 8;

                //tile_go.AddComponent<EventCbSystem.TileLogic>();

                tile_data.RegisterTileTypeChangedCallback(OnTileTypeChanged);
            }

        }
        //Generate a map
        map.GenerateMap(fillMap, useRandomSeed, seed, smoothAmount);
    }

    void OnTileTypeChanged(Tile tile_data)
    {
        if (tileGameObjectMap.ContainsKey(tile_data) == false)
        {
            Debug.LogError("tileGameObjectMap does not contain the tile_data or callback is not regestired");
            return;
        }

        //Grab the game object connected to the tile_data key to modify the tile game object
        GameObject tile_go = tileGameObjectMap[tile_data];

        if (tile_go == null)
        {
            Debug.LogError("tileGameObjectMap returned GameObject is null");
            return;
        }

        if (tile_data.Type == TileType.Floor)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = floorSprites[UnityEngine.Random.Range(0, floorSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = true;
            tile_go.layer = 13;

        }
        else if (tile_data.Type == TileType.Ground)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = groundSprites[UnityEngine.Random.Range(0, groundSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = false;
            tile_go.layer = 8;
        }
       
        else if (tile_data.Type == TileType.Rock)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = rockSprites[UnityEngine.Random.Range(0, rockSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = false;
            tile_go.layer = 8;
        }
        /*else if (tile_data.Type == TileType.MiniralGround)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = mineralSprites[UnityEngine.Random.Range(0, mineralSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = false;
            tile_go.layer = 8;
        }
        else if (tile_data.Type == TileType.Room || tile_data.Room == RoomType.Tresuary)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = treasureRoomSprites[UnityEngine.Random.Range(0, treasureRoomSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = true;
            tile_go.layer = 13;
        }
        else if (tile_data.Type == TileType.Room || tile_data.Room == RoomType.BedRoom)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = bedRoomSprites[UnityEngine.Random.Range(0, bedRoomSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = true;
            tile_go.layer = 13;
        }
        else if (tile_data.Type == TileType.Room || tile_data.Room == RoomType.Farm)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = farmRoomSprites[UnityEngine.Random.Range(0, farmRoomSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = true;
            tile_go.layer = 13;
        }
        else if (tile_data.Type == TileType.Room || tile_data.Room == RoomType.Training)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = trainingRoomSprites[UnityEngine.Random.Range(0, trainingRoomSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = true;
            tile_go.layer = 13;
        }
        else if (tile_data.Type == TileType.Room || tile_data.Room == RoomType.Library)
        {
            tile_go.GetComponent<SpriteRenderer>().sprite = libraryRoomSprites[UnityEngine.Random.Range(0, libraryRoomSprites.Length)];
            tile_go.GetComponent<BoxCollider2D>().isTrigger = true;
            tile_go.layer = 13;
        }*/
        else
        {

            Debug.LogError("OnTileTypeChanged - Unrecognized tile type");
        }
    }

    public Tile GetTileAtWorldCoord(Vector3 coord)
    {
        int x = Mathf.FloorToInt(coord.x);
        int y = Mathf.FloorToInt(coord.y);
        return map.GetTileAt(x, y);
    }
}
