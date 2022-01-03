using UnityEngine;

public class ResetAccessNumber : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private Reset reset;
    [SerializeField] private int resetNumber;

    void OnTriggerEnter(Collider coll)
    {
        reset.roomNum = resetNumber;
    }
}
