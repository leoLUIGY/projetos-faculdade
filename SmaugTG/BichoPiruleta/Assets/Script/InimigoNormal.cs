using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoNormal : MonoBehaviour
{
    private float vel = 2.5f;
    private int vidas;
    private bool dano;


    public GameObject heroi;
    public GameObject inimigo;
    public GameObject muni;
    

    private Animator bater;
    private Animator morrendo;


   
    // Start is called before the first frame update
    void Start()
    {


        dano = false;
        vidas = 3;
        bater = GetComponent<Animator>();
        morrendo = GetComponent<Animator>();
        bater.SetBool("atacar", false);
        morrendo.SetBool("morrendo", false);
    }

    // Update is called once per frame
    void Update()
    {


        if (dano == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vidas--;
                StartCoroutine(danoCor(0.2f));
            }
        }

        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
        if (vidas == 0) {
            morrendo.SetBool("morrendo", true);
            StartCoroutine(morrendoEfeito(1.2f));


        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("bala"))
        {

            Destroy(col.gameObject);
            vidas--;
        }

        if (col.gameObject.CompareTag("Player"))
        {
            if (TutorialCenario.teclas == 3)
            {
                Time.timeScale = 0;
                TutorialCenario.teclas = 4;
            }
         
                vel = 0;
                bater.SetBool("atacar", true);
                dano = true;
                NinjaRunner.vida--;
                StartCoroutine(danoCorHeroi(0.2f));



        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
       
        if (col.gameObject.CompareTag("Player"))
        {
            //vel = 2.5f;
            bater.SetBool("atacar", false);
            NinjaRunner.vida--;
            dano = false;
        }
    }

    private IEnumerator danoCor(float troca) {
        for (int i = 0; i< 2; i++) {
            inimigo.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(troca);
            inimigo.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(troca);
        }
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
    }

    private IEnumerator morrendoEfeito(float troca)
    {
       
        yield return new WaitForSeconds(troca);
        Instantiate(muni, new Vector3(inimigo.transform.position.x, inimigo.transform.position.y, inimigo.transform.position.z), inimigo.transform.rotation);
        int sucata = Random.Range(0, 10);

        if (sucata < 7)
        {
            NinjaRunner.sucataPontos += 1;
        }

        Destroy(inimigo);
       
    }


}
