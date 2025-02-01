using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class player2D_controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public GameObject bulletPrefab;
    public Transform weaponBarrel;

    Vector2 movement;
    public Animator animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireWeapon();
        }
    }

    void FixedUpdate()
    {
        playerInput();
    }
    private void playerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastHorizontal", movement.x);
        }

    }
    public void FireWeapon()
    {
        //shoots prefab, tracks position and rotation of the tip of the weapon
        GameObject bullet = Instantiate(bulletPrefab, weaponBarrel.position, weaponBarrel.rotation);

        //Plays audio when called
        //audioSource.clip = clip;
        //audioSource.Play();
    }

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

            SceneManager.LoadScene("Main Menu");

            //Reloads Current Scene
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}

