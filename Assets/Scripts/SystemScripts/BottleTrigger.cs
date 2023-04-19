using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleTrigger : MonoBehaviour
{
    private StoryObserver storyObserver;

    private void Start()
    {
        storyObserver = GetComponentInParent<StoryObserver>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                storyObserver.FromBottleToEnd();
            }
        }
    }
}
