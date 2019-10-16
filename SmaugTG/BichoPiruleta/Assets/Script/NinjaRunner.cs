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


    public static int quantidadeDeBalas;
    public static bool face = true;
    private float vel = 2.5f;
    public static int vida = 3;



    public GameObject cano;
    //public Transform heroiT;
    public GameObject bala;
  
    public GameObject cenario;
    public GameObject chao;

    public Text sucataLiberada;
    public static int sucataPontos;

    // Start is called before the first frame update
    void Start()
    {
        quantidadeDeBalas = 0;
        sucataPontos = 0;
        correndo = GetComponent<Animator>();
        ataqueNormal = GetComponent<Animator>();
        tiro = GetComponent<Animator>();


        correndo.SetBool("correndo", false);
        ataqueNormal.SetBool("ataqueNormal", false);
        tiro.SetBool("tiro", false);
    }

    // Update is called once per frame
    void Update()
    {
        sucataLiberada.text = sucataPontos.ToString();
        vidas.text = vida.ToString();
        balas.text = quantidadeDeBalas.ToString();

        if (vida <= 0) {
            Destroy(this.gameObject); 
        }

        mover();
        ataques();
      
        if (Input.GetKeyDown(KeyCode.D) && !face) {
            flip();
          
        } else if (Input.GetKeyDown(KeyCode.A) && face)
        {
            flip();
           
        }
        
    }

    public void ataques() { 
        if (Input.GetKeyDown(KeyCode.Space) && TutorialCenario.teclas >0) {
           
            ataqueNormal.SetBool("ataqueNormal", true);
        }

        else {
            ataqueNormal.SetBool("ataqueNormal", false);

        }

        if (Input.GetKey(KeyCode.V) && (quantidadeDeBalas > 0))
        {
            tiro.SetBool("tiro", true);
            quantidadeDeBalas--;
           
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
        if ((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.A)))
        {
            correndo.SetBool("correndo", false);

        }


        if (Input.GetKey(KeyCode.D) && TutorialCenario.teclas > 2)
        {

            correndo.SetBool("correndo", true);
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));
        }


        else if (Input.GetKey(KeyCode.A) && TutorialCenario.teclas > 1)
        {

            correndo.SetBool("correndo", true);

            transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
        }
       
    }
    void flip() {
        face = !face;
        Vector3 scala = this.gameObject.GetComponent<Transform>().localScale;
        scala.x *= -1;
        this.gameObject.GetComponent<Transform>().localScale = scala;
    }


    void OnCollisionEnter2D(Collision2D col ) {

        if (col.gameObject.CompareTag("parede"))
        {

            if (Input.GetKey(KeyCode.D))
            {

                cenario.transform.Translate(new Vector2(-3.5f * Time.deltaTime, 0));
                chao.transform.Translate(new Vector2(-3 * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
               
                cenario.transform.Translate(new Vector2(3.5f * Time.deltaTime, 0));
                chao.transform.Translate(new Vector2(3 * Time.deltaTime, 0));
            }


        }
    }
   

}
