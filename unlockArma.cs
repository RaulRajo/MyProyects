using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockArma : MonoBehaviour
{

    public GameObject botonArma2;
    public GameObject imagenArma2;
    public Button unlockArma2;

    public GameObject botonArma3;
    public GameObject imagenArma3;
    public Button unlockArma3;

    public GameObject botonArma4;
    public GameObject imagenArma4;
    public Button unlockArma4;

    public GameObject botonArma5;
    public GameObject imagenArma5;
    public Button unlockArma5;

    public GameObject botonArma6;
    public GameObject imagenArma6;
    public Button unlockArma6;

    public GameObject listillos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.SetInt("arma2Desbloqueado", 0);
        //PlayerPrefs.SetInt("arma3Desbloqueado", 0);
        //PlayerPrefs.SetInt("arma4Desbloqueado", 0);
        //PlayerPrefs.SetInt("arma5Desbloqueado", 0);
        //PlayerPrefs.SetInt("arma6Desbloqueado", 0);


        if (PlayerPrefs.GetInt("arma2Desbloqueado") == 1)
        {
            botonArma2.SetActive(false);
            imagenArma2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("arma3Desbloqueado") == 1)
        {
            botonArma3.SetActive(false);
            imagenArma3.SetActive(false);
        }

        if (PlayerPrefs.GetInt("arma4Desbloqueado") == 1)
        {
            botonArma4.SetActive(false);
            imagenArma4.SetActive(false);
        }

        if (PlayerPrefs.GetInt("arma5Desbloqueado") == 1)
        {
            botonArma5.SetActive(false);
            imagenArma5.SetActive(false);
        }

        if (PlayerPrefs.GetInt("arma6Desbloqueado") == 1)
        {
            botonArma6.SetActive(false);
            imagenArma6.SetActive(false);
        }


        PlayerPrefs.GetInt("arma2Desbloqueado");
        PlayerPrefs.GetInt("arma3Desbloqueado");
        PlayerPrefs.GetInt("arma4Desbloqueado");
        PlayerPrefs.GetInt("arma5Desbloqueado");
        PlayerPrefs.GetInt("arma6Desbloqueado");


        if (PlayerPrefs.GetFloat("seleccionPersonaje") <= 2)
        {
            listillos.SetActive(true);
        }
        else
        {
            listillos.SetActive(false);
        }



        if (PlayerPrefs.GetInt("Monedas") >= 200)
        {
            unlockArma2.interactable = true;

        }
        else
        {
            unlockArma2.interactable = false;
        }


        if (PlayerPrefs.GetInt("Monedas") >= 400)
        {
            unlockArma3.interactable = true;

        }
        else
        {
            unlockArma3.interactable = false;
        }


        if (PlayerPrefs.GetInt("Monedas") >= 800)
        {
            unlockArma4.interactable = true;

        }
        else
        {
            unlockArma4.interactable = false;
        }


        if (PlayerPrefs.GetInt("Monedas") >= 1600)
        {
            unlockArma5.interactable = true;

        }
        else
        {
            unlockArma5.interactable = false;
        }


        if (PlayerPrefs.GetInt("Monedas") >= 3200)
        {
            unlockArma6.interactable = true;

        }
        else
        {
            unlockArma6.interactable = false;
        }


        if (PlayerPrefs.GetInt("arma2Desbloqueado") == 1 && PlayerPrefs.GetInt("arma3Desbloqueado") == 1 && PlayerPrefs.GetInt("arma4Desbloqueado") == 1 && PlayerPrefs.GetInt("arma5Desbloqueado") == 1 && PlayerPrefs.GetInt("arma6Desbloqueado") == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_weapons_master, 100f, null);
        }
    }

    public void desbloquearArma2()
    {
        GameControl.score -= 200;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("arma2Desbloqueado", 1);
    }

    public void desbloquearArma3()
    {
        GameControl.score -= 400;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("arma3Desbloqueado", 1);
    }

    public void desbloquearArma4()
    {
        GameControl.score -= 800;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("arma4Desbloqueado", 1);
    }

    public void desbloquearArma5()
    {
        GameControl.score -= 1600;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("arma5Desbloqueado", 1);
    }

    public void desbloquearArma6()
    {
        GameControl.score -= 3200;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("arma6Desbloqueado", 1);
        Social.ReportProgress(GPGSIds.achievement_excalibur, 100f, null);
    }
}    
