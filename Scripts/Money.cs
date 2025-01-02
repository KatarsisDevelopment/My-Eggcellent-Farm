using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public Seller seller;
    public BarnSeller BarnSeller;
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnDisable()
    {
        if (seller == null)
        {
            seller.MoneyCount -= 1;
        }
        else
        {
            BarnSeller.MoneyCount -= 1;
        }
        player.MoneyCount += 1;
        PlayerPrefs.SetFloat("PMoney", player.MoneyCount);
    }
}
