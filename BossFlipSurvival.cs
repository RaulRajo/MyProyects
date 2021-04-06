using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlipSurvival : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;
    public GameObject posiPlayer;
    private Vector3 posicion;

    public bool bossDerecha;
    public static float posicionBoss;
    public static float posicionPlayer;
    public static float posicionPause;

    public static float posicionAtaque;

    private Animator anim;


    void Start()
    {
        boss = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("Speed", 0);
        posiPlayer = GameObject.FindGameObjectWithTag("Player");
        posicionAtaque = 1;
    }


    void Update()
    {
        posicionBoss = boss.transform.position.x;
        posicionPlayer = player.transform.position.x;
        posicionPause = posiPlayer.transform.position.x;


        if (posicionBoss - posicionPlayer <= posicionAtaque && posicionBoss - posicionPlayer >= -posicionAtaque && PlayerController.vida > 0 && PlayerController.dead == false)
        {
            anim.SetBool("Attack", true);
            BossSearch.bossSpeedFollow = 0;
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetFloat("Speed", 0);
            BossSearch.bossSpeedFollow = 0.03f;
        }

        Vector3 nuevaX = new Vector3(player.transform.position.x, 0.62f, 0);
        Vector3 bossX = new Vector3(boss.transform.position.x, 0, 0);

        if (PlayerController.dead == false)
        {
            if (posicionBoss > posicionPlayer)
            {
                mirarIzquierdaSurvival();
            }
            else
            {
                mirarDerechaSurvival();
            }

            anim.SetFloat("Speed", 1);
            transform.position = Vector2.MoveTowards(transform.position, nuevaX, BossSearch.bossSpeedFollow);
        }

        if (Time.timeScale == 1)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        } else
        {
            player = boss;
            if (posicionPause > posicionBoss)
            {
                mirarDerechaSurvival();
            } else
            {
                mirarIzquierdaSurvival();
            }
        }
    }

    void mirarDerechaSurvival()
    {
        if (bossDerecha == false)
        {
            bossDerecha = true;
            Vector3 theScale = boss.transform.localScale;
            theScale.x *= -1;
            boss.transform.localScale = theScale;
        }
    }

    void mirarIzquierdaSurvival()
    {
        if (bossDerecha == true)
        {
            bossDerecha = false;
            Vector3 theScale = boss.transform.localScale;
            theScale.x *= -1;
            boss.transform.localScale = theScale;
        }
    }
}
