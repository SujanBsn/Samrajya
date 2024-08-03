using MoreMountains.Feedbacks;
using System.Collections;
using UnityEngine;


public class CannonController : MonoBehaviour
{
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

    //private void OnTriggerExit(Collider other)
    //{
    //    lookAtFeedBack.StopFeedbacks();
    //}

    IEnumerator ShootCannon()
    {
        yield return new WaitForSeconds(3f);
        GameObject _cannonBall = Instantiate(cannonBall);
        _cannonBall.transform.position = firePos.transform.position;
        _cannonBall.GetComponent<Rigidbody>().velocity = (target.transform.position - firePos.transform.position) * firePower;

        lookAtFeedBack.StopFeedbacks();
        lookAtFeedBack.enabled = false;
    }
}
