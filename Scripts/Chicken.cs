using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chicken : MonoBehaviour
{
    Coop Coop;
    public Transform EatTransform;
    Animator Animator;
    private void Start()
    {
        Animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Coop coop = GetComponentInParent<Coop>();
        if (coop.CWheatCount > 0)
        {
            transform.GetChild(0).transform.position = EatTransform.transform.position;
            transform.GetChild(0).transform.LookAt(Vector3.zero);
            Animator.SetBool("Eat", true);
        }
        else
        {
            Animator.SetBool("Eat", false);
            transform.GetChild(0).transform.position = gameObject.transform.position;
            transform.LookAt(FindObjectOfType<Player>().transform.position);
        }
       
    }
}