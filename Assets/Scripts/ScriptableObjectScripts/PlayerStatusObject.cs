using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatusObject",menuName = "ScriptableObjects/PlayerStatusObject")]
public class PlayerStatusObject : ScriptableObject
{
    public LevelDescription currentLevel;
}

public struct LevelDescription
{
    int ScenarioNumber;
    int LevelNumber;
    int SubLevelNumber;
}