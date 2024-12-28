using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeGameManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Game Exited");
            SceneManager.LoadScene("StartPage");
        }
    }
}
