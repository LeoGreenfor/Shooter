using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatCotroller : MonoBehaviour
{
    public Transform nextPosition;
    public Transform currentPosition;

    private Transform player;
    [SerializeField]
    private float distansToBoat;

    public Image image;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        bool isPlayerNear = Vector3.Distance(transform.position, player.position) <= distansToBoat;
        Animator animator = image.GetComponent<Animator>();

        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            animator.Play("CrossRiverImage");
            StartCoroutine(nameof(CrossRiverCulldown));
        }
    }

    private void SwimToDock()
    {
        transform.position = nextPosition.position;
        
        Vector3 playerPosition = transform.position;
        player.position = playerPosition;

        Swap<Transform>(ref currentPosition, ref nextPosition);
    }

    private IEnumerator CrossRiverCulldown()
    {
        yield return new WaitForSeconds(1.0f);
        SwimToDock();
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T temp = second;
        second = first;
        first = temp;
    }
}
