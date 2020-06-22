using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public bool isCanMove = true;
  public float runSpeed = 40f;
  private float horizontalMove = 0f;
  private bool jump = false;
  private CharacterController2D controller;

  private void Awake()
  {
    controller = GetComponent<CharacterController2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (isCanMove)
    {
      horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
      if (Input.GetButtonDown("Jump"))
      {
        jump = true;
      }
    }
    else
    {
      horizontalMove = 0f;
    }
  }

  void FixedUpdate()
  {
    // Move our character
    controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
    jump = false;
  }

  public IEnumerator DeadPlayer()
  {
    stopMovingPlayer();
    transform.position = GameObject.Find("GameController").GetComponent<GameController>().respawnPosition.transform.position;
    yield return new WaitForSeconds(1f);
    startMovingPlayer();
  }

  public void stopMovingPlayer()
  {
    isCanMove = false;
  }

  public void startMovingPlayer()
  {
    isCanMove = true;
  }
}