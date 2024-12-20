using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    //WASD and Mouse tracking
    Vector2 moveDirection;
    Vector2 mousePosition;

    public AudioSource audioSource;
    public AudioClip clip;

    public void Start()
    {
        //Gets Components at the start of the script
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!pauseMenu.isPaused)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
            moveDirection = new Vector2(moveX, moveY).normalized;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
    
    public void Fire()
    {
        //shoots prefab, tracks position and rotation of the tip of the weapon
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //the speed the bullet travels
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

        //Plays audio when called
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

            SceneManager.LoadScene("Main Menu");

            //Reloads Current Scene
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
