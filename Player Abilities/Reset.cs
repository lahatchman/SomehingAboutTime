using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] public int roomNum;
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject player;
    [SerializeField] public Vector3 resetPoint;
    [SerializeField] MachineConsole machineparts;
    [SerializeField] private Safe safeDoor;
    [SerializeField] private Lever[] lever;

    [System.Serializable]
    public class RoomNumber
    {
        public string roomName;
        public Key[] keyCardsScriptToReset;
        public GameObject[] keyCardsGameObjectToReset;
        public MachinePartsCollection[] machinePartsScriptToReset;
        public GameObject[] machinePartsGameObjectToReset;
    }

    public RoomNumber[] roomNumber;

    void Start()
    {
        resetPoint = player.transform.position;
    }

    public void ResetFunction()
    {
        StartCoroutine(ResetCollectables());
        ResetPuzzles();
        controller.enabled = false;
        player.transform.position = resetPoint;
        controller.enabled = true;
    }

    IEnumerator ResetCollectables()
    {
        for (int i = 0; i < roomNumber[roomNum].keyCardsGameObjectToReset.Length; i++)
        {
            roomNumber[roomNum].keyCardsScriptToReset[i].haveKey = false;
            roomNumber[roomNum].keyCardsGameObjectToReset[i].SetActive(true);
        }

        for (int i = 0; i < roomNumber[roomNum].machinePartsGameObjectToReset.Length; i++)
        {
            roomNumber[roomNum].machinePartsScriptToReset[i].hasPart = false;
            roomNumber[roomNum].machinePartsGameObjectToReset[i].SetActive(true);
        }
        yield break;
    }

    private void ResetPuzzles()
    {
        if (roomNum == 2)
        {
            safeDoor.door.rotation = safeDoor.originalPos;
            safeDoor.safeColldier.enabled = true;
            safeDoor.code.codeCorrect = false;
        }
        else if (roomNum == 3)
        {
            StartCoroutine(ResetLevers());
        }
    }

    IEnumerator ResetLevers()
    {
        for (int i = 0; i < lever.Length; i++)
        {
            lever[i].on = false;
        }
        yield break;
    }
}
