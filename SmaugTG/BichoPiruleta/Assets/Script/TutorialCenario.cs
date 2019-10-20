using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCenario : MonoBehaviour
{
    public GameObject letrasTutorial;
    public GameObject inimigos;
   // public GameObject background;

    private float x = 13.2f;
    private float y = -1.51f;
    private float z = -0.2f;

    public static int teclas;
    public bool inicioTutorial;
    public  Text letras;
    

   // Start is called before the first frame update
    void Start()
    {
        teclas = 0;
        inicioTutorial = false;
        letrasTutorial.SetActive(false);
        StartCoroutine(turorial(5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && inicioTutorial == true && teclas == 0) {
            teclas = 1;
            letras.text = "A";


           
        }

        if(teclas == 1 && Input.GetKeyDown(KeyCode.A)) {
            teclas = 2;
            letras.text = "D";
        }

        if (teclas == 2 && Input.GetKeyDown(KeyCode.D))
        {


            //background.GetComponent<SpriteRenderer>().color = Color.clear;
            letrasTutorial.SetActive(false);
            for (int i = 0; i < 10; i++)
            {
                Instantiate(inimigos, new Vector3(x + (i*10), y, z),
                inimigos.transform.rotation);
            }
            teclas = 3;
        }
        if (teclas == 4) {
            letras.text = "Space";
            letrasTutorial.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) {
                Time.timeScale = 1;
                letrasTutorial.SetActive(false);
                teclas = 5;
            }
        }



    }

   
            
    

public static void parallaxEfect() {
    
    }

    private IEnumerator turorial(float troca)
    {
        //background.GetComponent<SpriteRenderer>().color = Color.red;
        letras.text = "W";
        yield return new WaitForSeconds(troca);
        inicioTutorial = true;
        letrasTutorial.SetActive(true);
    }
}
