﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    private int cpuScore;
    private int playerScore;
    public Vector2 ballPosition;

    public int CpuScore { get { return cpuScore; } set { this.cpuScore = value; } }
    public int PlayerScore { get { return playerScore; } set { this.playerScore = value; } }



    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        cpuScore = 0;
        playerScore = 0;
	}
	
	void Update () {
        // fare metodo per log

        Debug.Log("Player score: " + playerScore.ToString());
        Debug.Log("CPU score: " + cpuScore.ToString());

    }

    public void incrementCPUScore() {
        cpuScore++;
    }

    public void incrementPlayerScore() {
        playerScore++;
    }
}
