using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    public float speed;
    public int enemyCount = 0;
    [SerializeField] private Vector3 direction;

    public Enemy enemy01;
    public Enemy enemy02;
    public Enemy enemy03;
    public Enemy enemy04;

    static int minX = -5;
    static int maxX = 5;

    int xDirection = minX;
    
    private bool down;

    private void Awake()
    {
        InstantiateEnemies();
    }

    private void Start()
    {
        foreach (var enemy in enemies)
        {
            direction = new Vector3(-5, enemy.transform.position.y, 0);
        }

        down = false;
    }

    private void Update()
    {
        // Remove enemy once destroyed.
        foreach (var enemy in enemies)
        {
            if (enemy.Equals( null))
            {
                enemies.Remove(enemy);
            }
        }

        float randTime = Random.Range(10, 50);
        Invoke(nameof(Shoot), randTime);
        MoveEnemies();
    }

    public void Shoot()
    {
        // Use random to randomly select an enemy from the 
        // enemy list and make it shoot.

        int randEnemy = Random.Range(0, enemies.Count);
        GameObject shot = Instantiate(enemies[randEnemy].bullet, enemies[randEnemy].shootingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);
    }

    // Make a method that instantiates the enemies in the enemy list.
    // The method will keep track of how many enemies are alive,
    // and remove enemies that have been killed.

    void InstantiateEnemies()
    {
        for (int x = -4; x < 6; x += 2)
        {
            enemies.Add(Instantiate(enemy01, new Vector3(x, 4, 0), Quaternion.identity));
            enemyCount++;
            enemies.Add(Instantiate(enemy02, new Vector3(x, 3, 0), Quaternion.identity));
            enemyCount++;
            enemies.Add(Instantiate(enemy03, new Vector3(x, 2, 0), Quaternion.identity));
            enemyCount++;
            enemies.Add(Instantiate(enemy04, new Vector3(x, 1, 0), Quaternion.identity));
            enemyCount++;
        }
    }

    void MoveEnemies()
    {
        // Based on current direction, iterate through enemy
        // list and move until max or min approaches certain
        // coordinate in game space.
        // Once min/max hits that point, go down, then opposite direction.
        // For max, must hit x = 5. x= -5 for min.
        
        foreach (var enemy in enemies)
        {
            if (!enemy.Equals(null))
            {
                Vector3 minPosition = new Vector3(minX, enemy.transform.position.y, 0);
                Vector3 maxPosition = new Vector3(maxX, enemy.transform.position.y, 0);

                if (enemy.transform.position.Equals(minPosition))
                {
                    xDirection = maxX;
                    // enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y - .1f, 0);
                    down = true;
                }

                if (enemy.transform.position.Equals(maxPosition))
                {
                    xDirection = minX;
                    // enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y - .1f, 0);
                    down = true;
                }
                
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, 
                    new Vector3(xDirection, enemy.transform.position.y, 0), Time.deltaTime * speed);
            }
        }

        if (down)
        {
            foreach (var enemy in enemies)
            {
                enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y - .1f, 0);
            }
            down = false;
        }
    }
}
