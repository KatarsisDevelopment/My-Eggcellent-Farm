using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public Transform[] WayPoints;
    public int CurrentPoint;
    public float NpcSpeed = 1f;
    Animator Animator;
    public int NpcOrderCount;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, WayPoints[CurrentPoint].transform.position, NpcSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, WayPoints[CurrentPoint].transform.position) >= 0.1f)
        {
            transform.LookAt(WayPoints[CurrentPoint].transform.position);
        }
        else
        {
            transform.LookAt(transform.forward);
        }
        if (Vector3.Distance(transform.position, WayPoints[CurrentPoint].transform.position) >= 0.1f)
        {
            Animator.SetBool("Walk", true);
        }
        else
        {
            Animator.SetBool("Walk", false);
        }
        if (NpcOrderCount < 2)
        {
            Animator.SetBool("Carry", true);
            
        }
    }
}
