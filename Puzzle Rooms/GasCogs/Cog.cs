using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    [SerializeField] public int cogPos, correctPos;
    [SerializeField] public bool playerHere;
    [SerializeField] public bool cogCorrect;
    [SerializeField] public Collider colldier;
    [SerializeField] public Quaternion originRot;

    void Start()
    {
        cogPos = 0;
        cogCorrect = false;
        originRot = this.transform.rotation;
    }

    void Update()
    {
        if (playerHere)
        {
            CogRotate();
        }

        if (cogPos == correctPos)
        {
            cogCorrect = true;
        }
        else
        {
            cogCorrect = false;
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

    void CogRotate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.Rotate(this.transform.rotation.x - 90.0f, this.transform.rotation.y, this.transform.rotation.z);
            if (cogPos >= 3)
            {
                cogPos = 0;
            }
            else
            {
                cogPos++;
            }
        }
    }
}
