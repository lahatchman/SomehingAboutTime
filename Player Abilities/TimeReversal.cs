using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeReversal : MonoBehaviour
{
    //Serialized Private Variables
    [Header("Editable Values")]
    [SerializeField] private float rewindSpeed;
    [Header("Script Attributes")]
    [SerializeField] public List<Vector3> waypoints;
    [SerializeField] private float posLerp;
    [SerializeField] private Vector3 pointVecLine;
    [SerializeField] private int listIncrease;
    [SerializeField] public bool isRewinding, canSetWaypoint, canReverse;

    void Start()
    {
        waypoints = new List<Vector3>();
        isRewinding = false;
        canSetWaypoint = false;
        canReverse = false;
    }

    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && canSetWaypoint) //1 Key
        {
            CancelInvoke();
            StopAllCoroutines();
            waypoints.Clear();
            waypoints.Insert(0, transform.position);
            listIncrease = 1;
            InvokeRepeating("PosRecord", 2.0f, 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && canReverse) //2 Key
        {
            CancelInvoke();
            StopAllCoroutines();
            isRewinding = true;
            StartCoroutine(PosRewind());
        }

        if (waypoints.Count <= 0)
        {
            CancelInvoke();
            StopAllCoroutines();
            waypoints.Insert(0, transform.position);
            listIncrease = 1;
            InvokeRepeating("PosRecord", 2.0f, 2.0f);
        }
    }

    public void SetWaypoint()
    {
        CancelInvoke();
        StopAllCoroutines();
        waypoints.Clear();
        waypoints.Insert(0, transform.position);
        listIncrease = 1;
        InvokeRepeating("PosRecord", 2.0f, 2.0f);
    }

    IEnumerator PosRewind() //Returns the player to previous positions
    {
        while (posLerp <= 1.0f)
        {
            if (waypoints.Count > 0)
            {
                posLerp += Time.deltaTime * rewindSpeed;
                transform.position = Vector3.Lerp(transform.position, waypoints[waypoints.Count - 1], posLerp);
            }
            yield return null;
        }
        posLerp = 0.0f;
        waypoints.RemoveAt(waypoints.Count - 1);
        StartCoroutine(PosRewind());

        if (waypoints.Count <= 0) isRewinding = false;
    }

    IEnumerator PosRecord() //Stores the players previous positions 
    {
        if (waypoints.Count < 10)
        {
            waypoints.Add(transform.position + (0.1f * listIncrease) * Vector3.Normalize(transform.position - waypoints[0]));
            listIncrease++;
        }
        else
        {
            listIncrease = 1; 
            waypoints.RemoveAt(listIncrease);
        }
        return null;
    }
}
