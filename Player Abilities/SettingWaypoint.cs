using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingWaypoint : MonoBehaviour
{
    //Serialized Private Variables
    [Header("Script Attributes")]
    [SerializeField] private bool canSetWaypoint;
    [SerializeField] private GameObject player;
    [SerializeField] private TimeReversal timeReversal;
    [SerializeField] private Reset reset;

    private void Start()
    {
        canSetWaypoint = false;
        player = GameObject.Find("Player");
        timeReversal = player.GetComponent<TimeReversal>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            canSetWaypoint = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            canSetWaypoint = false;
        }
    }

    void Update()
    {
        if (canSetWaypoint && Input.GetKeyDown(KeyCode.E))
        {
            timeReversal.SetWaypoint();
            reset.resetPoint = player.transform.position;
        }
    }

}
