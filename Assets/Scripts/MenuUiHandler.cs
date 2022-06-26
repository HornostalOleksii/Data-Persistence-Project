using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUiHandler : MonoBehaviour
{
  public GameObject ErrorText;
  
  public void UserNameEntered(string userName)
  {
    DataManager.Instance.UserName = userName;
  }

  public void StartNew()
  {
    if (string.IsNullOrWhiteSpace(DataManager.Instance.UserName))
      ErrorText.SetActive(true);
    else
      SceneManager.LoadScene(1);
  }

  public void Exit()
  {
    //MainManager.Instance.SaveColor(); 

#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
    Application.Quit(); // original code to quit Unity player
#endif
  }
}