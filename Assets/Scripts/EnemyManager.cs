using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Enemy> ememies;
    [SerializeField] private int speed;
    [SerializeField] private int enemyCount;
    [SerializeField] private float direction;
    
    public GameObject enemy01;
    public GameObject enemy02;
    public GameObject enemy03;
    public GameObject enemy04;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
