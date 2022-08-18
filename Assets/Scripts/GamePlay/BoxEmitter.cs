using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEmitter : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private Transform boxEmitter;
    private GameObject _box;

    private void Start()
    {
        StartCoroutine(ILaunchNextBox());
    }

    private IEnumerator ILaunchNextBox()
    {
        yield return new WaitForSeconds(8);
        _box = Instantiate(boxPrefab, boxEmitter.position, Quaternion.identity);

        StartCoroutine(ILaunchNextBox());

    }
}
