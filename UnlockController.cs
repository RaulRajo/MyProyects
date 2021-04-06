using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockController : MonoBehaviour
{
    public GameObject botonBate;
    public GameObject imagenBate;
    public Button unlockBate;

    public GameObject botonMarron;
    public GameObject imagenMarron;
    public Button unlockMarron;

    public GameObject botonVerde;
    public GameObject imagenVerde;
    public Button unlockVerde;

    public GameObject botonAzul;
    public GameObject imagenAzul;
    public Button unlockAzul;

    public GameObject botonGris;
    public GameObject imagenGris;
    public Button unlockGris;

    public GameObject botonPelo;
    public GameObject imagenPelo;
    public Button unlockPelo;

    public GameObject botonRojo;
    public GameObject imagenRojo;
    public Button unlockRojo;

    // Start is called before the first frame update
    void Start()
    {
        GameControl.score = PlayerPrefs.GetInt("Monedas");
    }

    // Update is called once per frame
    void Update()
    {

        //PlayerPrefs.SetInt("bateDesbloqueado", 0);
        //PlayerPrefs.SetInt("marronDesbloqueado", 0);
        //PlayerPrefs.SetInt("verdeDesbloqueado", 0);
        //PlayerPrefs.SetInt("azulDesbloqueado", 0);
        //PlayerPrefs.SetInt("grisDesbloqueado", 0);
        //PlayerPrefs.SetInt("peloDesbloqueado", 0);
        //PlayerPrefs.SetInt("rojoDesbloqueado", 0);

        //PlayerPrefs.SetInt("bossMatado", 0);
        if (PlayerPrefs.GetInt("bossMatado") == 1)
        {
            PlayerPrefs.SetInt("grisDesbloqueado", 1);
        }


        if (PlayerPrefs.GetInt("bateDesbloqueado") == 1)
        {
            botonBate.SetActive(false);
            imagenBate.SetActive(false);
        }


        if (PlayerPrefs.GetInt("marronDesbloqueado") == 1)
        {
            botonMarron.SetActive(false);
            imagenMarron.SetActive(false);
        }

        if (PlayerPrefs.GetInt("verdeDesbloqueado") == 1)
        {
            botonVerde.SetActive(false);
            imagenVerde.SetActive(false);
        }

        if (PlayerPrefs.GetInt("azulDesbloqueado") == 1)
        {
            botonAzul.SetActive(false);
            imagenAzul.SetActive(false);
        }

        if (PlayerPrefs.GetInt("grisDesbloqueado") == 1)
        {
            botonGris.SetActive(false);
            imagenGris.SetActive(false);
        }

        if (PlayerPrefs.GetInt("peloDesbloqueado") == 1)
        {
            botonPelo.SetActive(false);
            imagenPelo.SetActive(false);
        }

        if (PlayerPrefs.GetInt("rojoDesbloqueado") == 1)
        {
            botonRojo.SetActive(false);
            imagenRojo.SetActive(false);
        }


        PlayerPrefs.GetInt("bateDesbloqueado");
        PlayerPrefs.GetInt("marronDesbloqueado");
        PlayerPrefs.GetInt("verdeDesbloqueado");
        PlayerPrefs.GetInt("azulDesbloqueado");
        PlayerPrefs.GetInt("grisDesbloqueado");
        PlayerPrefs.GetInt("peloDesbloqueado");
        PlayerPrefs.GetInt("rojoDesbloqueado");


        if (PlayerPrefs.GetInt("Monedas") >= 25)
        {
            unlockBate.interactable = true;
            
        } else
        {
            unlockBate.interactable = false;
        }

        if (PlayerPrefs.GetInt("Monedas") >= 100)
        {
            unlockMarron.interactable = true;
            
        } else
        {
            unlockMarron.interactable = false;
        }

        if (PlayerPrefs.GetInt("Monedas") >= 200)
        {
            unlockVerde.interactable = true;
            
        } else
        {
            unlockVerde.interactable = false;
        }

        if (PlayerPrefs.GetInt("Monedas") >= 400)
        {
            unlockAzul.interactable = true;
            
        } else
        {
            unlockAzul.interactable = false;
        }

        //if (PlayerPrefs.GetInt("Monedas") >= 400)
        //{
        //    unlockGris.interactable = true;
            
        //} else
        //{
        //    unlockGris.interactable = false;
        //}

        if (PlayerPrefs.GetInt("Monedas") >= 1600)
        {
            unlockPelo.interactable = true;
            
        } else
        {
            unlockPelo.interactable = false;
        }

        if (PlayerPrefs.GetInt("Monedas") >= 3200)
        {
            unlockRojo.interactable = true;
            
        } else
        {
            unlockRojo.interactable = false;
        }

        if (PlayerPrefs.GetInt("marronDesbloqueado") == 1 && PlayerPrefs.GetInt("verdeDesbloqueado") == 1 && PlayerPrefs.GetInt("azulDesbloqueado") == 1 && PlayerPrefs.GetInt("grisDesbloqueado") == 1 && (PlayerPrefs.GetInt("peloDesbloqueado") == 1 && PlayerPrefs.GetInt("rojoDesbloqueado") == 1))
        {
            Social.ReportProgress(GPGSIds.achievement_gods_master, 100f, null);
        }
    }

    public void desbloquearBate()
    {
        GameControl.score -= 25;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("bateDesbloqueado", 1);
    }

    public void desbloquearMarron()
    {
        GameControl.score -= 100;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("marronDesbloqueado", 1);
    }

    public void desbloquearVerde()
    {
        GameControl.score -= 200;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("verdeDesbloqueado", 1);
    }

    public void desbloquearAzul()
    {
        GameControl.score -= 400;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("azulDesbloqueado", 1);
    }

    public void desbloquearGris()
    {
        GameControl.score -= 800;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("grisDesbloqueado", 1);
    }

    public void desbloquearPelo()
    {
        GameControl.score -= 1600;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("peloDesbloqueado", 1);
    }

    public void desbloquearRojo()
    {
        GameControl.score -= 3200;
        PlayerPrefs.SetInt("Monedas", GameControl.score);
        PlayerPrefs.SetInt("rojoDesbloqueado", 1);
        Social.ReportProgress(GPGSIds.achievement_susanoo, 100f, null);
    }
}
