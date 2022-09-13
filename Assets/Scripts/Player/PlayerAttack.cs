using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float throwCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.CanAttack())
            Attack();

        cooldownTimer += Time.deltaTime;

        if (Input.GetMouseButton(1) && cooldownTimer > throwCooldown && playerMovement.CanAttack())
            Throw();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 1;
    }

    private void Throw()
    {
        anim.SetTrigger("throw");
        cooldownTimer = 1;

        projectiles[FindFireball()].transform.position = firePoint.position;
        projectiles[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
