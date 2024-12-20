using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip clip;

   // public static Audio instance;

    private void Awake()
    {

        GameObject[] backgroundMusic = GameObject.FindGameObjectsWithTag("Music");
        if(backgroundMusic.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


        //GameObject.FindGameObjectWithTag("Music").GetComponent<Audio>().StopMusic();

        /*if (instance != null)
             Destroy(gameObject);
         else
         {
             audioSource = GetComponent<AudioSource>();
             instance = this;
             DontDestroyOnLoad(this.gameObject);
             
        }*/

    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
    
