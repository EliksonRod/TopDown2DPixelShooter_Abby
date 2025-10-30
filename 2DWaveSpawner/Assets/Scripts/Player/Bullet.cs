using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullet;


    public float normalBulletSpeed = 15f;
    public float normalBulletDamage = 1f;


    public float shotgunBulletSpeed = 12.5f;
    public float bulletGravity = 3f;
    public float shotgunBulletDamage = 2f;


    private Rigidbody2D rb;
    private float damage;

    public enum BulletType
    {
        Normal,
        Shotgun
    }
    public BulletType bulletType;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        SetDestroyTime();

        SetRbStats();

        InitializeBulletStats();
    }

    private void InitializeBulletStats()
    {
        if (bulletType == BulletType.Normal)
        {
            normalBulletVelocity();
            damage = normalBulletDamage;
        }
        else if (bulletType == BulletType.Shotgun)
        {
            shotgunBulletVelocity();
            damage = shotgunBulletDamage;
        }
    }
  

    private void normalBulletVelocity()
    {
        rb.linearVelocity = transform.right * normalBulletSpeed;
    }
    private void shotgunBulletVelocity()
    {
        rb.linearVelocity = transform.right * normalBulletSpeed;
    }

    private void SetRbStats()
    {
        if (bulletType == BulletType.Normal)
        {
            rb.gravityScale = 0f;
        }
        else if (bulletType == BulletType.Shotgun) {
            rb.gravityScale = bulletGravity;
        }
    }
            
    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) > 0)
        {

            //Damage Target
            IDamagable iDamagable = collision.gameObject.GetComponent<IDamagable>();
            if (iDamagable != null)
            {
                iDamagable.Damage(damage);
            }


            //Destroys Bullet
            Destroy(gameObject);
        }
    }
}
