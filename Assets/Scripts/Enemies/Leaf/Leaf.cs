using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
  public GameObject attackBall;
  public Transform attackPosition;
  public float attackMaxDelay = 4f;
  public float attackMinDelay = 2f;
  public float timeBallDestroy = 2f;

  private float nextAtackDelay = 0f;
  private GameObject objAttackBall;

  void Start()
  {
    nextAtackDelay = Random.Range(attackMinDelay, attackMaxDelay);
  }

  // Update is called once per frame
  void Update()
  {
    nextAtackDelay = nextAtackDelay - Time.deltaTime;
    if (nextAtackDelay < 0f)
    {
      nextAtackDelay = Random.Range(attackMinDelay, attackMaxDelay);
      objAttackBall = Instantiate(attackBall, attackPosition.position, Quaternion.identity) as GameObject;
      objAttackBall.GetComponent<AttackBall>().timeDestroy = timeBallDestroy;
      objAttackBall.GetComponent<AttackBall>().shotStart();
    }
  }
}
