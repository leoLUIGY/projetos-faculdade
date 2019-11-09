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

    // Start is called before the first frame update
    void Start()
    {

        cano = GetComponent<Rigidbody>();
        pointAngle = 270;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(linhaIni.position, destino.transform.position, Color.red);

           
            if (Physics2D.Linecast(linhaIni.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador")))
            {
            esperar = true;
               
           
            var canoPlaye = destino.transform.position - transform.position;
            var angle = Mathf.Atan2(canoPlaye.y, canoPlaye.x) * Mathf.Rad2Deg + pointAngle;
            

            
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                if (esperar == true)
                {
                    StartCoroutine(tiroFuzil(2f));
                }
            }

           
        
    }
    private IEnumerator tiroFuzil(float troca)
    {
        yield return new WaitForSeconds(troca);
        Instantiate(balaInimigo, new Vector3(canoInimigo.transform.position.x, canoInimigo.transform.position.y,
    canoInimigo.transform.position.z), transform.rotation);
        esperar = false;
    }
}
