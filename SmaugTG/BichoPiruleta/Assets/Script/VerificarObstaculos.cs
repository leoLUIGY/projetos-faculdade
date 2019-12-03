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
    public float velultimo = 2.5f;
    private int angle;
    public GameObject bEsquerdo;
    public GameObject bDireito;
    public Transform targ;
    // Start is called before the first frame update
    void Start()
    {
        correndo = GetComponent<Animator>();
        angle = 170;
    }

    // Update is called once per frame
    void Update()
    {
        linhaChao2 = Physics2D.Linecast(linhaInicioChao.position, linhaFimChao.position, 1 << LayerMask.NameToLayer("obstaculos"));




        if (linhaChao2 == false && InimigoAtira.linha == false)
        {
            /*if (InimigoAtira.atirar == true)
            {
                velultimo = vel;
                vel = 0;
            }
            else if (InimigoAtira.atirar == false)
            {
                vel = 2.5f;
            }
            */
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            correndo.SetBool("andando", true);
        }


        if (linhaChao2 == true)
        {

            vel *= -1;

            flip();
        }
        var angle1 = Mathf.Atan2(targ.position.y - bEsquerdo.transform.position.y, targ.position.x - bEsquerdo.transform.position.x) * Mathf.Rad2Deg + angle;
        var angle2 = Mathf.Atan2(targ.position.y - bDireito.transform.position.y, targ.position.x - bDireito.transform.position.x) * Mathf.Rad2Deg + angle;

        if (face)
        {
            angle = 170;
            bEsquerdo.transform.rotation = Quaternion.Euler(0, -180, -angle1 + 15);
            bDireito.transform.rotation = Quaternion.Euler(0, -180, -angle1 + 15);
        }
        else if (!face)
        {
            angle = 205;
            bEsquerdo.transform.rotation = Quaternion.Euler(0, -180, -angle1 + 15);
            bDireito.transform.rotation = Quaternion.Euler(0, -180, -angle1 + 15);
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
