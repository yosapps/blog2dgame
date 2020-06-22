using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadController : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      StartCoroutine(other.gameObject.GetComponent<PlayerMovement>().DeadPlayer());
    }
  }
}
