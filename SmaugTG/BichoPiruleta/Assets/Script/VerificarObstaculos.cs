using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarObstaculos : MonoBehaviour
{
    public Transform linhaInicioChao, linhaFimChao;
    public bool linhaChao2;
    public  bool face = true;
    private Animator correndo;
    public  float vel = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        correndo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        linhaChao2 = Physics2D.Linecast(linhaInicioChao.position, linhaFimChao.position, 1 << LayerMask.NameToLayer("obstaculos"));


        if (linhaChao2 == false && InimigoAtira.linha == false)
        {
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            correndo.SetBool("andando", true);
        }


        if (linhaChao2 == true)
        {

           vel *= -1;

            flip();
        }
    }
    public void flip()
    {
        face = !face;
        Vector3 scala = this.gameObject.GetComponent<Transform>().localScale;
        scala.x *= -1;
        this.gameObject.GetComponent<Transform>().localScale = scala;
    }

}
