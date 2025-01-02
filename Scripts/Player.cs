using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    FixedJoystick FixedJoystick;
    Animator Animator;
    public float Speed;
    public List<GameObject> PWheats = new List<GameObject>();
    public int WheatCount,MaxWheatCount;
    public List<GameObject> PPumpkin = new List<GameObject>();
    public int PumpkinCount, MaxPumpkinCount;
    public List<GameObject> Eggs = new List<GameObject>();
    public List<GameObject> PMilks = new List<GameObject>();
    public int PEggCount,PMilkCount;
    GameObject EggBox;
    public GameObject Sickle,MaxWheatImage;
    public float MoneyCount;
    public TextMeshProUGUI EggCountText,WheatCountText,MoneyCountText;
    
    void Start()
    {
        EggBox = transform.GetChild(3).gameObject;
        FixedJoystick = FindObjectOfType<FixedJoystick>();
        Animator = GetComponent<Animator>();
        StartCoroutine(WheatGiveEnum());
        StartCoroutine(EggTakeEnum());
        StartCoroutine(SellEnum());
        MoneyCount = PlayerPrefs.GetFloat("PMoney", MoneyCount);
        MaxWheatCount = PlayerPrefs.GetInt("PWheat", MaxWheatCount);
        MaxPumpkinCount = PlayerPrefs.GetInt("PWheat", MaxWheatCount);
        Speed = PlayerPrefs.GetFloat("PSpeed", Speed);
        for (int i = 0; i < 9; i++)
        {
            PWheats[i] = transform.GetChild(0).GetChild(i).gameObject;
        }
        for (int i = 0; i < 30; i++)
        {
            Eggs[i] = transform.GetChild(1).GetChild(i).gameObject;
        }
        for (int i = 0; i < 9; i++)
        {
            PPumpkin[i] = transform.GetChild(2).GetChild(i).gameObject;
        }
        for (int i = 0; i < PMilks.Count; i++)
        {
            PMilks[i] = transform.GetChild(4).GetChild(i).gameObject;
        }
    }
    void Update()
    {
        EggCountText.text = PEggCount + "";
        WheatCountText.text = WheatCount + "";
        MoneyCountText.text = MoneyCount + "";
        transform.position += new Vector3(FixedJoystick.Horizontal, 0, FixedJoystick.Vertical) * Speed * Time.deltaTime;
        Camera.main.transform.position = transform.position + new Vector3(-6,9,-6);
        if (FixedJoystick.Horizontal != 0 && FixedJoystick.Vertical != 0)
        {
            Animator.SetFloat("Speed", 1f);
            transform.forward = new Vector3(FixedJoystick.Horizontal, 0, FixedJoystick.Vertical);
        }
        else
        {
            Animator.SetFloat("Speed", 0f);
        }
        if (PEggCount > 0 || PMilkCount > 0)
        {
            Animator.SetBool("Carrying", true);
            EggBox.gameObject.SetActive(true);
        }
        else
        {
            Animator.SetBool("Carrying", false);
            EggBox.gameObject.SetActive(false);
        }
        if (WheatCount == MaxWheatCount || PumpkinCount == MaxPumpkinCount)
        {
            MaxWheatImage.SetActive(true);
        }
        else
        {
            MaxWheatImage.SetActive(false);
        }
    }
    public void TakeWheat()
    {
        if (WheatCount < MaxWheatCount)
        {
            Animator.SetTrigger("Harvesting");
            WheatCount += 1;
            PWheats[WheatCount - 1].SetActive(true);
        }
    }
    public void TakePumpkin()
    {
        if (PumpkinCount < MaxPumpkinCount)
        {
            Animator.SetTrigger("Harvesting");
            PumpkinCount += 1;
            PPumpkin[PumpkinCount - 1].SetActive(true);
        }
    }
    IEnumerator EggTakeEnum()
    {
        while (true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
            {
                Coop coop = hit.collider.gameObject.GetComponent<Coop>();
                if (coop && coop.EggCount > 0)
                {
                    PEggCount += 1;
                    Eggs[PEggCount - 1].SetActive(true);
                    coop.Eggs[coop.EggCount - 1].SetActive(false);
                    coop.EggCount -= 1;
                }
            }
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
            {
                Barn barn = hit.collider.gameObject.GetComponent<Barn>();
                if (barn && barn.MilksCount > 0)
                {
                    PMilkCount += 1;
                    PMilks[PMilkCount - 1].SetActive(true);
                    barn.Milks[barn.MilksCount - 1].SetActive(false);
                    barn.MilksCount -= 1;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator WheatGiveEnum()
    {
        while (true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,transform.forward,out hit,1f))
            {
                Coop coop = hit.collider.gameObject.GetComponent<Coop>();
                if (coop && coop.CWheatCount < 9)
                {
                    if (WheatCount > 0)
                    {
                        PWheats[WheatCount - 1].gameObject.SetActive(false);
                        WheatCount -= 1;
                        coop.CWheatCount += 1;
                        coop.CWheats[coop.CWheatCount - 1].gameObject.SetActive(true);

                    }
                }
                Barn barn = hit.collider.gameObject.GetComponent<Barn>();
                if (barn && barn.BPumpkinsCount < 9)
                {
                    if (PumpkinCount > 0)
                    {
                        PPumpkin[PumpkinCount - 1].gameObject.SetActive(false);
                        PumpkinCount -= 1;
                        barn.BPumpkinsCount += 1;
                        barn.BPumpkins[barn.BPumpkinsCount - 1].gameObject.SetActive(true);

                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator SellEnum()
    {
        while (true)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
            {
                Seller seller = hit.collider.gameObject.GetComponent<Seller>();
                if (seller && PEggCount > 0)
                {
                    Eggs[PEggCount - 1].gameObject.SetActive(false);
                    PEggCount -= 1;
                    seller.SEggCount += 1;
                    seller.SEggList[seller.SEggCount - 1].gameObject.SetActive(true);
                }
            }
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
            {
                BarnSeller BarnSeller = hit.collider.gameObject.GetComponent<BarnSeller>();
                if (BarnSeller && PMilkCount > 0)
                {
            
                    PMilks[PMilkCount - 1].gameObject.SetActive(false);
                    PMilkCount -= 1;
                    BarnSeller.SEggCount += 1;
                    BarnSeller.SEggList[BarnSeller.SEggCount - 1].gameObject.SetActive(true);
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wheat"))
        {
            if (WheatCount < MaxWheatCount)
            {
                other.gameObject.GetComponent<Wheat>().Collected = true;
                TakeWheat();
            }
        }
        if (other.gameObject.CompareTag("Pumpkin"))
        {
            if (PumpkinCount < MaxPumpkinCount)
            {
                other.gameObject.GetComponent<Wheat>().Collected = true;
                TakePumpkin();
            }
        }
        if (other.gameObject.CompareTag("Money"))
        {
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BuyArea") && MoneyCount > 0)
        {
          BuyManager buyManager =  other.gameObject.GetComponent<BuyManager>();
            if (buyManager.CurentCost >= 0)
            {
                buyManager.CurentCost -= 1;
                PlayerPrefs.SetFloat(buyManager.PrefsName, buyManager.CurentCost);
                MoneyCount -= 1;
                PlayerPrefs.SetFloat("PMoney", MoneyCount);
            }
        }
    }

}
