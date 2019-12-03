using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : MonoBehaviour
{
    public Transform destino;
    public int pointAngle = 270;
    public float dampTime = 1f;
    private Vector3 velocity = Vector3.zero;
    private bool atacar;
    public GameObject[] doggeEspecial = new GameObject[6];
    private int especial = 6;
    Vector3 point;

    private Animator dogeAndando;
    // Start is called before the first frame update
    void Start()
    {
        atacar = false;
        for (int i = 0; i <4; i++) {
            doggeEspecial[i].SetActive(false);
            dogeAndando = GetComponent<Animator>();
            dogeAndando.SetBool("dogeAndando", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (especial == i)
            {
                doggeEspecial[i].SetActive(true);
            }
            else
            {
                doggeEspecial[i].SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.B) && especial == 6)
        {
            for (int i = 0; i < 6; i++)
            {
                transform.Translate(new Vector2(12 * Time.deltaTime, 0));

            }
            StartCoroutine(ataqueDoge(1f));
        }
        else
        {

            var pos = new Vector3(destino.position.x - 2.5f, transform.position.y, transform.position.z);
            point = pos;
            Vector3 delta = new Vector3(0.3f, 0, 0);
            Vector3 destination = point + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

            if (transform.position == point) {
                dogeAndando.SetBool("dogeAndando", false);
            } else if (transform.position != point) {
                dogeAndando.SetBool("dogeAndando", true);
            }


            if (Portais.outroMapa == true)
            {
                transform.position = new Vector3(-7.8f, -2.5f, transform.position.z);
                Portais.outroMapa = false;
            }
        }
      
    }

   
    private IEnumerator ataqueDoge(float tempo)
    {
       

        for (int i = 0; i < 7; i++)
        {
            especial = i;
            yield return new WaitForSeconds(tempo);
        }
        

    }

  void OnCollisionEnter2D(Collision2D col) { 
        if (col.gameObject.CompareTag("Player")) {
            GetComponent<Rigidbody2D>().simulated = false;

            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            GetComponent<Rigidbody2D>().simulated = false;

            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<Rigidbody2D>().simulated = true;

        }
    }
   
}

