using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoRotaçao : MonoBehaviour
{
   
    public Rigidbody cano;

    public GameObject destino;
    public GameObject canoInimigo;
    public GameObject balaInimigo;
     public Transform linhaIni;
    public Transform linhaFim;
    public int pointAngle;
    private bool esperar;
    public static AudioClip atirar;
    static AudioSource sons;
    private float linhaFimX, linhaFimY;
    // Start is called before the first frame update
    void Start()
    {

        cano = GetComponent<Rigidbody>();
        pointAngle = 270;
        atirar = Resources.Load<AudioClip>("tiroInimigo");

        sons = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        linhaFimX = destino.transform.position.x;
        linhaFimY = destino.transform.position.y;
        //Debug.DrawLine(linhaIni.position, destino.transform.position, Color.red);

        //if (InimigoAtira.atirar == true)
        //{
        if (Physics2D.Linecast(linhaIni.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador")))
            {

            if (InimigoAtira.atirar == true)
            {
                linhaFim.position = new Vector2(linhaFimX, linhaFimY);
            }

            var canoPlaye = destino.transform.position - transform.position;
                var angle = Mathf.Atan2(canoPlaye.y, canoPlaye.x) * Mathf.Rad2Deg + pointAngle;



                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                StartCoroutine(tiroFuzil(1f));
                StartCoroutine(intervaloFuzil(5f));
            //}
        }


    }
    private IEnumerator tiroFuzil(float troca)
    {

            sons.PlayOneShot(atirar);
            Instantiate(balaInimigo, new Vector3(canoInimigo.transform.position.x, canoInimigo.transform.position.y,
canoInimigo.transform.position.z), transform.rotation);
            yield return new WaitForSeconds(troca);

    }
    private IEnumerator intervaloFuzil(float troca)
    {


        yield return new WaitForSeconds(troca);

    }
}
