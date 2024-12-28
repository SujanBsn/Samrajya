using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionButtonHandler : MonoBehaviour, IButtonAction
{
    [Header("Level Data")]
    public string sceneName;
    public int levelNumber;

    [Header("Player Data")]
    public PlayerDataObject playerDataObject;

    public void OnButtonClick()
    {
        if (playerDataObject.PlayerData.levelNumber < levelNumber)
        {
            Debug.Log($"Level {levelNumber} not unlocked!");
            return;
        }
        else
        {
            Debug.Log($"Loading level {levelNumber}!");
            SceneManager.LoadScene(sceneName);
        }
    }
}
