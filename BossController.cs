using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;

public class BossController : MonoBehaviour
{

    public float maxSpeed = 5f;
    public static float bossSpeed = 0.5f;
    public float vidaBoss;
    public static float contadorBoss = 0;
    public SpriteRenderer sr;

    public AudioSource enemigoMuerto;
    public AudioSource enemigoHerido;

    private Animator anim;

    private Rigidbody2D rb2d;

    public static BossController boss;

    public static bool bossDead;

    public float maximaVidaBoss;
    public Image barraVida;

    public GameObject barra;
    public GameObject final;
    public GameObject finalisimo;
    public GameObject grupoMonedas;

    


    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponentInParent<BossController>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bossSpeed = 0.1f;
        contadorBoss = PlayerPrefs.GetFloat("muertosBoss");

        bossDead = false;

        maximaVidaBoss = 150;
        vidaBoss = 150;

                
    }

    // Update is called once per frame
    void Update()
    {

        barraVida.fillAmount = vidaBoss / maximaVidaBoss;

        if (bossSpeed > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (bossDead == false)
            {
                col.SendMessage("EnemyKnockBack", transform.position.x);
            }
        }

        if (col.gameObject.tag == "Attack" && bossDead == false)
        {
            vidaBoss -= GameControl.dañoJugador;
            if (vidaBoss <= 0)
            {
                bossDead = true;
                anim.SetBool("Dead", true);
                sr.color = Color.red;
                BossSearch.bossSpeedFollow = 0;
                bossSpeed = 0f;
                anim.SetFloat("Speed", 0);
                Invoke("quitarBarra", 2f);
                Destroy(gameObject, 2);
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
                GameControl.score += 5;
                PlayerPrefs.SetInt("Monedas", GameControl.score);
                contadorBoss += 1;
                PlayerPrefs.SetFloat("muertosBoss", contadorBoss);
                PlayerPrefs.Save();
                if (PlayerPrefs.GetInt("audio", 0) == 1)
                {
                    enemigoMuerto.Play();
                }
                final.SetActive(false);
                finalisimo.SetActive(true);
                grupoMonedas.SetActive(true);

                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_threat_of_the_gods, 1, (bool success) => {

                });
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_danger_of_the_gods, 1, (bool success) => {

                });
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_killer_of_the_gods, 1, (bool success) => {

                });
                PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_legend_of_the_gods, 1, (bool success) => {

                });

            }

            else
            {
                BossSearch.bossSpeedFollow = 0;
                anim.SetFloat("Speed", 0);
                anim.SetTrigger("Hurt");
                if (PlayerPrefs.GetInt("audio", 0) == 1)
                {
                    enemigoHerido.Play();
                }
                Invoke("reanudar", 1f);
            }
        }
    }

    void reanudar()
    {
        anim.SetFloat("Speed", 1);
        BossSearch.bossSpeedFollow = 0.04f;
    }

    void quitarBarra()
    {
        Destroy(barra);
    }

}
