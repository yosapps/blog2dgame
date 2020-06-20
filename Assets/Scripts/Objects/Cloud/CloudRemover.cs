using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRemover : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Cloud"))
    {
      Destroy(other.gameObject);
    }
  }
}
