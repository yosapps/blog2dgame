using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
  public contentObject[] sentences;
  private DialogManager dialogManager;

  [System.Serializable]
  public class contentObject
  {
    public string showName;
    [TextArea(3, 10)]
    public string sentence;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.E) && dialogManager != null)
    {
      if (dialogManager.checkNextContent())
      {
        dialogManager.DisplayNextSentence();
      }
      else
      {
        dialogManager.StartDialogue(this);
        dialogManager.DisplayNextSentence();
      }
    }
  }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      dialogManager = other.gameObject.GetComponent<DialogManager>();
      dialogManager.StartDialogue(this);
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      dialogManager.EndDialogue();
      dialogManager = null;
    }
  }
}
