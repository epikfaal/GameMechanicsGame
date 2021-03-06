﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour, BuildingInterface {
    private static int count = 0;
    Player player;
    Tile tile;
	// Use this for initialization
	void Start () {
		
	}
	public void assignToPlayer(Player player)
    {
        if (this.player) this.player.removeCity(this);
        this.player = player;
        player.addCity(this);
        Color tempcolor = player.color;
        tempcolor.a = 0.7f;
        GetComponent<SpriteRenderer>().color = tempcolor;
    }
    public static City Create(int x, int y, Tile[][] world)
    {
        GameObject go = new GameObject("city " + count);
        count++;
        go.transform.position = new Vector3(x, y, -.5f);
        go.transform.localScale = new Vector3(3f, 3f, 1f);
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>() as SpriteRenderer;
        GameObject spritego = GameObject.FindGameObjectWithTag("CitySpriteDump");

        sr.sprite = spritego.GetComponent<SpriteRenderer>().sprite;
        sr.color = new Color(1f, 1f, 1f, 1);

        City city = go.AddComponent<City>() as City;
        city.setTile(world[x][y]);

        go.AddComponent<BoxCollider2D>();
        return city;
    }
    private void OnMouseDown()
    {
        MovementController.moveUnit(tile, this);
    }
    private void setTile(Tile tile)
    {
        this.tile = tile;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
