using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portais : MonoBehaviour
{
    public GameObject alvo;
    public GameObject loading;
    public GameObject[] visor = new GameObject[4];
    public static bool apertou;
    public static bool salvarCamera;
    public  int portal;
    public static bool outroMapa;
  
    Vector3 posis;
    // Start is called before the first frame update
    void Start()
    {
       
        loading.SetActive(false);
        apertou = false;
        portal = 1;
        salvarCamera = false;
        outroMapa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(portal == 1) {
            posis = new Vector3(-103.6f, -46.6f, alvo.transform.position.z);
           
          
        } else if (portal == 2) {
            posis = new Vector3(-7.8f, -2.5f, alvo.transform.position.z);

        }


        if (apertou == true && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(tempoLoad(5f));

        }
        if (Menu.carregar == true) {
            PlayerPrefs.GetInt("portais");
        }
        if (NinjaRunner.vida <= 0)
        {
            if (portal == 1)
            {
                Destroy(this.gameObject);
                //Menu.Continuar();
                 SceneManager.LoadScene(2);
                NinjaRunner.vida = 6;
            }
            else if (portal > 1)
            { 
            Menu.Continuar();
            }

        }

    }

    void OnCollisionEnter2D(Collision2D col) { 
        if (col.gameObject.CompareTag("Player")) {
            apertou = true;

        
        }
    }

    private IEnumerator tempoLoad(float tempo) {
        for (int i = 0; i<5; i++) {
            visor[i].SetActive(false);
        }
        loading.SetActive(true);
        alvo.transform.position = posis;

        yield return new WaitForSeconds(tempo);
        for (int j = 0; j < 5; j++)
        {
            visor[j].SetActive(true);
        }
        loading.SetActive(false);
        apertou = false;
        portal++;
        if (portal == 2) {
            outroMapa = true;
        }
        PlayerPrefs.SetInt("portais", portal);
        salvarCamera = true;
    }
}
