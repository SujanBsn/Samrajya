using TMPro;
using UnityEngine;

public class CoinsDisplay : MonoBehaviour
{
    public TextMeshProUGUI coinCount;
    public CoinObject coinObject;

    private void Start()
    {
        coinObject.currentCoin = 0;
        coinCount.text = "0";
    }

    public void UpdateCoinCount(Component sender, object data, EventTags tag)
    {
        coinObject.currentCoin += (int)data;
        coinCount.text = coinObject.currentCoin.ToString();
    }
}
