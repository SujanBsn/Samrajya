using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    /// <summary>
    /// Starts the first game scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("1_1");
    }
}
