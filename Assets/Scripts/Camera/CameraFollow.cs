using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform followTransform;
  // Update is called once per frame
  void FixedUpdate()
  {
    this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(followTransform.position.x, followTransform.position.y + 1.5f, this.transform.position.z), Time.deltaTime * 2f);
  }
}