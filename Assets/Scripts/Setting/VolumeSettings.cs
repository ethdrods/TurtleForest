using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class VolumeSettings : MonoBehaviour
{
    public GameObject settingsPanel;
    bool activeSettings  = false;
    
    // Start is called before the first frame update
    void Start()
    {
        settingsPanel.SetActive(activeSettings);
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))//Oculus startŰ
        {
            activeSettings = !activeSettings;
            settingsPanel.SetActive(activeSettings);

            GameState currentGameState = GameManager.GetInstance().CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay ? GameState.Pause : GameState.Gameplay;

            Debug.Log("currentGameState : " + currentGameState);
            Debug.Log("newGameState : " + newGameState);

            GameManager.GetInstance().SetState(newGameState);
        }
    }
}
