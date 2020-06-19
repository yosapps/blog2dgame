using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
  public float minSpeed;
  public float maxSpeed;
  private float moveSpeed;
  void Start()
  {
    moveSpeed = Random.Range(minSpeed, maxSpeed);
  }
  void Update()
  {
    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
  }
}
