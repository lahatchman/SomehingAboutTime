using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [SerializeField] GameObject gas;
    [SerializeField] Cog[] cogs;

    void Update()
    {
        if (cogs[0].cogCorrect && cogs[1].cogCorrect && cogs[2].cogCorrect && cogs[3].cogCorrect)
        {
            gas.SetActive(false);
            cogs[0].colldier.enabled = false;
            cogs[1].colldier.enabled = false;
            cogs[2].colldier.enabled = false;
            cogs[3].playerHere = false;
            cogs[3].colldier.enabled = false;
        }
        else
        {
            gas.SetActive(true);
            cogs[0].colldier.enabled = true;
            cogs[1].colldier.enabled = true;
            cogs[2].colldier.enabled = true;
            cogs[3].colldier.enabled = true;
        }
    }
}
