using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuyManager : MonoBehaviour
{
    public float Cost,CurentCost;
    public TextMeshProUGUI CostText;
    public Image F�llImage;
    public string PrefsName;
    public GameObject PurchasedObject;
    Canvas Canvas;
    void Start()
    {
        Canvas = transform.GetChild(0).GetComponent<Canvas>();
        CurentCost = PlayerPrefs.GetFloat(PrefsName, CurentCost);
    }
    void Update()
    {
        F�llImage.fillAmount = CurentCost / Cost;
        CostText.text = CurentCost.ToString("F0") + "";
        if (CurentCost <= 0)
        {
            PurchasedObject.SetActive(true);
            Canvas.gameObject.SetActive(false);
        }
    }
}
