using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

  [SerializeField] private GameObject mainMenu;

  public GameObject mainSettings;
  public GameObject mainLevels;

  private bool showMenu;

  private void Start()
  {
    showMenu = false;
    Cursor.visible = false;
  }

  public void Update()
  {
    if(Input.GetKeyDown(KeyCode.Escape))
    {
      if(showMenu) {
        Continue();
        showMenu = false;
      } else {
        Pause();
        showMenu = true;
      }
    }
  }

  public void LoadLeveOne()
  {
    Continue();
    SceneManager.LoadScene(0);
  }

  public void LoadLeveTwo()
  {
    Continue();
    SceneManager.LoadScene(1);
  }

  public void LoadLeveThree()
  {
    Continue();
    SceneManager.LoadScene(2);
  }

  public void Pause()
  {
    mainMenu.SetActive(true);
    Time.timeScale = 0;
    Cursor.visible = true;
  }

  public void Continue()
  {
    mainMenu.SetActive(false);
    Time.timeScale = 1;
    Cursor.visible = false;
    mainSettings.SetActive(false);
    mainLevels.SetActive(false);
  }


  public void ShowSettings()
  {
    mainMenu.SetActive(false);
    mainSettings.SetActive(true);
  }

  public void CloseSettings()
  {
    mainMenu.SetActive(true);
    mainSettings.SetActive(false);
  }

  public void ShowLevels()
  {
    mainMenu.SetActive(false);
    mainSettings.SetActive(false);
    mainLevels.SetActive(true);
  }

  public void CloseLevels()
  {
    mainMenu.SetActive(true);
    mainSettings.SetActive(false);
    mainLevels.SetActive(false);    
  }

  public void ExitApp()
  {
    Application.Quit();
  }
}