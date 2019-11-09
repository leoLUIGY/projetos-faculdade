using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool carregar;
   

    // Start is called before the first frame update
    void Start()
    {
        carregar = false;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame() {
        SceneManager.LoadScene(2);
    }
    public static void Continuar()
    {
        
        carregar = true;
        SceneManager.LoadScene(2);
       
    }
}
