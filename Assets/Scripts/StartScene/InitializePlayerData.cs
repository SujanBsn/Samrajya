using UnityEngine;

public class InitializePlayerData : MonoBehaviour
{
    [SerializeField]
    private PlayerDataObject playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData.Initialize();
    }
}
