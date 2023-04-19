using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public float spawnTimer;
    public float distanceToCenter;

    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private Transform centerPoint;

    [SerializeField]
    private GameObject zombiePrefab;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void SpawnZombie()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        bool isPlayerInDistance = Vector3.Distance(
            player.transform.position, centerPoint.position) <= distanceToCenter;
        Transform currentPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];

        if (isPlayerInDistance)
        {
            Instantiate(zombiePrefab, currentPosition.position, Quaternion.identity, null);
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(spawnTimer);
        SpawnZombie();

        StartCoroutine(Timer());
    }
}
