using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    private int x, y;
    public int getX() { return x; }
    public int getY() { return y; }
    public void setX(int x) { this.x = x; }
    public void setY(int y) { this.y = y; }
    public int movCost;
    // Use this for initialization

    
	void Start () {

        movCost = 1;
	}

    // currently works only if all movementcost = 1;
    public int getMoveCostToTile(Tile other)
    {
        int horizontal = (x - other.getX() < 0) ? -(x - other.getX()) : x - other.getX();
        int vertical = (y - other.getY() < 0) ? -(y - other.getY()) : y - other.getY();

        return horizontal + vertical;
    }

    void setParent(Sprite newParent)
    {

    }
	public void OnMouseDown()
    {
        /*Debug.Log("x: " + x + " y: " + y);
        if (Unit.unitSelected)
        {
            
            Unit.selectedUnit.transform.position = this.transform.position;
            Unit.unitSelected = false;
            MovementController.deselectUnit();
        }
        Debug.Log(Unit.unitSelected);*/
        

        MovementController.moveUnit(this);
    }
    public bool isUnitOnTile()
    {
        bool isOntile = TurnManager.player1.isUnitOnTile(this);
        if (!isOntile) isOntile = TurnManager.player2.isUnitOnTile(this);
        return isOntile;
    }

    public List<Unit> getUnitsAroundTile()
    {
        List<Unit> list = TurnManager.player1.getUnitsAroundTile(this);
        list.AddRange(TurnManager.player2.getUnitsAroundTile(this));
        

        return list;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
