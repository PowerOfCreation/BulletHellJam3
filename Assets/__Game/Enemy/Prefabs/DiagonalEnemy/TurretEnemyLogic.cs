using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TurretEnemyLogic : MonoBehaviour
{
    public GameObject projectilePrefab;

    private Animator animator;
    private static int chargingHash;

    private bool isCharging = false;

    private float angle = 0;

    private float targetY;

    private float moveInSpeed = 1f;

    void OnDisable()
    {
        animator.SetBool(chargingHash, false);
        isCharging = false;
    }

    void Start()
    {
        targetY = transform.position.y - 5f;
    }

    void Update()
    {
        if(transform.position.y > targetY)
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime * moveInSpeed;

            if(transform.position.y <= targetY)
            {
                targetY = 10f;

                isCharging = true;
                animator.SetBool(chargingHash, true);
            }
        }
        else
        {
            transform.position += new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0).normalized * Time.deltaTime * 0.2f;
            angle += Time.deltaTime * 2.5f;
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        chargingHash = Animator.StringToHash("ChargingAttack");
    }

    void Fire()
    {
        SpawnProjectiles();
    }

    protected virtual void SpawnProjectiles()
    {
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(new Vector3(1, 1).normalized);
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(new Vector3(-1, 1).normalized);
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(new Vector3(1, -1).normalized);
        PoolingManager.Spawn(projectilePrefab, transform.position).GetComponent<Projectile>().Initialize(new Vector3(-1, -1).normalized);
    }
}