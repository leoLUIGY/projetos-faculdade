using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RoboSuicida : MonoBehaviour
{
    private bool detectado;
    public GameObject destino;
    public GameObject roboSuicida;
    private float vel = 5;

    private bool colis;
    public PlayableDirector director;
   
    public int pointAngle;

    // Start is called before the first frame update
    void Start()
    {
        pointAngle = 250;
        colis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (colis == false)
        {
            director.Play();
        }
        else
        {
            if (detectado == true)
            {
                var canoPlaye = destino.transform.position - transform.position;
                var angle = Mathf.Atan2(canoPlaye.y, canoPlaye.x) * Mathf.Rad2Deg + pointAngle;

                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.Translate(new Vector2(0, vel * Time.deltaTime));

            }

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) {

            detectado = true;
            colis = true;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")) {
            NinjaRunner.vida--;
            Destroy(this.gameObject);
         }

        if (col.gameObject.CompareTag("bala"))
        {

            Destroy(roboSuicida);
        }
    }
}
