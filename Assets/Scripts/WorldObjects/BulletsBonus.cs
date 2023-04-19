using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerShooting>().AddBulletsToWeapons(30, 10);

            Destroy(this.gameObject);
        }
    }

}
