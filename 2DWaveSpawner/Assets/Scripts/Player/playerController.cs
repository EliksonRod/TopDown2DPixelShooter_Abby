using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public GameObject bulletPrefab;
    public GameObject[] bulletTypes;
    public Transform weaponBarrel;
    public float bulletVelocity = 20f;

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
        movement.y = Input.GetAxisRaw("Vertical");

        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastHorizontal",movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }
        
    }
    public void FireWeapon()
    {
        //shoots prefab, tracks position and rotation of the tip of the weapon
        GameObject bullet = Instantiate(bulletPrefab, weaponBarrel.position, weaponBarrel.rotation);

        //the speed the bullet travels
        bullet.GetComponent<Rigidbody2D>().AddForce(weaponBarrel.up * bulletVelocity, ForceMode2D.Impulse);

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
