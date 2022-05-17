using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
  public GameObject _obj;
      
  void FixedUpdate() {
    transform.LookAt(_obj.transform);
  }

}
