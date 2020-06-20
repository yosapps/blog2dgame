using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
  public bool moveStatus = true;
  public Transform positionStart;
  public Transform positionEnd;
  public float speedMovement = 3f;
  private Vector3 nextPos;
  private Vector3 firstPosition;

  void Start()
  {
    if (moveStatus)
    {
      transform.position = positionStart.position;
      nextPos = positionEnd.position;
    }
    firstPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if (moveStatus)
    {
      if (transform.position == positionStart.position) { nextPos = positionEnd.position; }
      if (transform.position == positionEnd.position) { nextPos = positionStart.position; }
      transform.position = Vector3.MoveTowards(transform.position, nextPos, speedMovement * Time.deltaTime);
    }
  }

  public void Reset()
  {
    moveStatus = false;
    transform.position = positionStart.position;
    nextPos = positionEnd.position;
  }

  private void OnDrawGizmos()
  {
    if (positionStart && positionEnd)
      Gizmos.DrawLine(positionStart.position, positionEnd.position);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      if (other.gameObject.GetComponent<CharacterController2D>().isGrounded())
      {
        other.gameObject.transform.parent = this.gameObject.transform;
      }
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      other.gameObject.transform.parent = null;
    }
  }

  public Vector3 getFirstPosition()
  {
    return firstPosition;
  }
}
