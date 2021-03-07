using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points;

    public GameObject bullet;
    
    public Transform shootingOffset;

    public EnemyManager manager;

    public ScoreManager _scoreManager;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");

      _scoreManager.AddScore(gameObject.GetComponent<Enemy>().points);
      
      Destroy(collision.gameObject);
      Destroy(gameObject);
    }

    private void Update()
    {
        // manager.Shoot(bullet, shootingOffset);
    }
}
