using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7) // 7 = Box
        {
            if (other.gameObject.CompareTag("Circle"))
            {
                EventManager.SendCirclePressed();
            }
            
            if (other.gameObject.CompareTag("Square"))
            {
                EventManager.SendSquarePressed();
            }

            Destroy(other.gameObject);
        }
    }
}
