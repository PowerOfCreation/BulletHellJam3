using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyLogic : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float speed = 1f;

    public float distanceNeededToShoot = 5f;

    private Animator animator;
    private static int chargingHash;

    private bool isCharging = false;

    void OnDisable()
    {
        animator.SetBool(chargingHash, false);
        isCharging = false;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        chargingHash = Animator.StringToHash("ChargingAttack");
    }

    void Update()
    {
        if (!isCharging)
        {
            if (Vector3.Distance(Player.self.transform.position, transform.position) <= distanceNeededToShoot)
            {
                animator.SetBool(chargingHash, true);
                isCharging = true;
            }
            else
            {
                transform.position += (Player.self.transform.position - transform.position).normalized * Time.deltaTime * speed;
            }
        }
    }

    void Fire()
    {
        Vector3 directionToPlayer = (Player.self.transform.position - transform.position);

        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(directionToPlayer);
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize((Quaternion.AngleAxis(15, transform.forward) * directionToPlayer));
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize((Quaternion.AngleAxis(-15, transform.forward) * directionToPlayer));

        isCharging = false;
        animator.SetBool(chargingHash, false);
    }
}