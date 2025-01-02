using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCounter : MonoBehaviour
{
    public GameObject NPCobject;
    public Transform[] waypoints;
    public Transform NpcInstPoint;
    bool IsInstant = false;
    void NpcInstanter()
    {
        Instantiate(NPCobject, NpcInstPoint.transform.position, Quaternion.identity);
        IsInstant = true;
    }
    void Repeater()
    {
        IsInstant = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC") && !IsInstant)
        {
            Destroy(other.gameObject,5f);
            NpcInstanter();
            Invoke("Repeater", 0.1f);
        }
    }


}
