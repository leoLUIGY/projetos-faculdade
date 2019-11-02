using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portais : MonoBehaviour
{
    public GameObject alvo;
    public GameObject loading;
    public static bool apertou;
    private int portal;
    Vector3 posis;
    // Start is called before the first frame update
    void Start()
    {
       
        loading.SetActive(false);
        apertou = false;
        portal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(portal == 1) {
            posis = new Vector3(-103.6f, -46.6f, alvo.transform.position.z);
        } else if (portal == 2) {
            posis = new Vector3(-7.8f, -2.5f, alvo.transform.position.z);
        }


        if (apertou == true && Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(tempoLoad(5f));
        }
    }

    void OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.CompareTag("Player")) {
            apertou = true;
        
        }
    }

    private IEnumerator tempoLoad(float tempo) {
        loading.SetActive(true);
        alvo.transform.position = posis;
        yield return new WaitForSeconds(tempo);
        loading.SetActive(false);
        apertou = false;
        portal++;
    }
}
