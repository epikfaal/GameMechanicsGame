using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour, BuildingInterface  {

    private static int count;
    Player player;
    Tile tile;
	// Use this for initialization
	void Start () {
		
	}

    void OnMouseDown()
    {
        bool occupied = tile.isUnitOnTile();

        MovementController.moveUnit(tile, this);
        
        if(!tile.isUnitOnTile() && TurnManager.currentPlayer == player && TurnManager.currentPlayer.funds >= 5000)
        {
            TurnManager.currentPlayer.funds -= 5000;
            TurnManager.currentPlayer.createUnit(tile, "SpecialUnitSprite");
            TurnManager.currentPlayer.UI.updateFunds(TurnManager.currentPlayer.funds);
        }
    }
    public static Factory Create(int x, int y, Tile[][] world)
    {
        GameObject go = new GameObject("Factory " + count);
        count++;
        go.transform.position = new Vector3(x, y, -.5f);
        go.transform.localScale = new Vector3(3f, 3f, 1f);
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>() as SpriteRenderer;
        GameObject spritego = GameObject.FindGameObjectWithTag("FactorySpriteDump");

        sr.sprite = spritego.GetComponent<SpriteRenderer>().sprite;
        sr.color = new Color(1f, 1f, 1f, 1);

        Factory factory = go.AddComponent<Factory>() as Factory;
        factory.setTile(world[x][y]);

        go.AddComponent<BoxCollider2D>();
        return factory;
    }

    public void assignToPlayer(Player player)
    {
        this.player = player;
        Color tempcolor = player.color;
        tempcolor.a = 0.8f;
        GetComponent<SpriteRenderer>().color = tempcolor;
    }

    private void setTile(Tile tile)
    {
        this.tile = tile;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
