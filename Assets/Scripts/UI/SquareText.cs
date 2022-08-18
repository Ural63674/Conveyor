using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareText : MonoBehaviour
{
    private int _squareText = 0;

    void Awake()
    {
        EventManager.OnSquareFinished.AddListener(AddPointToSquare);
    }

    private void AddPointToSquare()
    {
        _squareText++;
        GetComponent<Text>().text = "/" + _squareText;  
    }
}
