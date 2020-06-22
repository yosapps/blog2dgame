using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
  public int attackDamage = 1;
  public float moveSpeed = 2f;
  public float timeDestroy = 2f;

  public void shotStart()
  {
    StartCoroutine(setTimeDestroy());
  }
  void Update()
  {
    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
  }

  IEnumerator setTimeDestroy()
  {
    yield return new WaitForSeconds(timeDestroy);
    Destroy(this.gameObject);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      StartCoroutine(other.gameObject.GetComponent<PlayerMovement>().DeadPlayer());
    }
  }

}
