using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public float speedModifier = 1;

  public Transform shootingOffset;

  public Animator animator;
    // Update is called once per frame
  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    transform.Translate(transform.right * horizontal * speedModifier * Time.deltaTime);
    
    if (Input.GetKeyDown(KeyCode.Space))
    {
      animator.SetBool("Shooting", true);
      GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);

      Destroy(shot, 3f);

    }
    else
    {
      animator.SetBool("Shooting", false);
    }
  }
  
  private void OnCollisionEnter2D(Collision2D collision2D)
  {
    
    Destroy(collision2D.gameObject);
    Destroy(gameObject);
  }
}
