using System.Collections.Generic;
using UnityEngine;

public class Map
{
    //The width of the map
    //public int Width { get; private set; }
    int width;
    //The height of the map
    //public int Height { get; private set; }
    int height;
    //The random string used as a cration seed for the map
    string seed;

    //The tile map of the raw int map
    Tile[,] tileMap;

    //Instantiate the regeonControler for the map
    RegionManager regions = new RegionManager();

    //General random number 
    System.Random universalRandom = new System.Random();

    public Map(int width, int height)
    {
        this.width = width;
        this.height = height;

        tileMap = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tileMap[x, y] = new Tile(x, y);
                tileMap[x, y].Type = TileType.None;
            }
        }
    }

    public void GenerateMap(int fillPercent, bool useRandomSeed, int randomSeed, int smoothAmount)
    {
        RandomFillMap(fillPercent, useRandomSeed, randomSeed);

        for (int i = 0; i < smoothAmount; i++)
        {
            SmoothMap();
        }

        CreateMapBorder();

        CreateMinirals();

        //CreateItems();

        SetUpRooms();
    }

    void RandomFillMap(int fillPercent, bool useRandomSeed, int RandomSeed)
    {
        if (useRandomSeed)
        {
            seed = System.DateTime.Now.Millisecond.ToString();
        }
        else
        {
            seed = RandomSeed.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (pseudoRandom.Next(0, 100) < fillPercent)
                {
                    tileMap[x, y].Type = TileType.Ground;
                }
                else
                {
                    tileMap[x, y].Type = TileType.Floor;
                }
            }
        }
    }

    void SmoothMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourWallTiles = GetSurroundingTileCount(x, y);

                if (neighbourWallTiles > 4)
                    tileMap[x, y].Type = TileType.Floor;
                else if (neighbourWallTiles < 4)
                    tileMap[x, y].Type = TileType.Ground;

            }
        }
    }

    void CreateMapBorder()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    tileMap[x, y].Type = TileType.Rock;
                }
            }
        }
    }

    void CreateMinirals()
    {
        //Here we get the list of cordinate lists for the regions that are ground
        List<List<Vector2Int>> chunksSizes = regions.GetRegions(tileMap, width, height, TileType.Ground);

        int mineralAmount = 0;

        //Loop throught the tile lists and check for size and then start populating the tile map with the miniral
        foreach (List<Vector2Int> chunkList in chunksSizes)
        {
            //Check if the ground chunk is greater than 30 tiles we split up the miniral vines by deviding the amount of tiles by 30
            if (chunkList.Count > 30)
            {
                //The amount of minirals will be 30% of the total size of the ground chunk
                mineralAmount = (chunkList.Count * 30) / 100;

                //Start the loop for the amount of minirals to be created
                for (int i = 0; i < mineralAmount; i++)
                {
                    //Where the mineral should start
                    int randomPoint = universalRandom.Next(0, chunkList.Count);

                    //Randoms the size of the mineral deposite
                    int mineralDepositeSize = universalRandom.Next(0, 6);

                    int mineralSizeIncrease = 1;

                    ///Blocks mineral deposites
                    //for (int x = chunkList[randomPoint].tileX - mineralDepositeSize; x < chunkList[randomPoint].tileX + mineralDepositeSize; x++)
                    //{
                    //    for (int y = chunkList[randomPoint].tileY - mineralDepositeSize; y < chunkList[randomPoint].tileY + mineralDepositeSize; y++)
                    //    {
                    //        if (IsInMapRange(x, y))
                    //        {
                    //            if (tileMap[x, y].Type == TileType.Ground)
                    //            {
                    //                tileMap[x, y].Type = TileType.MiniralGround;
                    //                //Add the total minerals created to the incrimetation so as not to create to more minerals than the mineralAmount
                    //                i += 1;

                    //                mineralSizeIncrease++;
                    //            }
                    //        }
                    //    }
                    //}

                    ///Line mineral deposites
                    for (int x = chunkList[randomPoint].x - (mineralDepositeSize - mineralDepositeSize + mineralSizeIncrease); x < chunkList[randomPoint].x + (mineralDepositeSize - mineralDepositeSize + mineralSizeIncrease); x++)
                    {
                        for (int y = chunkList[randomPoint].y - (mineralDepositeSize - mineralDepositeSize + mineralSizeIncrease); y < chunkList[randomPoint].y + (mineralDepositeSize - mineralDepositeSize + mineralSizeIncrease); y++)
                        {
                            if (IsInMapRange(x, y))
                            {
                                if (tileMap[x, y].Type == TileType.Ground)
                                {
                                    tileMap[x, y].Type = TileType.MiniralGround;
                                    //Add the total minerals created to the incrimetation so as not to create to more minerals than the mineralAmount
                                    i += 1;

                                    mineralSizeIncrease++;
                                    if (mineralSizeIncrease > mineralDepositeSize)
                                    {
                                        mineralSizeIncrease = 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void CreateItems()
    {
        //Note to impliment!!!!!!!!!
    }

    void SetUpRooms()
    {
        //Here we get the list of cordinate lists for the regions that are ground
        List<List<Vector2Int>> chunksSizes = regions.GetRegions(tileMap, width, height, TileType.Floor);

        //Loop throught the tile lists and check for size and then start populating the tile map with the miniral
        foreach (List<Vector2Int> chunkList in chunksSizes)
        {
            //Check if the ground chunk is greater than 30 tiles we split up the miniral vines by deviding the amount of tiles by 30
            if (chunkList.Count < 40 && chunkList.Count > 10)
            {
                for (int i = 0; i < chunkList.Count; i++)
                {
                    tileMap[chunkList[i].x, chunkList[i].y].Room = RoomType.Tresuary;
                    tileMap[chunkList[i].x, chunkList[i].y].Type = TileType.Room;
                }
            }
        }

        //        int startX = universalRandom.Next(0, width);
        //int startY = universalRandom.Next(0, height);

        //int roomWidth = universalRandom.Next(0, 11);
        //int roomHeight = universalRandom.Next(0, 11);

        //for (int i = 0; i < roomWidth; i++)
        //{
        //    for (int j = 0; j < roomWidth; j++)
        //    {
        //        if (IsInMapRange(i + startX, j + startY))
        //        {
        //            tileMap[i + startX, j + startY].Room = RoomType.Tresuary;
        //            tileMap[i + startX, j + startY].Type = TileType.Room;
        //        }
        //    }
        //}
    }

    //Made this public so that the player can access it to quickly check the surrounding tiles for the fog of war
    public int GetSurroundingTileCount(int gridX, int gridY)
    {
        int tileCount = 0;

        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (IsInMapRange(neighbourX, neighbourY))
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        if (tileMap[neighbourX, neighbourY].Type == TileType.Floor)
                        {
                            tileCount += 1;
                        }
                    }
                }
                else
                {
                    tileCount++;
                }
            }
        }

        return tileCount;
    }

    public Tile GetTileAt(int x, int y)
    {
        if (!IsInMapRange(x, y))
        {
            return null;
        }
        return tileMap[x, y];
    }

    public bool IsInMapRange(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

}