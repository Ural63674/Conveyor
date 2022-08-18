using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerScript : MonoBehaviour
{
    private bool _isFirstConveyer;
    private bool _isSecondConveyer;
    [SerializeField] GameObject box;

    private void Awake()
    {
        _isFirstConveyer = true;
        _isSecondConveyer = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CubeTrigger1")
        {
            _isFirstConveyer = false;
            box.transform.SetParent(other.transform);
            box.GetComponent<Rigidbody>().useGravity = false;

            _isSecondConveyer = true;
        }

        if(other.gameObject.name == "CubeTrigger2")
        {
            _isSecondConveyer = false;
            box.transform.SetParent(other.transform);
            box.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public bool IsFirstConveyer()
    {
        return _isFirstConveyer;
    }

    public bool IsSecondConveyer()
    {
        return _isSecondConveyer;
    }
}
