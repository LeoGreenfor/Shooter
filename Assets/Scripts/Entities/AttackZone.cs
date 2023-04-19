using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    private ZombieController zombie;

    private void Start()
    {
        zombie = GetComponentInParent<ZombieController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        zombie.isOnZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        zombie.isOnZone = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && zombie.isCanPush)
        {
            zombie.InflictDamage();
        }
    }
}
