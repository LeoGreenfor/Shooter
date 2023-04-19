using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float distansToDoor;
    [SerializeField]
    private Animator animator;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        bool isPlayerNear = Vector3.Distance(transform.position, player.position) <= distansToDoor;
        bool isPlayerOpeningDoor = Input.GetKey(KeyCode.E);

        if (isPlayerNear && isPlayerOpeningDoor)
        {
            animator.Play("OpenDoors");
        }
    }
}
