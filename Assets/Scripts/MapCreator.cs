using UnityEngine;
using UnityEngine.Tilemaps;

public class MapCreator : MonoBehaviour
{
    public Vector2 StartPoint;
    public Tilemap map;

    private void Start()
    {
        StartPoint = new Vector2(1, 1);
        PopulateTileMap(new DefaultMap());
    }

    public void PopulateTileMap(Map mapConfig){

        //for (int i = 0; i < map.floorTiles.Length; i++)
        //{
        //    GameObject tile = Instantiate(map.floorTiles[i].prefab, Vector3.zero, Quaternion.identity) as GameObject;
        //    tile.transform.position = new Vector3((TileSize * map.floorTiles[i].x) + (TileSize / 2), (TileSize * map.floorTiles[i].x) + (TileSize / 2), 0);
        //}
        Vector3Int[] positions = new Vector3Int[mapConfig.floorTiles.Length];
        TileBase[] tileArray = new TileBase[mapConfig.floorTiles.Length];
        for (int i = 0; i < mapConfig.floorTiles.Length; i++)
        {
            positions[i] = new Vector3Int(mapConfig.floorTiles[i].x, mapConfig.y - mapConfig.floorTiles[i].y, 3);
            tileArray[i] = mapConfig.floorTiles[i].tile;
        }
        map.SetTiles(positions, tileArray);
    }
}

