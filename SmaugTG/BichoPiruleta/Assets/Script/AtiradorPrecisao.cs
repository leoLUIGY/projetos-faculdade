using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiradorPrecisao : MonoBehaviour
{

    public Transform targ;
    public Transform linhaInicio, linhaFim;
    Quaternion newRotation;
    public GameObject canoInimigo;
    public GameObject balaInimigo;

    private float linhaFimX, linhaFimY;

    public static bool linha;
    public bool bater;
   
    private float vel = 2.5f;

    private Animator atiraPara;
    // Start is called before the first frame update
    void Start()
    {
        atiraPara = GetComponent<Animator>();
        bater = false;
       
    }
    // Update is called once per frame
    void Update()
    {

        linhaFimX = targ.position.x;
        linhaFimY = targ.position.y;

        if (bater == true)
        {
            linhaFim.position = new Vector3(linhaFimX, linhaFimY, targ.position.z);
        }

        Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
        linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));

        if (Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador")))
        {


            Vector3 canoPlaye = targ.transform.position - transform.position;
            canoPlaye.x = 0;
            canoPlaye.y = 0;
            newRotation = Quaternion.LookRotation(canoPlaye);

            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.1f * Time.deltaTime);
            StartCoroutine(tiroPrecisao(2f));
          
        }




        if (linha == true)
        {



            atiraPara.SetBool("playerNaMira", true);
           


        }
        else
        {

            atiraPara.SetBool("playerNaMira", false);

        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("bala"))
        {

            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            bater = true;

        }

    }
    private IEnumerator tiroPrecisao(float troca)
    {
      yield return new WaitForSeconds(troca);
        Instantiate(balaInimigo, new Vector3(canoInimigo.transform.position.x, canoInimigo.transform.position.y,
     canoInimigo.transform.position.z), canoInimigo.transform.rotation);
    }
}
