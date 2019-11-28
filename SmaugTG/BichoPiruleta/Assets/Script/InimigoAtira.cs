using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtira : MonoBehaviour
{
    private Animator correndo;
   

    public Transform targ;
    public Transform linhaInicio, linhaFim;
   
    public static bool face = true;
    private float linhaFimX, linhaFimY;

    public static bool atirar;
    public static bool linha;
    
    private float vel = 2.5f;
   
    private Animator atiraPara;
    // Start is called before the first frame update
    void Start()
    {
        atiraPara = GetComponent<Animator>();
        correndo = GetComponent<Animator>();
       

    }
    // Update is called once per frame
    void Update()
    {

        linhaFimX = targ.position.x;
        linhaFimY = targ.position.y;



        Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
        linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));
       
       

        if (atirar == true)
        {
            linhaFim.position = new Vector2(linhaFimX, linhaFimY);
        }

        if (linha == true)
        {
          
           

            atiraPara.SetBool("playerNaMira", true);
            correndo.SetBool("andando", false);


        }
        else
        {

            atiraPara.SetBool("playerNaMira", false);
            
        }

     
      


    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("balaJohn"))
        {

            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }


    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player"))
        {

            atirar = true;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            atirar = false;
        }

    }
}