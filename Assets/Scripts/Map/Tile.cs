using System;
using System.Collections;
using System.Collections.Generic;


public enum TileType
{
    None = 1,
    Floor,
    Ground,
    Rock,
    MiniralGround,
    Room
};

public enum RoomType
{
    None,
    BedRoom,
    Farm,
    Tresuary,
    Training,
    Library

};

public class Tile
{

    //The type of the tile
    TileType type = TileType.Floor;

    //The type of room the tile is part of
    RoomType room = RoomType.None;

    //The health of the tile
    private int health;

    //External funtion to be called when the tile type is changed
    Action<Tile> cbTileTypeChanged;

    //External function to be called when the visibility of the tile is changed, used for the FOW effect
    Action<Tile> cbTileVisibilityChanged;

    public TileType Type
    {
        get { return type; }

        set
        {
            //Set the old type to the current type to check for change in the tile
            TileType oldType = type;
            //Set the type to the new type
            type = value;

            //Set the health of the tile acording the position in the type list
            health = (int)type;

            //Using action deligate
            if (cbTileTypeChanged != null && oldType != type)
            {
                cbTileTypeChanged(this);

            }
        }
    }

    public RoomType Room
    {
        get { return room; }

        set { room = value; }
    }

    public int X { get; protected set; }

    public int Y { get; protected set; }

    public Tile(int _x, int _y)
    {
        //The tiles co oordinates
        X = _x;
        Y = _y;
    }

    public void RegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged += callback;
    }
    public void UnregisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged -= callback;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Type = TileType.Floor;
        }
    }
}

