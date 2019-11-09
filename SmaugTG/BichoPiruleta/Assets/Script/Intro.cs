using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    public GameObject cam = GameObject.Find("Main Camera");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var video = cam.GetComponent<UnityEngine.Video.VideoPlayer>();
        if (video.clockTime.Equals(14))
        {
            SceneManager.LoadScene(1);
        }
    }
}
