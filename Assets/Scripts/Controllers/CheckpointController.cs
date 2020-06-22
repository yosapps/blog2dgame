using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
  public AudioClip soundItem;
  private bool isChecked = false;
  private GameController objGameController;


  private void Start()
  {
    objGameController = GameObject.Find("GameController").GetComponent<GameController>(); ;
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player") && !isChecked)
    {
      objGameController.updateRespawnPosition(this.gameObject);
      other.gameObject.GetComponent<AudioSource>().PlayOneShot(soundItem);
      isChecked = true;
    }
  }
}
