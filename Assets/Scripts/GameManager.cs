using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerLives;
    private void Reset()
    {
        Debug.Log("Reset");
    }
}
