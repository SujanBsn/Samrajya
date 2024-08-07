using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeGameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Game Exited");
            SceneManager.LoadScene("StartPage");
        }
    }
}
