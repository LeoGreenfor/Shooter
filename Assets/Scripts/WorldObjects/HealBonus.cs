using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().HealthChange(20);

            Destroy(this.gameObject);
        }
    }
}
