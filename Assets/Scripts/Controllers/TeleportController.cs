using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
  public AudioClip soundItem;
  public GameObject TeleportDestination;
  public bool isTeleportEnable = true;
  public float delayMovePlayer = 1f;
  private PlayerMovement objPlayer;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player") && isTeleportEnable)
    {
      TeleportDestination.GetComponent<TeleportController>().isTeleportEnable = false;
      other.gameObject.GetComponent<AudioSource>().PlayOneShot(soundItem);
      other.gameObject.transform.position = TeleportDestination.transform.position;
      objPlayer = other.gameObject.GetComponent<PlayerMovement>();
      objPlayer.stopMovingPlayer();
      StartCoroutine(disablePlayerMove());
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      isTeleportEnable = true;
    }
  }

  IEnumerator disablePlayerMove()
  {
    yield return new WaitForSeconds(delayMovePlayer);
    objPlayer.startMovingPlayer();
  }
}
