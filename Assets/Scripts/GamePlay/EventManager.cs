using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent OnCircleFinished = new UnityEvent();
    public static UnityEvent OnSquareFinished = new UnityEvent();

    public static void SendCirclePressed()
    {
        OnCircleFinished.Invoke();
    }

    public static void SendSquarePressed()
    {
        OnSquareFinished.Invoke();
    }
}
