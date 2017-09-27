using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {
    GameObject parent;
    Sprite tileSp;
    SpriteRenderer sr;
    GameObject test;
    private int maxX, maxY;
    private Tile[][] world;
    //List<GameObject> gameObjectList;
    // Use this for initialization
    void Start () {
       
        tileSp = Sprite.Create(Texture2D.whiteTexture, new Rect(0f, 0f, 2f, 2f), new Vector2(0.5f, 0.5f), 100f);
        createWorld(20, 20);
        //sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        //sr.color = new Color(.9f, .9f, .9f, 1f);



        //test = new GameObject("testobject");
        //sr.sprite = tileSp;
        //sr.transform.position = new Vector3(2, 1, 0);
        //sr.transform.localScale = new Vector3(50, 50, 0);
        //Debug.Log(sr.transform);

        //gameObjectList = new List<GameObject>();

        //SpriteRenderer sr2 = test.AddComponent<SpriteRenderer>() as SpriteRenderer;
        //sr2.sprite = tileSp;
        //sr2.transform.position = new Vector3(1, 1, 0);
        //sr2.transform.localScale = new Vector3(50, 50, 0);

    }

	
    public void createWorld(int width, int height)
    {
        world = new Tile[width][];
        maxX = width - 1;
        maxY = height - 1;
        for(int i = 0; i < width; i++)
        {
            world[i] = new Tile[height];
            for(int j = 0; j < height; j++)
            {
                GameObject go = new GameObject("Tile" + i + "x" + j + "y");
                Tile tile = go.AddComponent<Tile>() as Tile;

                //bc2D.size = new Vector2(.2f, .2f);

                tile.setX(i);
                tile.setY(j);

                SpriteRenderer sr2 = go.AddComponent<SpriteRenderer>() as SpriteRenderer;
                sr2.sprite = tileSp;

                tile.transform.position = new Vector3(i, j, 0);
                tile.transform.localScale = new Vector3(50, 50, 0);

                BoxCollider2D bc2D = go.AddComponent<BoxCollider2D>() as BoxCollider2D;
                
                world[i][j] = tile;
            }
        }
        MovementController.setWorld(world);
        //TODO: TEMPCODE:
        createSymetricCities(0, 1, false);
        createSymetricCities(1, 0, false);
        createSymetricCities(2, 3);
        createSymetricCities(4, 7);
        createSymetricCities(1, 8);
        createSymetricCities(0, 4);
        createSymetricCities(17, 1);
        createSymetricCities(12, 3);
        createSymetricCities(14, 7);
        createSymetricCities(11, 8);
        createSymetricCities(10, 4);
        createSymetricCities(2, 13);
        createSymetricCities(4, 17);
        createSymetricCities(1, 18);
        createSymetricCities(0, 14);
        createSymetricCities(7, 11);

        createSymetricFactorys(3, 3, false);
        createSymetricFactorys(9, 4);
        createSymetricFactorys(13, 1);
        createSymetricFactorys(12, 16);

        TurnManager.player1.tile = world[(int)TurnManager.player1.startX][(int)TurnManager.player1.startY];
        TurnManager.player2.tile = world[(int)TurnManager.player2.startX][(int)TurnManager.player2.startY];
    }
    private void createSymetricCities(int x, int y, bool neutral = true)
    {
        int x2, y2;
        x2 = maxX - x;
        y2 = maxY - y;
        City city1 = City.Create(x, y, world);
        City city2 = City.Create(x2, y2, world);
        if (!neutral)
        {
            city1.assignToPlayer(TurnManager.player1);
            city2.assignToPlayer(TurnManager.player2);
        }
    }

    private void createSymetricFactorys(int x, int y, bool neutral = true)
    {
        int x2, y2;
        x2 = maxX - x;
        y2 = maxY - y;
        Factory factory1 = Factory.Create(x, y, world);
        Factory factory2 = Factory.Create(x2, y2, world);
        if (!neutral)
        {
            factory1.assignToPlayer(TurnManager.player1);
            factory2.assignToPlayer(TurnManager.player2);
        }
    }
    public int getMaxX()
    {
        return maxX;
    }
    public int getMaxY()
    {
        return maxY;
    }
    // Update is called once per frame
    void Update () {
        
		
	}
}
