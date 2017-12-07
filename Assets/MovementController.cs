using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementController : MonoBehaviour {

    static Tile currentPos;
    static Tile[] reachableTiles;
    private static Unit selectedUnit;
    private static bool unitSelected;
    private static Tile[][] world;

	// Use this for initialization
	void Start () {
		
	}
	
    public static void deselectUnit()
    {
        colorReachableTiles(Color.white);
        selectedUnit = null;
        unitSelected = false;
    }


    public static void selectUnit(Unit unit)
    {
        if(selectedUnit == unit)
        {
            deselectUnit();
            return;
        }
        if (unitSelected)
        {
            // cleanup the current selection
            colorReachableTiles(new Color(1, 1, 1));
        }
        Debug.Log("unit: " + unit);
        unitSelected = true;
        selectedUnit = unit;
        float unitX = unit.transform.position.x;
        float unitY = unit.transform.position.y;

        currentPos = world[(int)unitX][(int)unitY];
        createReachableTiles();
        colorReachableTiles(new Color(92f/255f, 154f/255f, 164f/255f));

    }

    public static void moveUnit(Tile tile, BuildingInterface building = null)
    {

        
        if (unitSelected) {
            if(selectedUnit.player != TurnManager.currentPlayer)
            {
                deselectUnit();
                return;
            }
            if (reachableTiles.Contains(tile))
            {
                bool actuallymoved = selectedUnit.moveTo(tile);
                bool canCapture = selectedUnit.canCapture;
                deselectUnit();
                if (building != null && actuallymoved && canCapture) building.assignToPlayer(TurnManager.currentPlayer);
            }
        }


    }

    public static void setWorld(Tile[][] world)
    {
        MovementController.world = world;
    }

    private static void createReachableTiles()
    {
        List<Tile> reachTiles = new List<Tile>();
        int move = selectedUnit.moveStat;
        for(int i = 0; i< world.Length; i++)
        {
            for(int j = 0; j < world[i].Length; j++)
            {
                if(world[i][j].getMoveCostToTile(currentPos) <= move)
                {
                    reachTiles.Add(world[i][j]);
                }
            }
        }
        reachableTiles = reachTiles.ToArray();
        /*int move = selectedUnit.moveStat;
        int minx = (currentPos.getX() - move >= 0) ? currentPos.getX() - move : 0;
        int miny = (currentPos.getY() - move >= 0) ? currentPos.getY() - move : 0;

        int maxx = (currentPos.getX() + move <= 4) ? currentPos.getX() + move : 4;
        int maxy = (currentPos.getY() + move <= 4) ? currentPos.getY() + move : 4;

        reachableTiles = new Tile[(maxx - minx) * (maxy - miny)];
        int index = 0;
        for(int i = minx; i < maxx; i++)
        {
            for(int j = miny; j < maxy; j++)
            {
               
                reachableTiles[index] = world[i][j];
                index++;
            }
        }*/

    }
    
    private static void colorReachableTiles(Color color)
    {
        for(int i = 0; i < reachableTiles.Length; i++)
        {
            reachableTiles[i].GetComponent<SpriteRenderer>().color = color;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
