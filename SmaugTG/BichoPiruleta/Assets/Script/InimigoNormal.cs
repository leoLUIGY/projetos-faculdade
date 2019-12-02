using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoNormal : MonoBehaviour
{
    private float vel = 2.5f;
    public int vidas;
    private bool dano;

  
    public GameObject heroi;
    public GameObject inimigo;
    public GameObject[] muni = new GameObject[2];

    private float velAnterior;
    public  bool achouPlayer;
    private Animator bater;
    private Animator morrendo;
    public static bool face = true;

    public bool linhaChao;
    // Start is called before the first frame update
    void Start()
    {

        achouPlayer = false;
        dano = false;
        vidas = 3;
        bater = GetComponent<Animator>();
        morrendo = GetComponent<Animator>();
        bater.SetBool("atacar", false);
        morrendo.SetBool("morrendo", false);
    }

    // Update is called once per frames
    void Update()
    {
       
        if (achouPlayer == true)
        {
           
            inimigo.transform.Translate(new Vector2(vel * Time.deltaTime, 0));
         
        }
        //transform.Translate(new Vector2(vel * Time.deltaTime, 0));
        if (vidas <= 0)
        {
            morrendo.SetBool("morrendo", true);
            StartCoroutine(morrendoEfeito(1.2f));


        }

        if (dano == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vidas--;
                StartCoroutine(danoCor(0.2f));
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
        if (col.gameObject.CompareTag("balaJohn"))
        {

            StartCoroutine(danoCor(0.2f));
            Destroy(col.gameObject);

        }

        if (col.gameObject.CompareTag("Player"))
        {
         
            if (TutorialCenario.teclas == 3)
            {
                Time.timeScale = 0;
                TutorialCenario.teclas = 4;
            }
            velAnterior = vel;
                vel = 0;
                bater.SetBool("atacar", true);
                dano = true;
                NinjaRunner.vida--;
                StartCoroutine(danoCorHeroi(0.2f));
           
        }

        if(col.gameObject.CompareTag("Doge")) {
            dano = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
       
        if (col.gameObject.CompareTag("Player"))
        {
            vel = velAnterior;
            bater.SetBool("atacar", false);
            //NinjaRunner.vida--;
            dano = false;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
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

            achouPlayer = true;

        }


      

    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
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





    private IEnumerator danoCor(float troca) {
        for (int i = 0; i< 2; i++) {
            inimigo.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(troca);
            inimigo.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(troca);
        }
        vidas--;
    }

    private IEnumerator danoCorHeroi(float troca)
    {
        for (int i = 0; i < 2; i++)
        {
            heroi.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(troca);
            heroi.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(troca);
        }
        if (!face)
        {
          heroi.transform.Translate(new Vector3(1f * Time.deltaTime, 0, 0));
        } else if (face) {
           heroi.transform.Translate(new Vector3(-1f * Time.deltaTime, 0, 0));
        }
    }

    private IEnumerator morrendoEfeito(float troca)
    {


        yield return new WaitForSeconds(troca);
        int sucata = Random.Range(0, 11);
        int caixa = Random.Range(0, 2);

        if (sucata < 7)
        {
            Instantiate(muni[caixa], new Vector3(inimigo.transform.position.x, inimigo.transform.position.y, inimigo.transform.position.z), inimigo.transform.rotation);

            NinjaRunner.sucataPontos += 1;
        }

        Destroy(inimigo);
       
    }

}
