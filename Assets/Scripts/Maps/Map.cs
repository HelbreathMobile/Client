using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Map
{
    public FloorTile[] floorTiles;
    public ObjectTile[] objectTiles;
    public int x;
    public int y;

    public void generate(string mapName, string tileType)
    {
        string tileCsv = "/" + mapName + "/" + tileType + ".csv";
        string[][] tiles2DArray = ReadCsv(tileCsv);
        int arrayCounter = 0;
        if (tileType.Equals("objects"))
        {
            objectTiles = new ObjectTile[tiles2DArray.Length];
            for (int i = 0; i < tiles2DArray.Length; i++) // rows of the csv
            {


                objectTiles[arrayCounter] = new ObjectTile(
                int.Parse((string)tiles2DArray[i][0]),
                int.Parse((string)tiles2DArray[i][1]),
                "Maps/tiles/" + (string)tiles2DArray[i][2].Replace(".png", "")
            );
                arrayCounter++;
            }
        }
        else
        {
            floorTiles = new FloorTile[tiles2DArray.Length];
            for (int i = 0; i < tiles2DArray.Length; i++) // rows of the csv
            {
                floorTiles[arrayCounter] = new FloorTile(
                    int.Parse((string)tiles2DArray[i][0]),
                    int.Parse((string)tiles2DArray[i][1]),
                    "Maps/tiles/" + (string)tiles2DArray[i][2].Replace(".png",""),
                    (tiles2DArray[i][3].Equals("true")),
                    (tiles2DArray[i][4].Equals("true"))
                );
                arrayCounter++;
            }
        }
    }

    string[][] ReadCsv(string filename)
    {
        string filePath = Application.streamingAssetsPath + filename;
        string csvString;

        if (Application.platform == RuntimePlatform.Android) //Need to extract file from apk first
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }

            csvString = reader.text;
        }
        else
        {
            csvString = File.ReadAllText(filePath);
        }

        var tiles = new List<string[]>();
        string[] tilesStrings = csvString.Split("\n".ToCharArray());
        for (int i = 0; i < tilesStrings.Length; i++)
        {
            string[] tile = tilesStrings[i].Split(',');
            if(tile.Length > 0 && !tile[0].Equals(""))
            {
                tiles.Add(tile);
            }
        }

        return tiles.ToArray();
    }
}

public class DefaultMap : Map
{
    public DefaultMap()
    {
        this.x = 169;
        this.y = 169;
        generate("default", "objects");
        generate("default", "floor");
    }

}