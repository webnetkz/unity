using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveProgress : MonoBehaviour
{

  public Button levelTwoBtn;
  public Button levelThreeBtn;

  public float bestTimeLevelOne;
  public float bestTimeLevelTwo;
  public float bestTimeLevelThree;

  public bool levelOne;
  public bool levelTwo;
  public bool levelThree;


  void Start()
  {
    LoadGame();
  }

  public void SaveGame()
  {
    BinaryFormatter bf = new BinaryFormatter(); 
    FileStream file = File.Create(Application.persistentDataPath 
      + "/MySaveData.dat"); 
    SaveData data = new SaveData();

    data.savedBestTimeLevelOne = bestTimeLevelOne;
    data.savedBestTimeLevelTwo = bestTimeLevelTwo;
    data.savedBestTimeLevelThree = bestTimeLevelThree;

    data.savedLeveOne = levelOne;
    data.savedLevelTwo = levelTwo;
    data.savedLevelThree = levelThree;

    bf.Serialize(file, data);
    file.Close();
    Debug.Log("Игра сохранена!");
  }

  public void LoadGame()
  {
    if (File.Exists(Application.persistentDataPath 
      + "/MySaveData.dat"))
    {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = 
        File.Open(Application.persistentDataPath 
        + "/MySaveData.dat", FileMode.Open);
      SaveData data = (SaveData)bf.Deserialize(file);
      file.Close();

      bestTimeLevelOne = data.savedBestTimeLevelOne;
      bestTimeLevelTwo = data.savedBestTimeLevelTwo;
      bestTimeLevelThree = data.savedBestTimeLevelThree;

      levelOne = data.savedLeveOne;
      levelTwo = data.savedLevelTwo;
      levelThree = data.savedLevelThree;

      if(levelOne) {
        levelTwoBtn.interactable = true;
      }

      if(levelTwo) {
        levelThreeBtn.interactable = true;
      }

      Debug.Log("Сохранения игры загружены!");
    }
    else
      Debug.LogError("There is no save data!");
  }

  public void ResetData()
  {
    if (File.Exists(Application.persistentDataPath 
      + "/MySaveData.dat"))
    {
      File.Delete(Application.persistentDataPath 
        + "/MySaveData.dat");

      bestTimeLevelOne = 0.0f;
      bestTimeLevelTwo = 0.0f;
      bestTimeLevelThree = 0.0f;

      levelOne = false;
      levelTwo = false;
      levelThree = false;

      Debug.Log("Сбросить игровые сохранения!");
    }
    else
      Debug.LogError("Произошла ошибка при сохранении игры.");
  }
}


[Serializable]
class SaveData
{
  public float savedBestTimeLevelOne;
  public float savedBestTimeLevelTwo;
  public float savedBestTimeLevelThree;

  public bool savedLeveOne;
  public bool savedLevelTwo;
  public bool savedLevelThree;
}