using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] private GameObject formCircle;
    [SerializeField] private GameObject formSquare;
    [SerializeField] private BoxTriggerScript _boxTriggerScript;
    private bool _isFirstConveyer;
    private bool _isSecondConveyer;
    private bool _isThirdConveyer;
    private Rigidbody rigidbody;
    private float coeffOfDeceleration = 0.94f; //Коэффициент замедления на 2 конвейере (разница координат X первой и второй руки, разделенная на время движения коробки)
    private float coeffAcceltration = 1.25f; //Коэффициент ускорения на 1 конвейере (разница координат Z первой руки и эмиттера, разделенная на время движения коробки)

    private void Awake()
    {
        _isFirstConveyer = true;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isFirstConveyer == true && _boxTriggerScript.IsFirstConveyer() == true)
        {
            transform.Translate(Vector3.back * coeffAcceltration * Time.deltaTime);
        }

        if (_isSecondConveyer == true && _boxTriggerScript.IsSecondConveyer() == true)
        {
            transform.Translate(Vector3.back* coeffOfDeceleration * Time.deltaTime);            
        }

        if (_isThirdConveyer)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "press1")
        {
            formCircle.SetActive(true);
            gameObject.GetComponentInParent<Transform>().tag = "Circle";
        }

        if(collision.gameObject.name == "press2")
        {
            formSquare.SetActive(true);
            formCircle.SetActive(false);
            gameObject.GetComponentInParent<Transform>().tag = "Square";
        }

        if(collision.gameObject.name == "conveyor2")
        {
            _isSecondConveyer = true;
            gameObject.transform.parent = null;
            rigidbody.useGravity = true;
        }

        if(collision.gameObject.name == "conveyor3")
        {
            _isThirdConveyer = true;
            gameObject.transform.parent = null;
            rigidbody.useGravity = true;
        }
    }
}
