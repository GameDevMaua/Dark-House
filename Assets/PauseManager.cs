using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour , PlayerInputActionMap.IPauseActions
{

    public GameObject pauseMenuPrefab;
    public GameObject menuInstance;
    public AudioListener playerAudioListener;
    
    private PlayerInputActionMap.PauseActions pauseAction;

    public void Pause()
    {
        if (menuInstance)
        {
            return;
        }
        print("pause");
        menuInstance = Instantiate(pauseMenuPrefab);
        Time.timeScale = 0;
        playerAudioListener.enabled = false;
    }

    public void UnPause()
    {
        if (menuInstance == null)
        {
            return;
        }
        print("unpause");

        Destroy(menuInstance);
        Time.timeScale = 1;
        playerAudioListener.enabled = true;
    }

    private void Start()
    {
        
    }

    private void Awake()
    {
        var map = new PlayerInputActionMap();
        pauseAction = new PlayerInputActionMap.PauseActions(map);
        
        pauseAction.SetCallbacks(this);
    }

    private void OnEnable()
    {
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.Disable();
    }

    public void OnEsc(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
        {
            return;
        }
        
        if (!context.ReadValueAsButton()) return;
        //print("a");
        if (Time.timeScale == 0)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }
}
