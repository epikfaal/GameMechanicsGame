using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    public static Player player1, player2, currentPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
    static public void addPlayer (Player player)
    {
        if (player1)
        {
            player2 = player;
        } else
        {
            player1 = currentPlayer = player;
        }
    }
    public void switchTurn()
    {
        Debug.Log("switching turn");
        if(currentPlayer == player1)
        {
            currentPlayer = player2;
            currentPlayer.startTurn();
        } else
        {
            currentPlayer = player1;
            currentPlayer.startTurn();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
