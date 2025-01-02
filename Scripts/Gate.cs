using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Gate : MonoBehaviour
{
    public GameObject Gate1, Gate2;
    void Start()
    {
      
    }
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        Gate1.gameObject.transform.DOScaleX(0.001f, 0.1f);
        Gate2.gameObject.transform.DOScaleX(0.001f, 0.1f);
    }
    private void OnTriggerExit(Collider other)
    {
        Gate1.gameObject.transform.DOScaleX(0.3f, 0.1f);
        Gate2.gameObject.transform.DOScaleX(0.3f, 0.1f);
    }
}
