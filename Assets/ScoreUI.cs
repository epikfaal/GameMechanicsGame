using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
    public Player player;
	// Use this for initialization

    public void updateFunds(int funds)
    {
        Text text = GetComponent<Text>();
        text.text = "money: " + funds;
    }
	void Start () {
        player.setUI(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
