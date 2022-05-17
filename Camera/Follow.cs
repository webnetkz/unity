using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
  public GameObject _from;
  public GameObject _to;
  public float x;
  public float y;
  public float z;


  private void Update() {
    _from.transform.position = _to.transform.position + new Vector3(z, y, z);
  }
}