using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObjects : MonoBehaviour
{
    [SerializeField] private LayerMask _interactableObjectMask;
    private Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;       
    }

    void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out raycastHit, Mathf.Infinity, _interactableObjectMask))
        {
            raycastHit.transform.GetComponentInChildren<Animator>().SetBool("isPressActive", true);

        }
    }  
}
