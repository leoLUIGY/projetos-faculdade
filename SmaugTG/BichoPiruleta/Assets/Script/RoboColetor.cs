using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboColetor : MonoBehaviour
{
   
 
    private Animator correndo;
    public GameObject golpe;

    public Transform linhaInicio, linhaFim;
    public Transform linhaInicioChao, linhaFimChao;
    public static bool face = true;

    public bool linha;
    public bool linhaChao;
    public bool linhaChao2;
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
        linhaChao = Physics2D.Linecast(linhaInicioChao.position, linhaFimChao.position, 1 << LayerMask.NameToLayer("chao"));

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





        if ((linhaChao == false && linha == false) || (linhaChao2 == true && linha == false))
        {

            vel *= -1;

            flip();
        }
        else if (linhaChao == true && linha == false)
        {
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            correndo.SetBool("andando", true);
        }
        void flip()
        {
            face = !face;
            Vector3 scala = this.gameObject.GetComponent<Transform>().localScale;
            scala.x *= -1;
            this.gameObject.GetComponent<Transform>().localScale = scala;
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("bala"))
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
