using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private int speed;
    [SerializeField] private int enemyCount = 4;
    [SerializeField] private float direction;
    
    public Enemy enemy01;
    public Enemy enemy02;
    public Enemy enemy03;
    public Enemy enemy04;

    public Transform parentTransform;


    private void Awake()
    {
        enemies = new List<Enemy>();
        
        for (int i = 0; i < enemyCount; i++)
        {
            enemies.Add(enemy01);
            enemies.Add(enemy02);
            enemies.Add(enemy03);
            enemies.Add(enemy04);
            Debug.Log("Enemies: " + enemies);
        }

        // enemyCount = enemies.Count;
        // Debug.Log("Enemies: " + enemies);
    }

    private void Start()
    {
        InstantiateEnemies();
        Debug.Log("Enemies: " + enemies);
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
        Instantiate(enemy01, Vector3.zero, Quaternion.identity);

        for (int x = 0; x < enemyCount; x++)
        {
            Instantiate(enemy01, new Vector3(x, 0, 0), Quaternion.identity);
        }
        // Enemy toSpawn;
        // Vector3 positionToSpawn = Vector3.zero;
        //
        //
        // foreach (var enemy in enemies)
        // {
        //     Debug.Log("Enemies: " + enemies);
        //     toSpawn = Instantiate(enemy, parentTransform);
        //     toSpawn.transform.localPosition = positionToSpawn;
        //     positionToSpawn.x += 2;
        // }
    }
}
