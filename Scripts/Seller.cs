using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public List<GameObject> SEggList = new List<GameObject>();
    public int SEggCount;
    public List<GameObject> MoneyList = new List<GameObject>();
    public int MoneyCount;
    public float WorkerCount = 1f;
    bool IsOver = false;
    void Start()
    {
        for (int i = 0; i < 120; i++)
        {
            SEggList[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
        for (int i = 0; i < MoneyList.Count; i++)
        {
            MoneyList[i] = transform.GetChild(1).GetChild(i).gameObject;
        }

    }
    void Repeater()
    {
        IsOver = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            WayPointManager wayPointManager = other.gameObject.GetComponent<WayPointManager>();
            if (wayPointManager && wayPointManager.NpcOrderCount > 0 && SEggCount > 0)
            {
                SEggList[SEggCount - 1].gameObject.SetActive(false);
                SEggCount -= 1;
                wayPointManager.NpcOrderCount -= 1;
                MoneyCount += 1;
                MoneyList[MoneyCount - 1].gameObject.SetActive(true);
            }
            if (wayPointManager.NpcOrderCount <= 0)
            {
                if (!IsOver)
                {
                    WayPointManager[] wayPointManagers = FindObjectsOfType<WayPointManager>();
                    foreach (WayPointManager obj in wayPointManagers)
                    {
                        obj.GetComponent<WayPointManager>().CurrentPoint += 1;
                        other.gameObject.GetComponent<WayPointManager>().CurrentPoint = 0;
                        IsOver = true;
                        other.gameObject.transform.localPosition = other.gameObject.transform.localPosition - new Vector3(0, 0, 3F ) * Time.deltaTime;

                        Invoke("Repeater", 2f);
                    }
                }
               
            }
        }
    }

}
