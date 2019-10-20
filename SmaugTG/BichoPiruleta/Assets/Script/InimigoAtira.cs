using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtira : MonoBehaviour
{
    public GameObject canoInimigo;
    public GameObject balaInimigo;
    private Animator correndo;

    public Transform linhaInicio, linhaFim;
    public Transform linhaInicioChao, linhaFimChao;
    public static bool face = true;

    public bool linha;
    public bool linhaChao;
    public bool linhaChao2;
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
        Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
        linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));
        linhaChao = Physics2D.Linecast(linhaInicioChao.position, linhaFimChao.position, 1 << LayerMask.NameToLayer("chao"));
        linhaChao2 = Physics2D.Linecast(linhaInicioChao.position, linhaFimChao.position, 1 << LayerMask.NameToLayer("obstaculos"));



        if (linha == true)
        {
            atiraPara.SetBool("playerNaMira", true);
            correndo.SetBool("andando", false);
            Instantiate(balaInimigo, new Vector3(canoInimigo.transform.position.x, canoInimigo.transform.position.y,
            canoInimigo.transform.position.z), canoInimigo.transform.rotation);
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
            Destroy(this.gameObject);
        }


    }
}