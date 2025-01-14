using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float health, maxHealth = 3;
    [SerializeField] private float speed = 1.5f;

    private GameObject player;

    GameController gameController;
    private float scoreAddAmount = 10;
    InfiniteWaves spawn;

    //[SerializeField] Transform target;

    NavMeshAgent agent;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawn = gameController.GetComponentInChildren<InfiniteWaves>();
        health = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    /*void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }*/
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;//3->2->1->0=Enemy has died

        if (health <= 0)
        {
            Destroy(gameObject);
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
        ScoreManager.instance.AddPoint();

        gameController.AddScore(scoreAddAmount);

        spawn.enemiesRemaining--;
        spawn.enemiesKilled++;

    }
}
