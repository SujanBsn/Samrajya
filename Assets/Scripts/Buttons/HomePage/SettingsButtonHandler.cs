using UnityEngine;

public class SettingsButtonHandler : MonoBehaviour, IButtonAction
{
    [SerializeField]
    GameObject settingsUI;
    public void OnButtonClick()
    {
        settingsUI.SetActive(true);
    }
}
