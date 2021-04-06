using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class Timer : MonoBehaviour
{
    private float StartTime;
    private float mejor;
    public static float TimerControl;
    public static string TimerString;

    public Text tiempoMarcadorMuerte;

    public int minutosAñadir;
    public int segundosAñadir;
    public int totalAñadir;
    bool recorded = false;

    bool logro1;
    bool logro2;
    bool logro3;

    void Start()
    {
        StartTime = Time.time;
        mejor = PlayerPrefs.GetFloat("tiempo");
        //PlayerPrefs.SetFloat("tiempo", 0);
        //PlayerPrefs.SetString("tiempoString", "0");
        recorded = false;

    }
    void Update()
    {
        if (PlayerController.dead == false)
        {
            TimerControl = Time.time - StartTime;
            string mins = ((int)TimerControl / 60).ToString("00");
            string segs = ((int)TimerControl % 60).ToString("00");
            string milisegs = ((TimerControl * 100) % 100).ToString("00");

            TimerString = string.Format("{00}:{01}:{02}", mins, segs, milisegs);

            GetComponent<Text>().text = TimerString;

            //GetComponent<Text>().text = ((int)TimerControl).ToString();

            tiempoMarcadorMuerte.text = TimerString;

            //GameControl.score = ((int)TimerControl % 60);
            //PlayerPrefs.SetInt("Monedas", GameControl.score);

            if (TimerControl >= 60 && !logro1)
            {
                Social.ReportProgress(GPGSIds.achievement_rookie_survivor, 100f, null);
                logro1 = true;
            }

            if (TimerControl >= 180 && !logro2)
            {
                Social.ReportProgress(GPGSIds.achievement_expert_survivor, 100f, null);
                logro2 = true;
            }

            if (TimerControl >= 300 && !logro3)
            {
                Social.ReportProgress(GPGSIds.achievement_master_survivor, 100f, null);
                logro3 = true;
            }
        }

        if (PlayerController.dead == true && !recorded)
        {
            if (TimerControl > mejor)
            {
                mejor = TimerControl;
                PlayerPrefs.SetString("tiempoString", TimerString);
                Social.ReportScore((long)(TimerControl * 1000), GPGSIds.leaderboard_survival_best_time, (bool success) => {

                });
            }
            PlayerPrefs.SetFloat("tiempo", mejor);

            //minutosAñadir = ((int)TimerControl / 60) * 60;
            //segundosAñadir = ((int)TimerControl % 60);
            //totalAñadir = minutosAñadir + segundosAñadir;
            //segundosAñadir = (int)(TimerControl);
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_legend_survivor, (int)TimerControl, (bool success) =>
            {

            });
            recorded = true;
        }
    }
}