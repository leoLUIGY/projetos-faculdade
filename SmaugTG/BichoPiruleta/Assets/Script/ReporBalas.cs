using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReporBalas : MonoBehaviour
{
    public GameObject muni;
  

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")) {

            NinjaRunner.quantidadeDeBalas += 5;
            Destroy(muni);
        }
    }
}
