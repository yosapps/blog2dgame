using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
  public GameObject[] cloudObjects;
  public float minDetay;
  public float maxDelay;

  private float nextAttackDelay;
  private Collider2D spawnPlace;
  void Start()
  {
    nextAttackDelay = Random.Range(minDetay, maxDelay);
    spawnPlace = GetComponent<Collider2D>();
  }

  // Update is called once per frame
  void Update()
  {
    nextAttackDelay = nextAttackDelay - Time.deltaTime;
    if (nextAttackDelay < 0)
    {
      float x = Random.Range(spawnPlace.bounds.center.x - spawnPlace.bounds.extents.x, spawnPlace.bounds.center.x + spawnPlace.bounds.extents.x);
      float y = Random.Range(spawnPlace.bounds.center.y - spawnPlace.bounds.extents.y, spawnPlace.bounds.center.y + spawnPlace.bounds.extents.y);
      Instantiate(cloudObjects[Random.Range(0, cloudObjects.Length)], new Vector3(x, y, 0), Quaternion.identity);
      nextAttackDelay = Random.Range(minDetay, maxDelay);
    }
  }
}
