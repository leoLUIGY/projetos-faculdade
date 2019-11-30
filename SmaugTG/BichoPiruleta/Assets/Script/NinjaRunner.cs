using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NinjaRunner : MonoBehaviour
{
    private Animator correndo;
    private Animator ataqueNormal;
    private Animator tiro;
    public Text balas;
    public Text vidas;

    public Rigidbody2D body;
    public static int quantidadeDeBalas;
    public static bool face = true;
    private float vel = 5f;
    public static int vida = 5;

    private bool correrAntes;

    public Transform groundCheck;
    private bool grounded;
    private float groundRadious = 0.1f;
    public LayerMask oQueChao;
    private float jumpForce = 500f;

    public static bool parede;

    public GameObject cano;
    //public Transform heroiT;
    public GameObject bala;

    public GameObject cenario;
    public GameObject[] chao = new GameObject[2] ;
    public GameObject[] vidasSucata = new GameObject[6];

    public Text sucataLiberada;
    public static int sucataPontos;

    public static AudioClip andar, atirar;
    static  AudioSource sons;



    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        correrAntes = false;
        quantidadeDeBalas = 10;
        sucataPontos = 0;
        correndo = GetComponent<Animator>();
        ataqueNormal = GetComponent<Animator>();
        tiro = GetComponent<Animator>();


        correndo.SetBool("correndo", false);
        ataqueNormal.SetBool("ataqueNormal", false);
        tiro.SetBool("tiro", false);

        andar = Resources.Load<AudioClip>("Walking");
        atirar = Resources.Load<AudioClip>("foton");

        sons = GetComponent<AudioSource>();

        PlayerPrefs.SetFloat("x", transform.position.x);

        PlayerPrefs.SetFloat("y", transform.position.y);

        PlayerPrefs.SetInt("qtb", quantidadeDeBalas);

        PlayerPrefs.SetInt("vidas", vida);
        PlayerPrefs.SetInt("qta", sucataPontos);

        for (int i = 0; i < 4; i++)
        {
           vidasSucata[i].SetActive(false);

        }
    }


    // Update is called once per frame
    void Update()
    {
       

        for(int i = 0; i <6; i++) { 
            if(vida == i) {
                vidasSucata[i].SetActive(true);
            }
             else {
                vidasSucata[i].SetActive(false);
             }
        }
        if (Portais.apertou == true)
        {
            PlayerPrefs.SetFloat("x", transform.position.x);

            PlayerPrefs.SetFloat("y", transform.position.y);

            PlayerPrefs.SetInt("qtb", quantidadeDeBalas);

            PlayerPrefs.SetInt("vidas", vida);
            PlayerPrefs.SetInt("qta", sucataPontos);

        }
    
        if (Menu.carregar == true)
        {
            Vector2 pos = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
    transform.position = pos;

            PlayerPrefs.GetInt("qtb");

            PlayerPrefs.GetInt("vidas");

            PlayerPrefs.GetInt("qta");
        }

      grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadious, oQueChao);

        sucataLiberada.text = sucataPontos.ToString();
        vidas.text = vida.ToString();
        balas.text = quantidadeDeBalas.ToString();

        mover();
        ataques();

        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            body.AddForce(new Vector2(0, jumpForce));
        }

        if (vida <= 0)
        {
          
                Destroy(this.gameObject);
                
        
        }


        if (Input.GetKeyDown(KeyCode.D) && !face)
        {
            flip();

        }
        else if (Input.GetKeyDown(KeyCode.A) && face)
        {
            flip();

        }

    }

    public void ataques()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ataqueNormal.SetBool("ataqueNormal", true);
        }

        else
        {
            ataqueNormal.SetBool("ataqueNormal", false);

        }

        if (Input.GetKey(KeyCode.V) && (quantidadeDeBalas > 0))
        {
            tiro.SetBool("tiro", true);
            quantidadeDeBalas--;
            sons.PlayOneShot(atirar);
            Instantiate(bala, new Vector3(cano.transform.position.x, cano.transform.position.y, cano.transform.position.z), cano.transform.rotation);




        }
        //if (Input.GetKeyUp(KeyCode.C))
        else
        {
            tiro.SetBool("tiro", false);

        }

       

    }

    void mover()
    {
        if ((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.A)) )
        {
            correrAntes = false;
            correndo.SetBool("correndo", correrAntes);
            sons.loop = false;
            sons.Pause();

        }

        if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.A)))
        {
            sons.PlayOneShot(andar);
            sons.loop = true;

        }


        if (Input.GetKey(KeyCode.D))
        {
            correrAntes = true;
            correndo.SetBool("correndo", correrAntes);

            if (correrAntes == true)
            {
              
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            }
        }


        else if (Input.GetKey(KeyCode.A))
        {
            correrAntes = true;
            correndo.SetBool("correndo", correrAntes);

            if (correrAntes == true)
            {
             

                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
            }
        }

    }
    void flip()
    {
        face = !face;
        Vector3 scala = this.gameObject.GetComponent<Transform>().localScale;
        scala.x *= -1;
        this.gameObject.GetComponent<Transform>().localScale = scala;
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("bala"))
        {

            Destroy(col.gameObject);
            //vida--;
        }

        if (col.gameObject.CompareTag("parede"))
        {

            if (Input.GetKey(KeyCode.D))
            {

                cenario.transform.Translate(new Vector2(-3.5f * Time.deltaTime, 0));

                for (int i = 0; i < 3; i++)
                {
                    chao[i].transform.Translate(new Vector2(-3 * Time.deltaTime, 0));
                }
            }
            if (Input.GetKey(KeyCode.A))
            {

                cenario.transform.Translate(new Vector2(3.5f * Time.deltaTime, 0));
                for (int i = 0; i < 3; i++)
                {
                    chao[i].transform.Translate(new Vector2(3 * Time.deltaTime, 0));
                }
            }


        }

       

    }
    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.CompareTag("parede"))
        {

            parede = true;

        }

    }
    void OnTriggerExit2D(Collider2D col)
    {


        if (col.gameObject.CompareTag("parede"))
        {

            parede = false;

        }

    }

}
