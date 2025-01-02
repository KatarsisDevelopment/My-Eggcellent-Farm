using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    public bool Collected,Watering;
    [SerializeField] private float GrowSpeed = 3f;
    void Start()
    {
        StartCoroutine(WGrowEnum());
    }
    IEnumerator WGrowEnum()
    {
        while (true)
        {
            
            if (Collected)
            {
                GetComponent<BoxCollider>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
                yield return new WaitForSeconds(GrowSpeed);
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);
                    yield return new WaitForSeconds(GrowSpeed);
                    transform.GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                    Collected = false;
                    GetComponent<BoxCollider>().enabled = true;

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
