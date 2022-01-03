using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{
    public MachineConsole mc;
    [SerializeField] private Key[] keyCardsScriptToReset;
    [SerializeField] private GameObject[] keyCardsGameObjectToReset;
    [SerializeField] private MachinePartsCollection[] machinePartsScriptToReset;
    [SerializeField] private MachinePartsCollection coilScriptToReset;
    [SerializeField] private GameObject[] machinePartsGameObjectToReset;
    [SerializeField] private GameObject MachinePart1, MachinePart2, MachinePart3, rewindButtonActive, waypointButtonActive, rewindButtonInactive, waypointButtonInactive;
    [SerializeField] private TimeReversal timeReversal;
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject resetPoint;
    [SerializeField] private MachineConsole machineConsole;
    [SerializeField] private Safe safeDoor;
    [SerializeField] private Lever[] lever;
    [SerializeField] private Cog[] cogs;

    void Start()
    {
        MachineConsole mc = gameObject.GetComponent<MachineConsole>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (mc.machineComplete) SceneManager.LoadScene("MainMenu");
        else LevelReset();
    }

    private void LevelReset()
    {
        StartCoroutine(ResetCollectables());
        StartCoroutine(ResetLevers());
        StartCoroutine(ResetCogs());
        RestAbilities();
        ResetMachine();
        ResetPuzzles();
        coilScriptToReset.hasPart = false;
        controller.enabled = false;
        player.transform.position = resetPoint.transform.position;
        controller.enabled = true;
    }

    IEnumerator ResetCollectables()
    {
        for (int i = 0; i < keyCardsGameObjectToReset.Length; i++)
        {
            keyCardsScriptToReset[i].haveKey = false;
            keyCardsGameObjectToReset[i].SetActive(true);
        }

        for (int i = 0; i < machinePartsGameObjectToReset.Length; i++)
        {
            machinePartsScriptToReset[i].hasPart = false;
            machinePartsGameObjectToReset[i].SetActive(true);
        }
        yield break;
    }

    private void RestAbilities()
    {
        rewindButtonActive.SetActive(false);
        waypointButtonActive.SetActive(false);
        rewindButtonInactive.SetActive(true);
        waypointButtonInactive.SetActive(true);
        timeReversal.canReverse = false;
        timeReversal.canSetWaypoint = false;
    }

    private void ResetMachine()
    {
        MachinePart1.GetComponent<Renderer>().enabled = false;
        MachinePart2.GetComponent<Renderer>().enabled = false;
        MachinePart3.GetComponent<Renderer>().enabled = false;
        machineConsole.MachineParts = 0;
    }

    private void ResetPuzzles()
    {
        safeDoor.door.rotation = safeDoor.originalPos;
        safeDoor.safeColldier.enabled = true;
        safeDoor.code.codeCorrect = false;
    }

    IEnumerator ResetLevers()
    {
        for (int i = 0; i < lever.Length; i++)
        {
            lever[i].on = false;
        }
        yield break;
    }

    IEnumerator ResetCogs()
    {
        for (int i = 0; i < cogs.Length; i++)
        {
            cogs[i].cogPos = 0;
            cogs[i].transform.rotation = cogs[i].originRot;
        }
        yield break;
    }
}
