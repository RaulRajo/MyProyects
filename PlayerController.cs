using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance2;
	public static float speed = 5f;
    public static float vida = 3;
    public static float nivel = 0;
    public GameObject jugador;
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;
    public static bool facingRight = true;
	public static Animator anim;
    public static SpriteRenderer spr;
    private bool movement = true;
	public static bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
    public static CircleCollider2D attackCollider;
    public AudioSource reciboDaño;
    public AudioSource ataco;
    public AudioSource muerte;
    public AudioSource saltar;
    public AudioSource UI;
    public AudioSource pocion;
    public AudioSource juegoGanado;
    public AudioSource juegoVivo;
    public AudioSource juegoMuerto;
    public AudioSource enemigoMuerto;
    public AudioSource enemigoHerido;
    public AudioSource gameOver;
    public AudioSource latido;

    public GameObject win;
    public GameObject noti;
    public Button settings;

    public static PlayerController player;

    public static int contadorMuertes;


    //variable for how high player jumps//
    [SerializeField]
	public float jumpForce;

	public static Rigidbody2D rb { get; set; }

    public static bool jump = false;
	public static bool dead = false;
	public static bool attack = false;

    void Start () {

        //If we don't currently have a game control...
        if (instance2 == null)
            //...set this one to be it...
            instance2 = this;
        //...otherwise...
        else if (instance2 != this)
            Destroy(gameObject);
        //...destroy this one because it is a duplicate.

        player = GetComponentInParent<PlayerController>();
        GetComponent<Rigidbody2D> ().freezeRotation = true;
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator> ();
        attackCollider = transform.GetChild(1).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
        speed = 5;
        vida = 3;
        dead = false;
        facingRight = true;
        nivel = PlayerPrefs.GetFloat("nivel");

        //nivel = 0;
        //PlayerPrefs.SetFloat("nivel", nivel);

        Time.timeScale = 1;
        contadorMuertes = PlayerPrefs.GetInt("contadorMuertes");
    }

	void Update()
	{
        HandleInput();
    }

	//movement//
	void FixedUpdate ()
	{

        if (PlayerPrefs.GetInt("audio", 0) == 0)
        {
            UI.Stop();
            pocion.Stop();
            juegoVivo.Stop();
            juegoMuerto.Stop();
            juegoGanado.Stop();
            gameOver.Stop();
            latido.Stop();
        }

        grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		float horizontal = Input.GetAxis("Horizontal");
        if (!movement) horizontal = 0;
		if (!dead && !attack)
		{
			anim.SetFloat ("vSpeed", rb.velocity.y);
			anim.SetFloat ("Speed", Mathf.Abs (horizontal));
			rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
		}
		if (horizontal > 0 && !facingRight && !dead && !attack) {
			Flip (horizontal);
		}

		else if (horizontal < 0 && facingRight && !dead && !attack){
			Flip (horizontal);
		}

        if (vida > 1)
        {
            latido.Stop();
        }

        if (dead == true)
        {
            corazon1.SetActive(false);
            corazon2.SetActive(false);
            corazon3.SetActive(false);
        }

    }

	//attacking and jumping//
	private void HandleInput()
	{

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attack = stateInfo.IsName("Attack");

        if (Input.GetKeyDown(KeyCode.A) && !dead && grounded)
        {
            
        }


        if (Input.GetKeyDown(KeyCode.Space) && !dead && grounded)
        {
            attack = true;
            anim.SetBool("Attack", true);
            anim.SetFloat("Speed", 0);
            speed = 0f;
            Invoke("ParoAtaque", 0.6f);

            if (PlayerPrefs.GetInt("audio", 0) == 1)
            { 
                ataco.Play();
            }
        }

		//if (Input.GetKeyUp(KeyCode.Space))
			//{
			//attack = false;
			//anim.SetBool ("Attack", false);
            //attackCollider.enabled = false;
            //speed = 5f;
        //}

		if (grounded && Input.GetKeyDown(KeyCode.W) && !dead)
		{
			anim.SetBool ("Ground", false);

            if (PlayerPrefs.GetInt("audio", 0) == 1)
            {
                saltar.Play();
            }

            jump = true;
        }

		//dead animation for testing//
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			if (!dead) {
				anim.SetBool ("Dead", true);
				anim.SetFloat ("Speed", 0);
				dead = true;
			} else {
					anim.SetBool ("Dead", false);
					dead = false;
				}
		}

        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce);
            jump = false;
        }
	}
		
	public void Flip (float horizontal)
	{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}

    public void Fliped()
    {
        Vector3 theScale = player.transform.localScale;
        theScale.x *= -1;
        player.transform.localScale = theScale;
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        if (vida > 1)
        {
            anim.SetBool("Hurt", true);

            if (PlayerPrefs.GetInt("audio", 0) == 1)
            {
                reciboDaño.Play();
            }

            //jump = true;

            float side = Mathf.Sign(enemyPosX - transform.position.x);
            rb.AddForce(Vector2.left * 1000 * side);
            rb.AddForce(Vector2.up * 250);
            speed = 0f;
            movement = false;
            Invoke("EnableMovement", 0.3f);
            //spr.color = Color.red;
            vida -= 1;

            if (vida < 3 && vida > 1)
            {
                corazon3.SetActive(false);
            }
            else if (vida == 1)
            {
                corazon2.SetActive(false);
                latido.Play();
                juegoVivo.volume = 0.5f;
            }
        }
        else
        {
            speed = 0;
            anim.SetBool("Dead", true);
            anim.SetFloat("Speed", 0);
            //spr.color = Color.red;
            corazon1.SetActive(false);
            dead = true;
            GameControl.instance.PlayerDied();
            //EnemyController.speed = 0f;
            latido.Stop();
            juegoVivo.volume = 0;
            //Destroy(gameObject, 1);
            Invoke("StopPlayer", 2);
            if (PlayerPrefs.GetInt("audio", 0) == 1)
            {
                muerte.Play();
                juegoMuerto.Play();
            }
            settings.interactable = false;
            //gameOver.Play();   
            contadorMuertes += 1;
            PlayerPrefs.SetInt("contadorMuertes", contadorMuertes);
        }
    }

    public void StopPlayer()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }


    public void PlayerWin()
    {
        if (PlayerPrefs.GetInt("audio", 0) == 1)
        {
            juegoGanado.Play();
            latido.Stop();
            juegoVivo.volume = 0f;
            //Destroy(gameObject);
        }

        speed = 0;
        EnemyController.speed = 0;
        jugador.SetActive(false);
        settings.interactable = false;
    }

    void EnableMovement()
    {
        movement = true;
        //spr.color = Color.white;
        anim.SetBool("Hurt", false);
        speed = 5;
    }

    void ParoAtaque()
    {
        attack = false;
        anim.SetBool("Attack", false);
        attackCollider.enabled = false;
        speed = 5f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstaculo")
        {
            grounded = false;
        }

        if (col.gameObject.tag == "Pocion")
        {
            juegoVivo.volume = 1;
        }

        if (col.gameObject.tag == "Coin")
        {
            noti.SetActive(true);
        }

        if (col.gameObject.tag == "Vacio")
        {
            speed = 0;
            anim.SetBool("Dead", true);
            anim.SetFloat("Speed", 0);
            //spr.color = Color.red;
            corazon1.SetActive(false);
            dead = true;
            GameControl.instance.PlayerDied();
            EnemyController.speed = 0f;
            latido.Stop();
            juegoVivo.volume = 0;
            contadorMuertes += 1;
            PlayerPrefs.SetInt("contadorMuertes", contadorMuertes);

            if (PlayerPrefs.GetInt("audio") == 1)
            {
                muerte.Play();
                juegoMuerto.Play();
            }
                
            settings.interactable = false;
        }

        if (col.gameObject.tag == "Platfroms")
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            transform.parent = col.transform;
            grounded = true;
        }

        if (col.gameObject.tag == "Activador")
        {
            GameControl.dañoJugador *= 2;
        }
        
        if (PlayerPrefs.GetInt("contadorMuertes") == 5)
        {
            AdMob.instance3.ShowInterstitialAd();
            contadorMuertes = 0;
            PlayerPrefs.SetInt("contadorMuertes", contadorMuertes);
        }

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platforms")
        {
            transform.parent = col.transform;
            grounded = true;
        }

        if (col.gameObject.tag == "Obstaculo")
        {
            grounded = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platforms")
        {
            transform.parent = null;
            grounded = false;
        }
    }    
}