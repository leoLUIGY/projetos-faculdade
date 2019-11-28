using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AutoCameraSetup : MonoBehaviour
{

    public float dampTime = 0.50f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

        if (target) {
            Vector3 delta;
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            if (Portais.apertou == true)
            {
                delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.1f, point.z));
               
            } else if (NinjaRunner.parede == true) {
                delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(point.x, point.y, point.z));
            }
            else
            {
               delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, point.y, point.z));
            }
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
          
        }

        if(Portais.salvarCamera == true) {
            PlayerPrefs.SetFloat("x", transform.position.x);

            PlayerPrefs.SetFloat("y", transform.position.y);

            PlayerPrefs.SetFloat("z", transform.position.y);

            Portais.salvarCamera = false;
        }

        if (Menu.carregar == true)
        {
            Vector3 pos = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            transform.position = pos;
            Menu.carregar = false;
        }
    }
}
