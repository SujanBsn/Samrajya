using TMPro;
using UnityEngine;

public class SoldierCountDisplay : MonoBehaviour
{
    public TextMeshPro soldierCountText;

    public void UpdateSoldierCount(Component sender, object data)
    {
        if (sender != null)
            soldierCountText.text = data.ToString();
    }
}
