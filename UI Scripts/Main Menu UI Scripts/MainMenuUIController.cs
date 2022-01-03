using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    //Serialized Private Variables
    [Header("Script Attributes (Non-Editable)")]
    [SerializeField] private string gameScene;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject hideMenuUI;
    [SerializeField] private bool uiHidden = false;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void SceneChange(string scene) => SceneManager.LoadScene(scene); //function for changing scene

    void ShowPanel(GameObject panel) => panel.SetActive(true); //function for showing UI panels

    void HidePanel(GameObject panel) => panel.SetActive(false); //function for hiding UI panels

    public void StartGame() => SceneChange(gameScene); //Start the game

    public void ControlsReturn()
    {
        HidePanel(controlsPanel);
        ShowPanel(mainMenuPanel);
    }

    public void CreditsReturn()
    {
        HidePanel(creditsPanel);
        ShowPanel(mainMenuPanel);
    }

    public void OpenControls()
    {
        HidePanel(mainMenuPanel);
        ShowPanel(controlsPanel);
    }

    public void OpenCredits()
    {
        HidePanel(mainMenuPanel);
        ShowPanel(creditsPanel);
    }

    public void HideUI()
    {
        if (!uiHidden)
        {
            HidePanel(hideMenuUI);
            uiHidden = true;
        }
        else
        {
            ShowPanel(hideMenuUI);
            uiHidden = false;
        }
    }

    public void ExitGame() => Application.Quit();
}
