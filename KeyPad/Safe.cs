using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] private GameObject keyPad, playerHud;
    [SerializeField] public Transform door;
    [SerializeField] private Quaternion target;
    [SerializeField] public Quaternion originalPos;
    [SerializeField] private float rotation, rotationSpeed;
    [SerializeField] public KeyPad code;
    [SerializeField] private bool playerHere;
    [SerializeField] public Collider safeColldier;

    void Start()
    {
        playerHere = false;
        target = Quaternion.Euler(0.0f, rotation, 0.0f);
        originalPos = door.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHere)
        {
            keyPad.SetActive(true);
            playerHud.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (code.codeCorrect)
        {
            playerHere = false;
            safeColldier.enabled = false;
            door.rotation = Quaternion.Slerp(door.rotation, target, Time.deltaTime * rotationSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHere = false;
        }
    }
}
