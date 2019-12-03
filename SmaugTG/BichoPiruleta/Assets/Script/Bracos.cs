using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bracos : MonoBehaviour
{
    public GameObject destino;
    private int angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = 170;
    }

    // Update is called once per frame
    void Update()
    {
        var angle1 = Mathf.Atan2(destino.transform.position.y - transform.position.y, destino.transform.position.x - transform.position.x) * Mathf.Rad2Deg + angle;
       

        //var angle2 = Mathf.Atan2(canoPlaye.x, 0) * Mathf.Rad2Deg + pointAngle2;





        transform.rotation = Quaternion.Euler(0, -180, -angle1 + 15);
       
    }
}
