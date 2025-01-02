using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    Animator Animator;
    Barn Barn;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Barn = transform.GetComponentInParent<Barn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Barn.BPumpkinsCount > 0)
        {
            Animator.SetBool("Eat", true);
        }
        else
        {
            Animator.SetBool("Eat", false);
        }
    }
}
