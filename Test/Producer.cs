using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer : MonoBehaviour
{
    public List<GameObject> Produced = new List<GameObject>();
    public int CountProuduced;
    public float TimeProduce;
    void Start()
    {
        for (int i = 0; i < Produced.Count; i++)
        {
            Produced[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
        StartCoroutine(EnumProduce());
    }
    IEnumerator EnumProduce()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeProduce);
            if (CountProuduced < Produced.Count - 1)
            {
                CountProuduced += 1;
                Produced[CountProuduced].SetActive(true);
            }
        }
    }
}
