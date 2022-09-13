using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTrigger : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement.walk = !playerMovement.walk;
    }
}
