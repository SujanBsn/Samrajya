using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public MMF_Player loadingSceneFeedback;


    /// <summary>
    /// Starts the first game scene
    /// </summary>
    public void StartGame()
    {
        loadingSceneFeedback.PlayFeedbacks();
        //SceneManager.LoadScene("1_1");
    }

    /// <summary>
    /// Exits the game
    /// </summary>
    public void EndGame()
    {
        Application.Quit();
    }
}
