using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class Enemy_Boss_Script : MonoBehaviour
{
    public SoldierPositionObject playerSoldierObject;
    public TextMeshPro enemySoldierCountText;
    public int enemySoldierCount;
    public MMF_Player ExitFeedBack;


    public GameObject endPopup;
    public TextMeshProUGUI endMessage;

    private void Start()
    {
        enemySoldierCountText.text = enemySoldierCount.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("King"))
        {
            int _playerSoldierCount = playerSoldierObject.soldierCount;
            if (_playerSoldierCount > enemySoldierCount)
            {
                endMessage.text = "<color=green>You Win!</color>";
                Debug.Log("Win!");
            }
            else
            {
                endMessage.text = "<color=red>You Lose!</color>";
                Debug.Log("Loss!");
            }

            endPopup.SetActive(true);
        }
    }


    public void ReplayButton()
    {
        ExitFeedBack.FeedbacksList.RemoveAt(0);
        ExitFeedBack.PlayFeedbacks();
    }

    public void ExitButton()
    {
        ExitFeedBack.FeedbacksList.RemoveAt(1);
        ExitFeedBack.PlayFeedbacks();
    }
}
