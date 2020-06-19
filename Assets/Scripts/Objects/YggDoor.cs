using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YggDoor : MonoBehaviour
{
  public string nextScene;
  private bool isPlayerIn = false;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && isPlayerIn)
    {
      SceneManager.LoadScene(nextScene);
    }
  }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      GetComponent<Animator>().SetBool("isClose", true);
      isPlayerIn = true;
    }
  }
  void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      GetComponent<Animator>().SetBool("isClose", false);
      isPlayerIn = false;
    }
  }
}
