using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
  public GameObject dataController;
  void Start()
  {
    if (!GameObject.Find("DataController"))
    {
      GameObject dataObject = Instantiate(dataController) as GameObject;
      dataObject.name = "DataController";
    }
  }
}
