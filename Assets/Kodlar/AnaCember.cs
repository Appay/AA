using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaCember : MonoBehaviour
{
    public GameObject kucukCember;
    GameObject OyunYönetici;
    void Start()
    {
        OyunYönetici = GameObject.FindGameObjectWithTag("OyunYoneticisiTag");

    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            kucukCemberOlustur();
        }
    }
    void kucukCemberOlustur()
    {
        Instantiate(kucukCember, transform.position, transform.rotation);
        OyunYönetici.GetComponent<OyunYoneticisi>().KucukCemberText();


    }
}
