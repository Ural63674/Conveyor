using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    private bool isBoxInTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7) // 7 = Box
        {
            isBoxInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7) // 7 = Box
        {
            isBoxInTrigger = false;
        }
    }

    public bool IsBoxInTrigger()
    {
        return isBoxInTrigger;
    }
}
