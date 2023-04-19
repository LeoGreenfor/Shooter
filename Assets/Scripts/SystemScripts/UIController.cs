using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    #region Weapon info
    public TMP_Text weaponName;
    public TMP_Text bulletsText;
    public TMP_Text bulletsAllText;
    #endregion
    #region Player info
    public TMP_Text healthBarText;
    public Image healthBarImage;
    #endregion
    #region Story info
    public TMP_Text missionText;
    public Image letterBackground;
    public GameObject letter;
    public Button Closebutton;
    #endregion

    public GameObject pause;

    /// <summary>
    /// Refreshing UI-elements with info about weapon
    /// </summary>
    /// <param name="weapon"></param>
    public void RefreshWeaponStats(Weapon weapon)
    {
        weaponName.text = weapon.name;
        bulletsText.text = weapon.bullets.ToString() + "/"
                           + weapon.bulletsMax.ToString();
        bulletsAllText.text = weapon.bulletsAll.ToString();
    }
    
    /// <summary>
    /// Refreshing UI-elements with info about weapon
    /// </summary>
    /// <param name="health"></param>
    public void RefreshHealthStats(PlayerHealth playerHealth)
    {
        healthBarText.text = string.Format("{0:0}", playerHealth.health) + "/" 
                                + string.Format("{0:0}", playerHealth.healthMax);
        healthBarImage.fillAmount = playerHealth.health / playerHealth.healthMax;
        
    }

    public void RefreshMissionInfo(string text)
    {
        missionText.text = text;
    }

    public void LookOnLetter()
    {
        letterBackground.gameObject.SetActive(true);
        letter.SetActive(true);
        Closebutton.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void CloseLetter()
    {
        letterBackground.gameObject.SetActive(false);
        letter.SetActive(false);
        Closebutton.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
}
