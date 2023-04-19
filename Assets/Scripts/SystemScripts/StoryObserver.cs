using Assets.Scripts.Memento;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StoryObserver : MonoBehaviour
{
    #region UI
    [SerializeField]
    private UIController missionInfoUI;
    #endregion
    #region Arc
    [SerializeField]
    private GameObject letter;
    [SerializeField]
    private GameObject bottle;
    [SerializeField]
    private GameObject water;
    #endregion
    public int storyArc;

    public void FromLetterToBottle()
    {
        missionInfoUI.LookOnLetter();

        letter.SetActive(false);
        bottle.SetActive(true);

        missionInfoUI.RefreshMissionInfo("Find a bottle with antidot somewhere in town");
        storyArc = 1;
    }

    public void FromBottleToEnd()
    {
        bottle.SetActive(false);
        water.SetActive(true);

        missionInfoUI.RefreshMissionInfo("Reach the mountain with the lake and throw the bottle into there");
        storyArc = 2;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(3);
    }

    private void Start()
    {
        storyArc = 0;
        missionInfoUI.RefreshMissionInfo("Find a camp with the survivors and find out what happened");
    }

    /*[System.Obsolete]
    private void FixedUpdate()
    {
        bool isPlayerNearLetter = Vector3.Distance(transform.FindChild("Letter").position, player.position) <= distanceToObject;
        bool isPlayerNearBottle = Vector3.Distance(transform.FindChild("Bottle").position, player.position) <= distanceToObject;
        bool isPlayerNearWater = Vector3.Distance(transform.FindChild("StoryWater").position, player.position) <= distanceToObject;
        bool isPlayerTakeObject = Input.GetKey(KeyCode.E);

        if (isPlayerTakeObject)
        {
            if (isPlayerNearLetter)
            {
                missionInfoUI.LookOnLetter();

                letter.SetActive(false);
                bottle.SetActive(true);

                missionInfoUI.RefreshMissionInfo("Find a bottle with antidot somewhere in town");
                storyArc = 1;
            }
            if (isPlayerNearBottle)
            {
                bottle.SetActive(false);
                water.SetActive(true);

                missionInfoUI.RefreshMissionInfo("Reach the mountain with the lake and throw the bottle into there");
                storyArc = 2;
            }
            if (isPlayerNearWater)
            {
                storyArc = 3;
            }

            player.GetComponent<Player>().RefreshMemento();
        }

        if (storyArc == 3)
        {
            SceneManager.LoadScene(0);
        }
    }*/
}
