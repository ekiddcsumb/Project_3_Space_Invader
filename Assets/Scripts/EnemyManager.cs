using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies;
    public int speed;
    public int enemyCount = 0;
    [SerializeField] private float direction;

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

    private void Update()
    {
        MoveEnemies();
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

    void MoveEnemies()
    {
        // Based on current direction, iterate through enemy
        // list and move until max or min approaches certain
        // coordinate in game space.
        // Once min/max hits that point, go down, then opposite direction.
        // For max, must hit x = 5. x= -5 for min.

        foreach (var enemy in enemies)
        {
            // var position = enemy.transform.position;
            
            if (!enemy.Equals(null))
            {
                Vector3 minPosition = new Vector3(-5, enemy.transform.position.y, 0);
                Vector3 maxPosition = new Vector3(5, enemy.transform.position.y, 0);
                
                // enemy.transform.Translate(Vector3.left * Time.deltaTime * speed);

                if (!enemy.transform.position.Equals(minPosition))
                {
                    enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, minPosition, Time.deltaTime * speed);
                    
                    // enemy.transform.Translate(Vector3.right * Time.deltaTime * speed);
                }
                else
                {
                    enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, maxPosition, Time.deltaTime * speed);
                }
                
                // if (transform.position.Equals(maxPosition))
                // {
                //     enemy.transform.Translate(Vector3.down * Time.deltaTime * speed);
                //     enemy.transform.Translate(Vector3.left * Time.deltaTime * speed);
                // }
            }
        }
    }
}
