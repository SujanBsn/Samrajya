using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvent : MonoBehaviour
{
    // Start is called before the first frame update
    private UIDocument document; //referencing to the document 
    private Button StartButton;
    private Button ExitButton;
    private VisualElement SamRajya;
    private void Awake()
    {
        document = GetComponent<UIDocument>();
        StartButton = document.rootVisualElement.Q("StartButton") as Button; //cast the returned visual element as button     
        StartButton.RegisterCallback<ClickEvent>(OnPlayGameClick); // register callback to the button ; load OnPlayGameClick and pass ClickEvent as parameter
        ExitButton = document.rootVisualElement.Q("ExitButton") as Button;
        ExitButton.RegisterCallback<ClickEvent>(QuitGame);

        SamRajya = document.rootVisualElement.Q("SamRajya") as VisualElement;
       

    }

    private void Start()
    {
        Invoke("Hover", 0.45f);
    }
    private void OnDisable()
    {
        StartButton.UnregisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("Pressed the Start!");
        SceneManager.LoadSceneAsync("1_1");
    }
    private void QuitGame(ClickEvent evt)
    {
        Debug.Log("Pressed the Exit!");
        Application.Quit();
        // This will only work in a built game, not in the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    private void Hover()
    {
        //Add or remove ".header--hover" in the SamRajya's class list
        SamRajya.ToggleInClassList("header--hover");

        Debug.Log("Hover started");

        //Add or remove ".header--hover" in the SamRajya's class list
        //when the transition ends
        SamRajya.RegisterCallback<TransitionEndEvent>
        (
            evt => SamRajya.ToggleInClassList("header--hover")
        );
    }
}