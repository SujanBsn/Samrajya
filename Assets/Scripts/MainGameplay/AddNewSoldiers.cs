using TMPro;
using UnityEngine;

public class AddNewSoldiers : MonoBehaviour
{
    public GameEvent addSoldierEvent;
    public TextMeshPro soldierText;
    public int soldierAddCount;
    public float soldierAddDelay;

    private void Start()
    {
        soldierText.text = soldierAddCount.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("King"))
        {
            float[] soldierSpawnData = { soldierAddCount, soldierAddDelay };
            addSoldierEvent.Raise(this, soldierSpawnData, EventTags.AddSoldierTag);
            gameObject.SetActive(false);
        }
    }
}
