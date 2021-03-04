using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public GameObject player;

  public Transform shootingOffset;
    // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
      Debug.Log("Bang!");

      Destroy(shot, 3f);

    }
  }

  private void OnCollisionEnter(Collision other)
  {
    Destroy(bullet);
    Destroy(player);
  }
}
