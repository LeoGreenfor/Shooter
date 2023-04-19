using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string name;

    public float shotDistance;
    public float shotTimer;

    public float weaponDamage;

    /// <summary>
    /// the number of balls in weapon
    /// </summary>
    public int bullets;
    /// <summary>
    /// the maximum number of balls in the holder
    /// </summary>
    public int bulletsMax;
    /// <summary>
    /// the number of balls the player has
    /// </summary>
    public int bulletsAll;
}
