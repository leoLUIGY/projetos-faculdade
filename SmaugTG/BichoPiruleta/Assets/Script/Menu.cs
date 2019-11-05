using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static bool carregar;
    GameObject cam = GameObject.Find("Main Camera");

    // Start is called before the first frame update
    void Start()
    {
        carregar = false;


    }

    // Update is called once per frame
    void Update()
    {
        var videoPlayer = cam.AddComponent<UnityEngine.Video.VideoPlayer>();
        if (!videoPlayer.isPlaying) {
            videoPlayer.Stop();
        }
    }

    public void PlayGame() {
        SceneManager.LoadScene(2);
    }
    public void Continuar()
    {

        carregar = true;
        SceneManager.LoadScene(2);
       
    }
}
