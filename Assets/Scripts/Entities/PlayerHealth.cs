using Assets.Scripts.Memento;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100.0f;
    public float healthMax = 100.0f;

    [SerializeField]
    private UIController UIController;

    private void Start()
    {
        UIController.RefreshHealthStats(this);
    }

    /// <summary>
    /// Change player health. Can work like "take damage" (you must specify a negative value) or "heal"
    /// </summary>
    /// <param name="numberOfUnits"></param>
    public void HealthChange(float numberOfUnits)
    {
        health += numberOfUnits;
        health = Mathf.Clamp(health, 0, healthMax);

        if (health == 0)
        {
            Death();
        }

        UIController.RefreshHealthStats(this);
    }

    /// <summary>
    /// Reload scene when player is dead
    /// </summary>
    private void Death()
    {
        gameObject.GetComponent<Player>().RestoreState();
    }
}
