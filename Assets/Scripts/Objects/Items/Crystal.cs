using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
  public int crystalIncrease = 1;
  public AudioClip soundItem;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      GameObject.Find("DataController").GetComponent<DataController>().addCrystal(crystalIncrease);
      other.gameObject.GetComponent<AudioSource>().PlayOneShot(soundItem);
      Destroy(this.gameObject);
    }
  }
}
