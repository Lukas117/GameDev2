using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float throwCooldown;
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
    }
}
