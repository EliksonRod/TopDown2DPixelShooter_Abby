/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
//freesounds.org

public class gameJuice : MonoBehaviour
{
    SpriteRenderer myRender;
    Material myMat;
    AudioSource collisionAudio;
    public AudioClip[] hitSound;

    // Start is called before the first frame update
    void Start()
    {
        //myMay = GetComponent<Material>();
        myRender = GetComponent<SpriteRenderer>();
        collisionAudio = GetComponent<AudioSource>();
        myMat = myRender.material;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Collectible")
        {
            StartCoroutine(changeColor(.5f));
            Debug.Log("collided with a collectible");
        }
        collisionAudio.clip = hitSound[Random.Range];
        collisionAudio.Play();
    }

    
}*/
