using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboColetor : MonoBehaviour
{
   
 
   


    private Animator correndo;
   
    private Animator tiro;
    public GameObject heroi;
    public static bool face = true;
    private bool roboParado;
    private bool roboAndando;
    private bool roboAtirando;
    public Transform linhaIn;
    public Transform linhaFi;
    private bool perseguir;
    // public Transform linhaInicio, linhaFim;


    public bool linha;
   
  
    public int vidas = 10;
    private float vel = 2.5f;

    private Animator atiraPara;
    // Start is called before the first frame update
    void Start()
    {
        perseguir = false;
        correndo = GetComponent<Animator>();
      
        tiro = GetComponent<Animator>();


        correndo.SetBool("RoboAndando", true);
       
        tiro.SetBool("roboAtirando", false);


    }
    // Update is called once per frame
    void Update()
    {
        // Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
        //linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));
        if (perseguir == true)
        {
            roboAtirando = false;
            roboAndando = true;
            if (Physics2D.Linecast(linhaIn.position, linhaFi.position, 1 << LayerMask.NameToLayer("jogador")))
            {
                roboAtirando = true;
                roboAndando = false;
            }
        }
       

            if (roboAndando == true) {
            correndo.SetBool("RoboAndando", true);
           
            tiro.SetBool("roboAtirando", false);
            transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
        }

        if (roboAtirando == true) {
            correndo.SetBool("RoboAndando", false);
           
            tiro.SetBool("roboAtirando", true);
          
        }
        if (vidas == 0)
        {
            Destroy(this.gameObject);
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

        if (col.gameObject.CompareTag("balaJohn"))
        {

            Destroy(col.gameObject);
            vidas--;

        }

       





    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            perseguir = true;
           
        }
        if ((transform.position.x < heroi.transform.position.x) && (face))
        {
            vel *= -1;
            flip();
        }
        if ((transform.position.x > heroi.transform.position.x) && (!face))
        {
            vel *= -1;
            flip();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
       
        if ((transform.position.x < heroi.transform.position.x) && (face))
        {
            vel *= -1;
            flip();
        }
        if ((transform.position.x > heroi.transform.position.x) && (!face))
        {
            vel *= -1;
            flip();
        }
    }
 
}
