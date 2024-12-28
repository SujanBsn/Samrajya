[System.Serializable]
public class PlayerData
{
    public string playerId;                       // Unique identifier for the player
    public string displayName;                    // Player's display name
    public int coins;                             // Player's coins

    public int scenarioNumber;
    public int levelNumber;

    public PlayerData(
        string playerId = null,
        string displayName = "Guest",
        int coins = 0,
        int scenarioNumber = 1,
        int levelNumber = 1
    )
    {
        this.playerId = playerId ?? System.Guid.NewGuid().ToString(); // Generate ID if none provided
        this.displayName = displayName;
        this.coins = coins;
        this.scenarioNumber = scenarioNumber;
        this.levelNumber = levelNumber;
    }
}
