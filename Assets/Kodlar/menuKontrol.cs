using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuKontrol : MonoBehaviour
{

    public void ilerlemeyi_sifirla()
    {
        PlayerPrefs.DeleteAll();
    }

    public void restartButton()
    {
        SceneManager.LoadScene("anaMenu");
    }
    
    public void oyunaGit()
    {
        int kayitliLevel = PlayerPrefs.GetInt("kayit");

        if (kayitliLevel==0)
        {
            SceneManager.LoadScene(kayitliLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(kayitliLevel);

        }

    }

    public void cik()
    {
        Application.Quit();
    }
   

}
