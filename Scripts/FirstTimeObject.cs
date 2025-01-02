using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FirstTimeObject : MonoBehaviour
{
    public GameObject firstTimeObject,Arrow;
    public TextMeshProUGUI InfoText;
    public Transform Field, Coop;
    bool IsInWheat = false;
    void Start()
    {
        if (PlayerPrefs.HasKey("FirstTime"))
        {
            // Daha önce oyuna girilmiþ, objeyi devre dýþý býrak.
            firstTimeObject.SetActive(false);
            Arrow.SetActive(false);
        }
        else
        {
            // Ýlk defa oyuna giriliyor, objeyi etkinleþtir ve FirstTime anahtarýný kaydet.
            firstTimeObject.SetActive(true);
            Arrow.SetActive(true);
            PlayerPrefs.SetInt("FirstTime", 1);
            PlayerPrefs.Save();
        }
    }
    private void Update()
    {
        if (!IsInWheat)
        {
            Arrow.gameObject.transform.LookAt(Field.position);
        }
        else
        {
            Arrow.gameObject.transform.LookAt(Coop.position);
            Invoke("Activer", 10f);
        }
    }
    void Activer()
    {
        Arrow.SetActive(false);
    }
    public void NextButton()
    {
        InfoText.text = "Now , Just Enjoy !";
    }
    public void CloseButton()
    {
        firstTimeObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wheat"))
        {
            IsInWheat = true;
        }
    }
}
