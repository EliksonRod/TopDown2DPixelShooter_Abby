using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float _playerAwarenessDistance;

    [SerializeField]
    private float health, maxHealth = 3;

    private Rigidbody2D _rigidbody;
    private Vector2 _targetDirection;
    public bool AwareOfPlayer;
    public Vector2 DirectionToPlayer;

    private Transform player;

    GameController gameController;
    private float scoreAddAmount = 10;
    InfiniteWaves spawn;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spawn = gameController.GetComponentInChildren<InfiniteWaves>();
        health = maxHealth;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;//3->2->1->0=Enemy has died

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        UpdateTargetDIrection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDIrection()
    {
        if (AwareOfPlayer == true)
        {
            _targetDirection = DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody.velocity = transform.up * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
        }
    }

    void OnDestroy()
    {
        //if (GameObject.FindGameObjectWithTag("WaveSpawner") != null)
        //{
       //     GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().spawnedEnemies.Remove(gameObject);
       // }
        gameController.AddScore(scoreAddAmount);
        spawn.enemiesKilled++;

    }
}
