using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUp : MonoBehaviour {
  public GameObject _obj;
  private Vector3 offset;

  void Start() {
    offset = transform.position - _obj.transform.position;
  }
  
  void FixedUpdate() {
    transform.position = _obj.transform.position + offset;
  }
}
