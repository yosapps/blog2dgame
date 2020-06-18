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
  private Queue<string> sentences;

  // Start is called before the first frame update
  void Start()
  {
    sentences = new Queue<string>();
  }

  public void StartDialogue(Dialog dialogue)
  {
    nameText.text = dialogue.nameDialog;
    sentences.Clear();

    foreach (string sentence in dialogue.sentences)
    {
      sentences.Enqueue(sentence);
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

    string sentence = sentences.Dequeue();
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
