using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneSelectorButtonHandler : MonoBehaviour, IButtonAction
{
    public string sceneName;

    public void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
