using TMPro;
using UnityEngine;

public class SoldierCountDisplay : MonoBehaviour
{
    public TextMeshPro soldierCountText;
    public EventTagObject eventTags;

    public void UpdatePlayerSoldierCount(Component sender, object data, string tag)
    {
        if (tag == eventTags.soldierCountTag)
            soldierCountText.text = data.ToString();
    }
}
