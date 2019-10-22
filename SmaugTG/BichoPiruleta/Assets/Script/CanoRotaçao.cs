using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoRotaçao : MonoBehaviour
{
   
    public Rigidbody cano;
    Quaternion newRotation;
    public GameObject destino;
    public GameObject canoInimigo;
    public GameObject balaInimigo;
    public Transform linhaIni;
    public Transform linhaFim;


    // Start is called before the first frame update
    void Start()
    {

        cano = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(linhaIni.position, destino.transform.position, Color.red);

           
            if (Physics2D.Linecast(linhaIni.position, linhaFim.position, 1 << LayerMask.NameToLayer("jogador")))
            {

                
            Vector3 canoPlaye = destino.transform.position - transform.position;
                canoPlaye.x = 0;
                canoPlaye.y = 0;
                newRotation = Quaternion.LookRotation(canoPlaye);
                
                transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.1f * Time.deltaTime);

                Instantiate(balaInimigo, new Vector3(canoInimigo.transform.position.x, canoInimigo.transform.position.y,
     canoInimigo.transform.position.z), canoInimigo.transform.rotation);
            }

           
        
    }
}
