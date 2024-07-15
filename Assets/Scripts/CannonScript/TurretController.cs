using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    Transform _Player;
    float dist;
    public float howClose;
    public Transform head, barrel;
    public GameObject _projectile;
    public float fireRate;
    private bool isShooting = false;
    private int shotsFired = 0;
    public int maxShots = 5;

    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        dist = Vector3.Distance(_Player.position, transform.position);
        if (dist <= howClose && !isShooting)
        {
            StartCoroutine(ShootSequence());
        }
    }

    IEnumerator ShootSequence()
    {
        isShooting = true;
        while (shotsFired < maxShots)
        {
            // Update head rotation to face the player
            head.LookAt(_Player);
            shoot();
            shotsFired++;
            yield return new WaitForSeconds(1f); // Interval of 1 second between shots
        }
        isShooting = false;
        shotsFired = 0; // Reset shots fired for the next sequence
    }

    void shoot()
    {
        GameObject clone = Instantiate(_projectile, barrel.position, head.rotation);
        clone.GetComponent<Rigidbody>().AddForce(head.forward * 1500);
        Destroy(clone, 10);
    }
}

