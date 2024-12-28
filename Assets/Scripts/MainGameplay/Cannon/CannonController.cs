using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MMF_Player))]
public class CannonController : MonoBehaviour
{
    public GameEvent cannonFireEvent;

    public MMF_Player lookAtFeedBack;

    public GameObject turret;
    public GameObject target;
    public GameObject firePos;
    public GameObject cannonBall;

    public float firePower;
    private void OnTriggerEnter(Collider other)
    {
        lookAtFeedBack.PlayFeedbacks();
        StartCoroutine(ShootCannon());
    }

    IEnumerator ShootCannon()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Fire!");
        GameObject _cannonBall = Instantiate(cannonBall);
        _cannonBall.transform.position = firePos.transform.position;
        _cannonBall.GetComponent<Rigidbody>().velocity = (target.transform.position - firePos.transform.position) * firePower;

        cannonFireEvent.Raise(this, _cannonBall.transform, EventTags.cannonBallFire);
        lookAtFeedBack.StopFeedbacks();
        lookAtFeedBack.enabled = false;
    }
}
