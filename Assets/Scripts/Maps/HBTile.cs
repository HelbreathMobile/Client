using UnityEngine;
using UnityEngine.Tilemaps;

public class HBTile
{
    public int x;
    public int y;
    public Tile tile;

    public HBTile(int x, int y, string resource)
    {
        Sprite sprite = Resources.Load <Sprite> (resource);
        this.tile = ScriptableObject.CreateInstance<Tile>();
        this.tile.sprite = sprite;
        this.x = x;
        this.y = y;
    }

}