using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtira : MonoBehaviour
{
    private Animator correndo;
   

    public Transform targ;
    public Transform linhaInicio, linhaFim;

    private float velAnterior;
    private float linhaFimX, linhaFimY;

    public static bool atirar;
    public static bool linha;
    
   
   
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

        //linhaFimX = targ.position.x;
        //linhaFimY = targ.position.y;



        Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
        linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));
       
       

        //if (atirar == true)
        //{
           // linhaFim.position = new Vector2(linhaFimX, linhaFimY);
        //}

        if (linha == true || atirar == true)
        {
          
           

            atiraPara.SetBool("playerNaMira", true);
            correndo.SetBool("andando", false);


        }
        else
        {

            atiraPara.SetBool("playerNaMira", false);
            correndo.SetBool("andando", true);
            
        }

     
      


    }
    private IEnumerator danoCor(float troca)
    {
        for (int i = 0; i < 2; i++)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(troca);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(troca);
        }
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("balaJohn"))
        {

            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(danoCor(0.2f));
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

            StartCoroutine(intervaloAtirarFalse(2f));
           
           
        }

    }


    private IEnumerator intervaloAtirarFalse(float troca)
    {

        atirar = false;
            yield return new WaitForSeconds(troca);
        atirar = false;
       
    }
}