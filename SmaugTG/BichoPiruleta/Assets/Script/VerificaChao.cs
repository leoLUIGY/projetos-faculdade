using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaChao : MonoBehaviour
{
    public Transform linhaInicioChao, linhaFimChao;
    public  bool face = true;
    private Animator correndo;

    public float vel = 2.5f;
    public bool linhaChao;
    void Start()
    {
        correndo = GetComponent<Animator>();
    }

    void Update() {
        linhaChao = Physics2D.Linecast(linhaInicioChao.position, linhaFimChao.position, 1 << LayerMask.NameToLayer("chao"));

        if (linhaChao == true && InimigoAtira.linha == false)
        {
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            correndo.SetBool("andando", true);
        }


        if (linhaChao == false)
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
