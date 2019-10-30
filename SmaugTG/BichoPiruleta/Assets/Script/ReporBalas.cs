using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReporBalas : MonoBehaviour
{
    public GameObject muni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")) {

            NinjaRunner.quantidadeDeBalas += 5;
            Destroy(muni);
        }
    }
}
