using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeManager : MonoBehaviour
{
    Animator Animator;
    public Image UprageImage;
    public Player Player;
    public int UprageCost,SpeedCost;
    public TextMeshProUGUI UprageText, SpeedText;
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        UprageCost = PlayerPrefs.GetInt("UprageCost", UprageCost);
        SpeedCost = PlayerPrefs.GetInt("SpeedCost", SpeedCost);
    }
    private void Update()
    {
        if (UprageCost < 1000)
        {
            UprageText.text = "" + UprageCost;
        }
        else
        {
            UprageText.text = "MAX";
        }
        if (SpeedCost < 1000)
        {
            SpeedText.text = "" + SpeedCost;
        }
        else
        {
            SpeedText.text = "MAX";
        }
    }
    public void UpdateSpeed()
    {
        if (SpeedCost < 1000)
        {
            if (Player.MoneyCount > SpeedCost)
            {
                Player.MoneyCount -= UprageCost;
                PlayerPrefs.SetFloat("PMoney", Player.MoneyCount);
                Player.Speed += 0.25f;
                PlayerPrefs.SetFloat("PSpeed", Player.Speed);
                SpeedCost *= 2;
                PlayerPrefs.SetInt("SpeedCost", SpeedCost);
            }
        }
        else
        {
            UprageText.text = "MAX";
        }
    }
    public void UpdateCapacity()
    {
        if (UprageCost < 1000)
        {
            if (Player.MoneyCount > UprageCost)
            {
                Player.MoneyCount -= UprageCost;
                PlayerPrefs.SetFloat("PMoney", Player.MoneyCount);
                Player.MaxWheatCount *= 2;
                PlayerPrefs.SetInt("PWheat", Player.MaxWheatCount);
                UprageCost *= 2;
                PlayerPrefs.SetInt("UprageCost", UprageCost);
            }
        }
        else
        {
            UprageText.text = "MAX";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Animator.SetBool("IsInPlayer", true);
            UprageImage.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Animator.SetBool("IsInPlayer", false);
            UprageImage.gameObject.SetActive(false);
        }
    }
}
