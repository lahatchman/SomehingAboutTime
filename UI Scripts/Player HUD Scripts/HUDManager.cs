using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    //Serialized Private Variables
    [Header("Script Attributes (Non-Editable)")]
    //Images Variables
    [SerializeField] private GameObject setWaypointImgActive;
    [SerializeField] private GameObject setWaypointImgInactive;
    [SerializeField] private GameObject rewindImgActive;
    [SerializeField] private GameObject rewindImgInactive;
    //Variables for Pause Menu
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Reset reset;
    [SerializeField] TimeReversal timeReversal;

    void Update()
    {
        Pressed1();
        Pressed2();
        PressedEsc();
    }

    private void SetImgActive(GameObject activeImage) => activeImage.SetActive(true);

    private void SetImgInactive(GameObject activeImage) => activeImage.SetActive(false);

    private void Pressed1() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && hud.activeSelf && timeReversal.canReverse)
        {
            SetImgInactive(setWaypointImgActive);
            SetImgActive(setWaypointImgInactive);
            StartCoroutine(Timer(0.5f, setWaypointImgActive, setWaypointImgInactive));
        }
    }

    private void Pressed2() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && hud.activeSelf && timeReversal.canSetWaypoint)
        {
            SetImgInactive(rewindImgActive);
            SetImgActive(rewindImgInactive);
            StartCoroutine(Timer(0.5f, rewindImgActive, rewindImgInactive));
        }
    }

    private void PressedEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && hud.activeSelf)
        {
            Time.timeScale = 0;
            hud.SetActive(false);
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !hud.activeSelf)
        {
            Time.timeScale = 1;
            hud.SetActive(true);
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        hud.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Reset()
    {
        Time.timeScale = 1;
        hud.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        reset.ResetFunction();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator Timer(float timer, GameObject activeImage, GameObject inactiveImage)
    {
        yield return new WaitForSeconds(timer);
        SetImgInactive(inactiveImage);
        SetImgActive(activeImage);
    }
}
