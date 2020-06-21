using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataController : MonoBehaviour
{
  public int crystalCount = 0;
  private TextMeshProUGUI crystalUI;
  void Start()
  {
    crystalUI = GameObject.Find("CrystalCount").GetComponent<TextMeshProUGUI>();
    DontDestroyOnLoad(this.gameObject);
  }
  public void addCrystal(int getCrystal)
  {
    crystalCount += getCrystal;
    crystalUI.text = crystalCount.ToString();
  }
}
