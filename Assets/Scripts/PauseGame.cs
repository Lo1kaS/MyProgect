using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private Canvas Interface;
    [SerializeField]
    private GameObject OptionMenu;
    [SerializeField]
    private Canvas PauseMenu;

    public bool isPaused = false;

    private InputSettings _input;
    private void Awake()
    {
        _input = new InputSettings();


    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Start()
    {
        OptionMenu.SetActive(false);
        Menu.SetActive(false);
    }
    void Update()
    {

        if (_input.Player.Menu.WasPressedThisFrame())
        {
            PauseSwitch();                
        }
    }
    private void PauseSwitch()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Pause();
        }
        else
        {
            unPause();
        }
    }
     public void OptionsMenu()
    {
        PauseMenu.enabled = false;
        OptionMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Interface.enabled = false;
        PauseMenu.enabled = true;
        Menu.SetActive(true);
    }
    private void unPause()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Interface.enabled = true;
        PauseMenu.enabled = false;
        OptionMenu.SetActive(false);
        Menu.SetActive(false);
    }
    public void BackToGame()
    {
        unPause();
        isPaused = false;
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        unPause();
        isPaused = false;
    }
    public void Back()
    {
        PauseMenu.enabled = true;
        OptionMenu.SetActive(false);
    }
}
