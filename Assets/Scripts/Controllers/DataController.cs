using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataController : MonoBehaviour
{
  public int crystalCount = 0;
  private TextMeshProUGUI crystalUI;
  void Awake()
  {
    crystalUI = GameObject.Find("CrystalCount").GetComponent<TextMeshProUGUI>();
    DontDestroyOnLoad(this);
  }
  public void addCrystal(int getCrystal)
  {
    crystalCount += getCrystal;
    crystalUI.text = crystalCount.ToString();
  }

  public void updateCrystalUI(GameObject objCrystalUI)
  {
    crystalUI = objCrystalUI.GetComponent<TextMeshProUGUI>();
    crystalUI.text = crystalCount.ToString();
  }
}
