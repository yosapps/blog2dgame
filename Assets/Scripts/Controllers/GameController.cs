using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
  public GameObject dataController;
  public GameObject respawnPosition;
  private DataController objDataController;
  void Start()
  {
    if (!GameObject.Find("DataController"))
    {
      GameObject dataObject = Instantiate(dataController) as GameObject;
      dataObject.name = "DataController";
      objDataController = dataObject.GetComponent<DataController>();
    }
    else
    {
      objDataController = GameObject.Find("DataController").GetComponent<DataController>();
      objDataController.updateCrystalUI(GameObject.Find("CrystalCount"));
    }
  }

  public void updateRespawnPosition(GameObject newPositon)
  {
    respawnPosition = newPositon;
  }
}
