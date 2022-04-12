using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField] private GameObject hudCanvas = null;
    [SerializeField] private GameObject PauseCanvas = null;
    [SerializeField] private GameObject deathscreenCanvas = null;

    private CameraController cameraController = null;
    private PlayerStats stats = null;
   

    private void Start()
    {
        GetReferences();
        SetActiveHud(true);
    }

    private void Update()
    {
        if (!stats.IsDead())
        {
            if (Input.GetKeyUp(KeyCode.P) && !isPaused)
                SetActivePause(true);
            else if (Input.GetKeyUp(KeyCode.P) && isPaused)
                SetActivePause(false);
        }
        
    }

    public void SetActiveHud(bool state)
    {
        hudCanvas.SetActive(state);
        deathscreenCanvas.SetActive(!state);
        
        if (!stats.IsDead())
            PauseCanvas.SetActive(!state);
    }

    public void SetActivePause(bool state)
    {
        PauseCanvas.SetActive(state);
        hudCanvas.SetActive(!state);
        
        Time.timeScale = state ? 0 : 1;
        if(state)
            cameraController.UnlockCursor();
        else
            cameraController.LockCursor();
        isPaused = state;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void GetReferences()
    {
        cameraController = GetComponentInChildren<CameraController>();
        stats = GetComponent<PlayerStats>();
    }
}
