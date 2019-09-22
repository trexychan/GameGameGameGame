﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePausing : PauseBehaviour
{
    [SerializeField] private GameObject _pauseCanvas = null;
    private bool _paused = false;

    protected override void Start() {
        base.Start();
        _pauseCanvas.SetActive(false);
    }

    protected override void OnStateEnter() {
        _paused = true;
        _pauseCanvas.SetActive(true);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (_paused) {
                ReturnToGame();
            } else {
                GameStateManager.INSTANCE.TriggerStateChange(GameState.INPAUSE);
            }
        }
    }

    protected override void OnStateExit() {
        _pauseCanvas.SetActive(false);
        _paused = false;
    }

    public void ExitRun() {
        PersistentDataManager.run.exitEarly = true;
        GameStateManager.INSTANCE.TriggerStateChange(GameState.INGAME);
        GameStateManager.INSTANCE.TriggerStateChange(GameState.EXITING);
    }

    public void ReturnToGame() {
        GameStateManager.INSTANCE.TriggerStateChange(GameState.INGAME);
    }
}
