using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecisaoPersegue : MonoBehaviour
{

    public Transform targ;
    private int angle;
    public GameObject bEsquerdo;
    public GameObject bDireito;
    public Transform linhaInicio, linhaFim;
    Quaternion newRotation;
    public GameObject canoInimigo;
    public  bool face = true;

    private float linhaFimX, linhaFimY;

    public static bool linha;
    public static bool bater;

    private float vel = 2.5f;

    private Animator atiraPara;
    // Start is called before the first frame update
    void Start()
    {
        atiraPara = GetComponent<Animator>();
        bater = false;
        angle = 170;

    }
    // Update is called once per frame
    void Update()
    {
       
        //linhaFimX = targ.position.x;
        //linhaFimY = targ.position.y;

        // if (bater == true)
        //{
        //  linhaFim.position = new Vector3(linhaFimX, linhaFimY, targ.position.z);
        //}

        Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
        linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));




        if (linha == true)
        {



            atiraPara.SetBool("playerNaMira", true);



        }
        else
        {

            atiraPara.SetBool("playerNaMira", false);

        }

        var angle1 = Mathf.Atan2(targ.position.y - bEsquerdo.transform.position.y, targ.position.x - bEsquerdo.transform.position.x) * Mathf.Rad2Deg + angle;
        var angle2 = Mathf.Atan2(targ.position.y - bDireito.transform.position.y, targ.position.x - bDireito.transform.position.x) * Mathf.Rad2Deg + angle;

        if (face)
        {
            angle = 170;
            bEsquerdo.transform.rotation = Quaternion.Euler(0, -180, -angle1 + 15);
            bDireito.transform.rotation = Quaternion.Euler(0,-180, -angle1 + 15);
        } else if (!face) {
            angle = 35;
            bEsquerdo.transform.rotation = Quaternion.Euler(0, -180, -angle1 + 15);
            bDireito.transform.rotation = Quaternion.Euler(0, -180, -angle1 + 15);
        }
    }
    void flip()
    {
        face = !face;
        Vector3 scala = this.gameObject.GetComponent<Transform>().localScale;
        scala.x *= -1;
        this.gameObject.GetComponent<Transform>().localScale = scala;
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
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(danoCor(0.2f));
           
        }
        if (col.gameObject.CompareTag("balaJohn"))
        {

            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if ((targ.transform.position.x > transform.position.x - 2f) && face)
            {

                flip();
            }
            else if ((targ.transform.position.x < transform.position.x + 2f) && !face)
            {

                flip();
            }
            bater = true;

        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if ((targ.transform.position.x > transform.position.x) && face)
            {

                flip();
            }
            else if ((targ.transform.position.x < transform.position.x) && !face)
            {

                flip();
            }

            bater = false;
        }


        }

    }

