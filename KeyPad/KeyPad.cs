using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    [Header("Editable Values")]
    [SerializeField] private int num;
    [SerializeField] private string parsedCode;
    [SerializeField] private string correctCode;
    [SerializeField] public bool codeCorrect;
    [SerializeField] private GameObject keyPad, playerHud, machinePart;
    [SerializeField] private TextMeshProUGUI displayKeyCode;

    void HidePanel(GameObject panel) => panel.SetActive(false); //function for hiding UI panels

    #region NumPad Keys
    public void NumZero()
    {
        num = 0;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumOne()
    {
        num = 1;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumTwo()
    {
        num = 2;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumThree()
    {
        num = 3;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumFour()
    {
        num = 4;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumFive()
    {
        num = 5;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumSix()
    {
        num = 6;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumSeven()
    {
        num = 7;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumEight()
    {
        num = 8;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void NumNine()
    {
        num = 9;
        if (parsedCode.Length < 4)
        {
            parsedCode += num.ToString();
            displayKeyCode.text = parsedCode;
        }
    }

    public void Enter()
    {
        if (parsedCode == correctCode)
        {
            parsedCode = "";
            displayKeyCode.text = parsedCode;
            machinePart.SetActive(true);
            HidePanel(keyPad);
            codeCorrect = true;
            Time.timeScale = 1;
            playerHud.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            parsedCode = "False";
            displayKeyCode.text = parsedCode;
            parsedCode = "";
        }
    }

    public void Clear()
    {
        parsedCode = "";
        displayKeyCode.text = parsedCode;
    }

    public void Close()
    {
        parsedCode = "";
        displayKeyCode.text = parsedCode;
        HidePanel(keyPad);
        Time.timeScale = 1;
        playerHud.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion
}
