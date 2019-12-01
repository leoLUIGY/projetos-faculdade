using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReporVida : MonoBehaviour
{
    public GameObject vida;
    // Start is called before the first frame update
   
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (NinjaRunner.vida < 6) {
                NinjaRunner.vida += 1;
                Destroy(vida);
            } 

        }
    }
}
