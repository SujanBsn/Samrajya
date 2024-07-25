using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EscapeUI : MonoBehaviour
{
    private Button _exit;
    // Start is called before the first frame update
    void Start()
    {
       var root = GetComponent<UIDocument>();
       _exit = root.rootVisualElement.Q("ExitButton") as Button;
       _exit.RegisterCallback<ClickEvent>(LoadEndPage);
        

    }

    private void LoadEndPage(ClickEvent e)
    {
        Debug.Log("Clicked the exit button");
        Debug.Log("Load the end page");
        SceneManager.LoadSceneAsync("EndPage");

    }
  
}
