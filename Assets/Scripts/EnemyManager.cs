using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> ememies;
    [SerializeField] private int speed;
    [SerializeField] private int enemyCount = 4;
    [SerializeField] private float direction;
    
    public GameObject enemy01;
    public GameObject enemy02;
    public GameObject enemy03;
    public GameObject enemy04;

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
        ememies = new List<Enemy>();
        
    }
}
