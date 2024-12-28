using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

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
            MMF_Player feedbackPlayer = gameObject.GetComponent<MMF_Player>();
            MMF_LoadScene loadScene = feedbackPlayer.GetFeedbackOfType<MMF_LoadScene>();
            Debug.Log($"Loading level {levelNumber}!");

            feedbackPlayer.PlayFeedbacks();
            StartCoroutine(AddDestinationScene());
            //SceneManager.LoadScene(sceneName);
        }

        IEnumerator AddDestinationScene()
        {
            yield return new WaitForSeconds(5f);
            MMF_Player feedbackPlayer = gameObject.GetComponent<MMF_Player>();
            MMF_LoadScene loadScene = feedbackPlayer.GetFeedbackOfType<MMF_LoadScene>();

            feedbackPlayer.StopFeedbacks();
            Debug.Log($"Loading level {levelNumber} for real!");
            loadScene.DestinationSceneName = sceneName;
            loadScene.LoadingMode = MMF_LoadScene.LoadingModes.Direct;
            feedbackPlayer.PlayFeedbacks();
        }
    }
}
