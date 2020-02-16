using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button startGameButton;
    public Button modeButton;
    public Button settingButton;
    public Button closeWindowButton;

    public GameObject modeMenu;
    public GameObject elderWindow;
    public GameObject childWindow;
    public GameObject disabledWindow;
 
    public void Awake() {
        startGameButton.onClick.AddListener(StartGame);
        modeButton.onClick.AddListener(OpenModeMenu);
        settingButton.onClick.AddListener(GameSettings);
        closeWindowButton.onClick.AddListener(CloseElderWindow);
    }

    public void StartGame() {
        SceneManager.LoadScene("DoctorOffice");
    }

    public void OpenModeMenu() {
        modeMenu.SetActive(true);
    }

    public void GameSettings() {
        Application.Quit();
    }

    public void LoadElderWindow() {
        elderWindow.SetActive(true);
    }
    public void CloseElderWindow() {
        elderWindow.SetActive(false);
        modeMenu.SetActive(false);
    }

    public void LoadChildWindow() {
        childWindow.SetActive(true);
    }
    public void CloseChildWindow() {
        childWindow.SetActive(false);
        modeMenu.SetActive(false);
    }

    public void LoadDisabledWindow() {
        disabledWindow.SetActive(true);
    }
    public void CloseDisabledWindow() {
        disabledWindow.SetActive(false);
        modeMenu.SetActive(false);
    }
}
