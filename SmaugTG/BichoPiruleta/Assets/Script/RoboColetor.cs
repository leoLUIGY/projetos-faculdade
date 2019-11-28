using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboColetor : MonoBehaviour
{
   
 
    private Animator correndo;
    public GameObject golpe;

    public Transform linhaInicio, linhaFim;
   

    public bool linha;
   
  
    public int vidas = 10;
    private float vel = 2.5f;

    private Animator atiraPara;
    // Start is called before the first frame update
    void Start()
    {
        atiraPara = GetComponent<Animator>();
        correndo = GetComponent<Animator>();
        golpe.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
        linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));
       

        if (vidas == 0)
        {
            Destroy(this.gameObject);
        }

        if (linha == true)
        {
            atiraPara.SetBool("playerNaMira", true);

            correndo.SetBool("andando", false);
            StartCoroutine(bateu(1f));
            NinjaRunner.vida-=2;
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
            vidas--;

        }


       
         

    }
    private IEnumerator bateu(float troca)
    {

        golpe.SetActive(true);
        yield return new WaitForSeconds(troca);
        golpe.SetActive(false);
    }
}
