using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,  IComparable
{
    public int points;

    public GameObject bullet;
    
    public Transform shootingOffset;

    public EnemyManager manager;

    public ScoreManager _scoreManager;

    public Animator animator;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "EnemyBullet(Clone)")
      {
          animator.SetBool("isDead", true);
          _scoreManager.AddScore(gameObject.GetComponent<Enemy>().points);
      
          Destroy(collision.gameObject);
          Destroy(gameObject);

          manager.speed += .2f;
          manager.enemyCount--;
      }
    }

    private void Update()
    {
        // manager.Shoot(bullet);
    }

    public int CompareTo(object obj)
    {
        return 0;
    }
}
