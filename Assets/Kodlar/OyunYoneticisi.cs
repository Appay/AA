using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OyunYoneticisi : MonoBehaviour
{

    GameObject donenCember;
    GameObject AnaCember;
    public Animator animator;
    public Text DonenCemberLevel;
    public Text Bir; 
    public Text iki;
    public Text Uc;
    public int kacTaneKucukCemberOlsun;
    bool kontrol = true;



    void Start()
    {
        PlayerPrefs.SetInt("kayit",int.Parse(SceneManager.GetActiveScene().name));

        
        donenCember = GameObject.FindGameObjectWithTag("donencemberTag");
        AnaCember = GameObject.FindGameObjectWithTag("AnaCemberTag");
        DonenCemberLevel.text = SceneManager.GetActiveScene().name;

        if (kacTaneKucukCemberOlsun < 2)
        {
            Bir.text = kacTaneKucukCemberOlsun+""; // stringe çevirmek için +"" yapıldı
        }
        else if (kacTaneKucukCemberOlsun < 3)
        {
            Bir.text = kacTaneKucukCemberOlsun + ""; 
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
        }
        else
        {
            Bir.text = kacTaneKucukCemberOlsun + ""; 
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            Uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }
        
    }
    public void KucukCemberText()
    {
        kacTaneKucukCemberOlsun--;
        if (kacTaneKucukCemberOlsun < 2)
        {
            Bir.text = kacTaneKucukCemberOlsun + ""; // stringe çevirmek için +"" yapıldı
            iki.text = "";
            Uc.text = "";

        }
        else if (kacTaneKucukCemberOlsun < 3)
        {
            Bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            Uc.text = "";
        }
        else
        {
            Bir.text = kacTaneKucukCemberOlsun + "";
            iki.text = (kacTaneKucukCemberOlsun - 1) + "";
            Uc.text = (kacTaneKucukCemberOlsun - 2) + "";
        }

        if (kacTaneKucukCemberOlsun==0)
        {
            StartCoroutine(yeniLevel());
        }

    }
     IEnumerator yeniLevel()
     {
        donenCember.GetComponent<Dondurme>().enabled = false;
        AnaCember.GetComponent<AnaCember>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        if (kontrol)
        {
            animator.SetTrigger("yenilevel"); // yeni level geçiş aniamsyonu
            yield return new WaitForSeconds(1.4f);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
            //name bir string olduğu için onu int'e çevirdik toplama hatalı olmasın
        }
       
     }


    public void oyunBitti()
    {
        StartCoroutine(CagirilanMetot());
    }

    IEnumerator CagirilanMetot()
    {
        donenCember.GetComponent<Dondurme>().enabled = false; 
        AnaCember.GetComponent<AnaCember>().enabled = false;
        animator.SetTrigger("oyunbitti");
        kontrol = false;
        yield return new WaitForSeconds(1); //1 sn bekletiliyor
        

        SceneManager.LoadScene("anaMenu");
    }
}
