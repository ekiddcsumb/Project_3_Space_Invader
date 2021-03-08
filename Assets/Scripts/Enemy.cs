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
    
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");

      if (collision.gameObject.name != "EnemyBullet(Clone)")
      {
          _scoreManager.AddScore(gameObject.GetComponent<Enemy>().points);
      
          Destroy(collision.gameObject);
          Destroy(gameObject);

          manager.speed += .1f;
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
