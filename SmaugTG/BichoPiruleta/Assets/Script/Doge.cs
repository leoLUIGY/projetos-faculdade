using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : MonoBehaviour
{
    public Transform destino;
    public int pointAngle = 270;
    public float dampTime = 1f;
    private Vector3 velocity = Vector3.zero;
    private bool atacar;
    Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        atacar = false;
    }

    // Update is called once per frame
    void Update()
    {

        var pos = new Vector3(destino.position.x, transform.position.y, transform.position.z);
         point = pos;
        Vector3 delta = new Vector3(0.3f, 0, 0);
        Vector3 destination = point + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

        if (atacar == true) {
            StartCoroutine(ataqueDoge(3f));
        }
    }

    void OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.CompareTag("Inimigo")) {
            atacar = true;
        }
    }
    private IEnumerator ataqueDoge(float tempo)
    {
        point.x += 2f;

        yield return new WaitForSeconds(tempo);
        atacar = false;

    }

}

