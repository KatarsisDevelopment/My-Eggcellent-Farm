using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public List<GameObject> ObjectList = new List<GameObject>();
    int ObjectCount = -1;
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            ObjectList[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjectList[ObjectCount + 1].gameObject.SetActive(true);
            ObjectCount += 1;
        }
    }
}
