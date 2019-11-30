using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiradorPrecisao : MonoBehaviour
{

    public Transform targ;
    public Transform linhaInicio, linhaFim;
    Quaternion newRotation;
    public GameObject canoInimigo;
    public GameObject balaInimigo;

    private float linhaFimX, linhaFimY;

   // public static bool linha;

    private bool espera;

    private float vel = 2.5f;

    private Animator atiraPara;
    public static AudioClip  atirar;
    static AudioSource sons;
    // Start is called before the first frame update
    void Start()
    {
        atiraPara = GetComponent<Animator>();

        atirar = Resources.Load<AudioClip>("foton");

        sons = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        linhaFimX = targ.position.x;
        linhaFimY = targ.position.y;


       
            //Debug.DrawLine(linhaInicio.position, linhaFim.position, Color.green);
            //linha = Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador"));

            if (Physics2D.Linecast(linhaInicio.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador")) )
           {
            if (PrecisaoPersegue.bater == true)
            {
                linhaFim.position = new Vector3(linhaFimX, linhaFimY, targ.position.z);
            }
            //if (PrecisaoPersegue.bater == true)
            //{
            var canoPlaye = targ.transform.position - canoInimigo.transform.position;

                var angle = Mathf.Atan2(canoPlaye.y, canoPlaye.x) * Mathf.Rad2Deg + 270;



                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                StartCoroutine(tiroPrecisao(1f));
                StartCoroutine(intervaloTiro(5f));
           // }
        }

       

    }

    private IEnumerator tiroPrecisao(float troca)
    {
            sons.PlayOneShot(atirar);
            Instantiate(balaInimigo, new Vector3(canoInimigo.transform.position.x, canoInimigo.transform.position.y,
         canoInimigo.transform.position.z), canoInimigo.transform.rotation);
            yield return new WaitForSeconds(troca);

           

      


    }

    private IEnumerator intervaloTiro(float troca)
    {
       
        yield return new WaitForSeconds(troca);






    }
}
