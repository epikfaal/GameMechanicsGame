using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Color color;
    public float startX, startY;
    private List<Unit> units;
    private List<City> citys;
    public int funds = 0;
    public ScoreUI UI;
    public Tile tile;
	// Use this for initialization
	void Start () {
        units = new List<Unit>();
        citys = new List<City>();
        color.a = 1f;
        TurnManager.addPlayer(this);

        GameObject go = new GameObject("unit" + color);
        Unit unit = go.AddComponent<Unit>() as Unit;
        unit.AssignToPlayer(this);
        units.Add(unit);
        go.transform.position = new Vector3(startX, startY, -1f);
        SpriteRenderer sr2 = go.AddComponent<SpriteRenderer>() as SpriteRenderer;
        GameObject array = GameObject.FindGameObjectWithTag("SpriteDump");
        sr2.sprite = array.GetComponent<SpriteRenderer>().sprite;
        sr2.color = color;

       

        BoxCollider2D bc2D = go.AddComponent<BoxCollider2D>() as BoxCollider2D;
        
    }
    void OnMouseDown()
    {
        
        tile.OnMouseDown();
        if(tile.isUnitOnTile() && !isUnitOnTile(tile))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void createUnit(Tile tile, string spriteName = "SpriteDump")
    {
        GameObject go = new GameObject("unit" + units.Count);
        Unit unit = go.AddComponent<Unit>() as Unit;
        unit.AssignToPlayer(this);
        units.Add(unit);
        go.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, -1f);
        SpriteRenderer sr2 = go.AddComponent<SpriteRenderer>() as SpriteRenderer;
        GameObject array = GameObject.FindGameObjectWithTag(spriteName);
        sr2.sprite = array.GetComponent<SpriteRenderer>().sprite;
        sr2.color = new Color(color.r, color.g, color.b, 0.4f);

        SpecialUnit su = array.GetComponent<SpecialUnit>() as SpecialUnit;
        go.transform.localScale = new Vector3(su.Scale, su.Scale, 1);
        unit.moveStat = su.moveStat;
        unit.canCapture = su.canCapture;
        unit.attackRange = su.attackRange;

        unit.hasMoved = true;
        
        BoxCollider2D bc2D = go.AddComponent<BoxCollider2D>() as BoxCollider2D;
    }
    public void startTurn()
    {
        funds += citys.Count * 1000;
        UI.updateFunds(funds);
        //income handling
        units.ForEach(delegate (Unit unit)
        {
            unit.startTurn();
        });
    }

    public void addUnit(Unit unit)
    {
        units.Add(unit);
    }

    public void removeUnit(Unit unit)
    {
        units.Remove(unit);
    }
    public void addCity(City city)
    {
        citys.Add(city);
    }
    public void removeCity(City city)
    {
        citys.Remove(city);
    }
    public void setUI(ScoreUI sUI)
    {
        UI = sUI;
    }
    public bool isUnitOnTile(Tile tile)
    {
        bool isOnTile = false;
        units.ForEach(delegate (Unit unit)
        {
            if(unit.transform.position.x == tile.transform.position.x && unit.transform.position.y == tile.transform.position.y)
            {
                isOnTile = true;
                return;
            }
        });
        return isOnTile;
    }
    public List<Unit> getUnitsAroundTile(Tile tile)
    {
        List<Unit> unitsaroundtile = new List<Unit>();
        units.ForEach(delegate (Unit unit)
        {
           if(unit.transform.position.x == tile.transform.position.x && (unit.transform.position.y == tile.transform.position.y -1 || unit.transform.position.y == tile.transform.position.y + 1)){
                unitsaroundtile.Add(unit);
            }
            if (unit.transform.position.y == tile.transform.position.y && (unit.transform.position.x == tile.transform.position.x - 1 || unit.transform.position.x == tile.transform.position.x + 1))
            {
                unitsaroundtile.Add(unit);
            }
        });
        return unitsaroundtile;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
