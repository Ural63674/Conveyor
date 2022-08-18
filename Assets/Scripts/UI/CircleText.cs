using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleText : MonoBehaviour
{
    private int _circleText = 0;

    void Awake()
    {
        EventManager.OnCircleFinished.AddListener(AddPointToCircle);
    }

    private void AddPointToCircle()
    {
        _circleText++;
        GetComponent<Text>().text = "/" + _circleText;
    }
}
