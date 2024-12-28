using System;
using UnityEngine;

public class ScenarioSelectionButtonHandler : MonoBehaviour, IButtonAction
{
    [Header("Scenario Data")]
    public int scenarioNumber;

    [Header("Player Data")]
    public PlayerDataObject playerDataObject;

    public void OnButtonClick()
    {
        // Don't do anything if scenario not unlocked
        if (playerDataObject.PlayerData.scenarioNumber < scenarioNumber)
        {
            Debug.Log($"Scenario {scenarioNumber} is not unlocked.");
            return;
        }

        if (this.gameObject.TryGetComponent<SimplePageScroll>(out SimplePageScroll pageScroller))
        {
            Debug.Log($"Loading Scenario {scenarioNumber}");
            pageScroller.ScrollPage();
        }
        else
        {
            Debug.Log("Scroller not found!");
        }
    }
}
 