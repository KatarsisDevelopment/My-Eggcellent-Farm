using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    public List<GameObject> BPumpkins = new List<GameObject>();
    public int BPumpkinsCount;
    public List<GameObject> Milks = new List<GameObject>();
    public int MilksCount;
    public float MilkInstantSpeed = 0.5f;
    void Start()
    {
        StartCoroutine(EggInstantEnum());
        for (int i = 0; i < BPumpkins.Count; i++)
        {
            BPumpkins[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
        for (int i = 0; i < Milks.Count; i++)
        {
            Milks[i] = transform.GetChild(1).GetChild(i).gameObject;
        }
    }
    IEnumerator EggInstantEnum()
    {
        while (true)
        {
            if (BPumpkinsCount > 0 && MilksCount < 30)
            {
                BPumpkins[BPumpkinsCount - 1].SetActive(false);
                BPumpkinsCount -= 1;
                yield return new WaitForSeconds(MilkInstantSpeed * 10);
                MilksCount += 1;
                Milks[MilksCount - 1].gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(MilkInstantSpeed);
        }
    }
}
