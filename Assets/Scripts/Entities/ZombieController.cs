using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public bool isCanPush;
    public bool isOnZone;

    [SerializeField]
    private GameObject attackZone;
    [SerializeField]
    private float health;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float distanceToPlayer;
    [SerializeField]
    private float distanceToAttack;
    [SerializeField]
    private float damageMin;
    [SerializeField]
    private float damageMax;
    [SerializeField]
    private GameObject ragdoll;

    private Transform player;
    private NavMeshAgent navMeshAgent;

    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        navMeshAgent.SetDestination(player.position);
        bool isPlayerNear = Vector3.Distance(transform.position, player.position) <= distanceToPlayer;
        bool isCanAttack = Vector3.Distance(transform.position, player.position) <= distanceToAttack;

        if (isPlayerNear && !isCanAttack)
        {
            animator.SetInteger("State", 1);
            navMeshAgent.isStopped = false;
        }
        else if (!isPlayerNear)
        {
            animator.SetInteger("State", 0);
            navMeshAgent.isStopped = true;
        }

        if (isCanAttack)
        {
            attackZone.SetActive(true);
        }
        else
        {
            attackZone.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject newRagdoll = Instantiate(ragdoll, transform.position, Quaternion.identity, null);
            newRagdoll.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void InflictDamage()
    {
        animator.Play("zombiePushing");
        navMeshAgent.isStopped = true;
        isCanPush = false;
        StartCoroutine(InflictDamageCulldown());
    }

    private IEnumerator PushingCulldown()
    {
        yield return new WaitForSeconds(1.15f);
        
        isCanPush = true;
        navMeshAgent.isStopped = false;
    }

    private IEnumerator InflictDamageCulldown()
    {
        yield return new WaitForSeconds(1.1f);
        if (isOnZone)
        {
            float damage = Random.Range(damageMin, damageMax);
            player.gameObject.GetComponent<PlayerHealth>().HealthChange(-damage);
        }
        StartCoroutine(PushingCulldown());
    }
}
