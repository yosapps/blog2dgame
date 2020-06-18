using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
  public float timeNext = 0.05f;
  private GameObject DialogPanel;
  private TextMeshProUGUI nameText;
  private TextMeshProUGUI dialogueText;
  private Queue<Dialog.contentObject> sentences;
  private Dialog.contentObject nextDialog;

  void Start()
  {
    sentences = new Queue<Dialog.contentObject>();
    DialogPanel = GameObject.Find("Dialog").transform.Find("DialogPanel").gameObject;
    nameText = DialogPanel.transform.Find("DialogBox").transform.Find("name").gameObject.GetComponent<TextMeshProUGUI>();
    dialogueText = DialogPanel.transform.Find("DialogBox").transform.Find("content").gameObject.GetComponent<TextMeshProUGUI>();
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
