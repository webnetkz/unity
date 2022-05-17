using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedLevel : MonoBehaviour
{
  public GameObject completedLevelOne;

  private bool levelOneNow;
  private SaveProgress saveProgress;
  
  void Start()
  {
    GameObject _go = GameObject.Find("Camera");
    saveProgress = _go.GetComponent<SaveProgress>();

    saveProgress.levelOne = true;
    saveProgress.SaveGame();
  }

  void OnTriggerEnter(Collider other)
  {
    if(other.tag == "Player")
    {
      Time.timeScale = 0;
      Cursor.visible = true;
      completedLevelOne.SetActive(true);
    }
  }

  public void LoadLevelTwo()
  {
    SceneManager.LoadScene(1);
  }
}
