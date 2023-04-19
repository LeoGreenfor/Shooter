using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollRemuver : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DeathTimer());
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
