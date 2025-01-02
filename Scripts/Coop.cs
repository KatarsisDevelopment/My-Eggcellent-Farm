using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coop : MonoBehaviour
{
    public List<GameObject> CWheats = new List<GameObject>();
    public int CWheatCount;
    public List<GameObject> Eggs = new List<GameObject>();
    public int EggCount;
    public float EggInstantSpeed = 0.5f;
    void Start()
    {
        StartCoroutine(EggInstantEnum());
        for (int i = 0; i < CWheats.Count; i++)
        {
            CWheats[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
        for (int i = 0; i < Eggs.Count; i++)
        {
            Eggs[i] = transform.GetChild(1).GetChild(i).gameObject;
        }
    }
    private void Update()
    {
         
    }
    IEnumerator EggInstantEnum()
    {
        while (true)
        {
            if (CWheatCount > 0 && EggCount < 30)
            {
                CWheats[CWheatCount - 1].SetActive(false);
                CWheatCount -= 1;
                yield return new WaitForSeconds(EggInstantSpeed * 10);
                EggCount += 1;
                Eggs[EggCount - 1].gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(EggInstantSpeed);
        }
    }
}
