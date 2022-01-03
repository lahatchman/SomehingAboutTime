using UnityEngine;

public class Lever : MonoBehaviour
{
    #region variables
    [SerializeField] public bool playerHere, on;
    [SerializeField] public Transform handle;
    [SerializeField] private float rotationDown, rotationUp, rotationSpeed;
    [SerializeField] private Quaternion target;
    #endregion

    void Start()
    {
        playerHere = false;
        on = false;
        target = Quaternion.Euler(rotationUp, 0.0f, 0.0f);
    }

    void Update()
    {
        if (playerHere)
        {
            PlayerInteract();
        }

        if (on)
        {
            HandleRotateDown();
        }
        else
        {
            HandleRotateUp();
        }

        handle.rotation = Quaternion.Slerp(handle.rotation, target, Time.deltaTime * rotationSpeed);
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

    void PlayerInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!on)
            {
                on = true;
            }
            else
            {
                on = false;
            }
        }
    }

    void HandleRotateDown()
    {
        target = Quaternion.Euler(-rotationDown, 0.0f, 0.0f);
    }

    void HandleRotateUp()
    {
        target = Quaternion.Euler(-rotationUp, 0.0f, 0.0f);
    }
}
