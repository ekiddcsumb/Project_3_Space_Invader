using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private int speed;
    public int enemyCount = 0;
    [SerializeField] private float up;
    [SerializeField] private float down;
    
    public Enemy enemy01;
    public Enemy enemy02;
    public Enemy enemy03;
    public Enemy enemy04;
    

    private void Awake()
    {
        InstantiateEnemies();
    }

    private void Start()
    {
        
        
    }

    public void Shoot(GameObject bullet, Transform shootingOffset)
    {
        // Use random to randomly select an enemy from the 
        // enemy list and make it shoot.
        
        GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
        
        Destroy(shot, 3f);
    }
    
    // Make a method that instantiates the enemies in the enemy list.
    // The method will keep track of how many enemies are alive,
    // and remove enemies that have been killed.

    void InstantiateEnemies()
    {
        // Instantiate(enemy01, Vector3.zero, Quaternion.identity);

        for (int x = -4; x < 6; x += 2)
        {
            // Instantiate(enemy01, new Vector3(x, 4, 0), Quaternion.identity);
            enemies.Add(Instantiate(enemy01, new Vector3(x, 4, 0), Quaternion.identity));
            enemyCount++;
            enemies.Add(Instantiate(enemy02, new Vector3(x, 3, 0), Quaternion.identity));
            enemyCount++;
            enemies.Add(Instantiate(enemy03, new Vector3(x, 2, 0), Quaternion.identity));
            enemyCount++;
            enemies.Add(Instantiate(enemy04, new Vector3(x, 1, 0), Quaternion.identity));
            enemyCount++;
            Debug.Log("Enemies: " + enemies);
        }
    }
}
