﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public Player player;
    public int moveStat = 3;
    public int attackRange = 1;
    public bool canCapture = true;
    public bool hasMoved = false;
    public const string SPRITE_NAME = "SpriteDump";
    
	void Start () {
        
	}
    public bool moveTo(Tile tile)
    {
        bool temp = false;
        Color tempcolor = player.color;
        tempcolor.r += (1f - tempcolor.r) * .5f;
        tempcolor.g += (1f - tempcolor.g) * .5f;
        tempcolor.b += (1f - tempcolor.b) * .5f;
        GetComponent<SpriteRenderer>().color = tempcolor;
        if (!hasMoved)
        {
            transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -1);
            temp = true;
        }
        hasMoved = true;
        tile.getUnitsAroundTile().ForEach(delegate (Unit unit)
        {
            if(unit.player != this.player)
            {
                unit.remove();
            }
        });
        return temp;
    }
    public void AssignToPlayer(Player player)
    {
        this.player = player;
    }
    public void startTurn()
    {
        GetComponent<SpriteRenderer>().color = player.color;
        hasMoved = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }
    public void remove()
    {
        player.removeUnit(this);
        Destroy(this.gameObject);
    }

	void OnMouseDown()
    {
        MovementController.selectUnit(this);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
