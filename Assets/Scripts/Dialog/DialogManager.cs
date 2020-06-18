using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
  public GameObject DialogPanel;
  public TextMeshProUGUI nameText;
  public TextMeshProUGUI dialogueText;
  public float timeNext = 0.05f;
  private Queue<Dialog.contentObject> sentences;
  private Dialog.contentObject nextDialog;

  void Start()
  {
    sentences = new Queue<Dialog.contentObject>();
  }

  public void StartDialogue(Dialog dialogue)
  {
    sentences.Clear();
    foreach (Dialog.contentObject content in dialogue.sentences)
    {
      sentences.Enqueue(content);
    }
  }

  public void DisplayNextSentence()
  {
    DialogPanel.SetActive(true);
    if (sentences.Count == 0)
    {
      EndDialogue();
      return;
    }
    nextDialog = sentences.Dequeue();
    nameText.text = nextDialog.showName;
    string sentence = nextDialog.sentence;
    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence));
  }

  IEnumerator TypeSentence(string sentence)
  {
    dialogueText.text = "";
    foreach (char letter in sentence.ToCharArray())
    {
      dialogueText.text += letter;
      yield return new WaitForSeconds(timeNext);
    }
  }

  public bool checkNextContent()
  {
    if (sentences.Count == 0 && !DialogPanel.activeSelf)
    {
      return false;
    }
    else
    {
      return true;
    }
  }

  public void EndDialogue()
  {
    DialogPanel.SetActive(false);
  }
}
