using TMPro;
using UnityEngine;

public class SoldierCountDisplay : MonoBehaviour
{
    public TextMeshPro soldierCountText;

    public void UpdatePlayerSoldierCount(Component sender, object data, EventTags tag)
    {
        if (tag == EventTags.soldierCountTag)
            soldierCountText.text = data.ToString();
    }
}
