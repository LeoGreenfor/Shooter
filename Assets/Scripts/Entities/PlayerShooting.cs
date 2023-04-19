using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Memento;

public class PlayerShooting : MonoBehaviour
{
    #region Fields
    #region Weapon
    [SerializeField] 
    private int currentWeapon;

    [SerializeField] 
    private KeyCode[] keysToSwitch;
    [SerializeField] 
    private Weapon[] weapons;
    #endregion
    #region Effects
    [SerializeField] 
    private Animator animator;
    [SerializeField] 
    private GameObject ShootEffectPrefab;
    private ParticleSystem ShotVFX;
    [SerializeField] 
    private AudioSource audioSource;
    [SerializeField] 
    private AudioClip[] shotClips;
    #endregion
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private UIController UIController;
    #endregion

    void Start()
    {
        for (int i = 0; i < hand.childCount; i++)
        {
            weapons[i] = hand.GetChild(i).GetComponent<Weapon>();
        }

        ShotVFX = weapons[currentWeapon].transform.GetChild(0).Find("VFX").GetComponent<ParticleSystem>();
        UIController.RefreshWeaponStats(weapons[currentWeapon]);
        GetComponent<Player>().weapon = weapons[currentWeapon];
    }

    void Update()
    {
        CheckSwitch();

        if (Input.GetMouseButtonDown(0))
        {
            if (weapons[currentWeapon].bullets > 0)
            {
                Shot();
            }
        }
    }

    private void Shot()
    {
        ShotVFX.Play();
        audioSource.PlayOneShot(shotClips[Random.Range(0, shotClips.Length)]);
        weapons[currentWeapon].bullets--;

        animator.CrossFade("Shot", 0.05f);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit, weapons[currentWeapon].shotDistance))
        {
            GameObject newParticle = Instantiate(ShootEffectPrefab,
                                                hit.point,
                                                Quaternion.identity,
                                                hit.transform);
            newParticle.transform.LookAt(transform.position);
            Destroy(newParticle, 10f);

            if (hit.collider.GetComponent<ZombieController>())
            {
                hit.collider.GetComponent<ZombieController>()
                    .TakeDamage(weapons[currentWeapon].weaponDamage);
            }
        }

        if (weapons[currentWeapon].bullets == 0)
        {
            //timer + animacia
            if (weapons[currentWeapon].bulletsAll >= weapons[currentWeapon].bulletsMax)
            {
                weapons[currentWeapon].bullets = weapons[currentWeapon].bulletsMax;
                weapons[currentWeapon].bulletsAll -= weapons[currentWeapon].bulletsMax;
            }
            else
            {
                weapons[currentWeapon].bullets = weapons[currentWeapon].bulletsAll;
                weapons[currentWeapon].bulletsAll = 0;
            }
        }

        UIController.RefreshWeaponStats(weapons[currentWeapon]);
    }

    private void CheckSwitch()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                currentWeapon--;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                currentWeapon++;
            }

            currentWeapon = Mathf.Clamp(currentWeapon, 0, 1);

            animator.CrossFade("Swich", 0.05f);
            StartCoroutine(nameof(SwichTimer));
        }

        for (int i = 0; i < keysToSwitch.Length; i++)
        {
            if (Input.GetKeyDown(keysToSwitch[i]) && currentWeapon != i)
            {
                currentWeapon = i;
                animator.CrossFade("Swich", 0.05f);
                StartCoroutine(nameof(SwichTimer));
                break;
            }
        }
    }

    private IEnumerator SwichTimer()
    {
        yield return new WaitForSeconds(0.15f);
        SwichWeapon();
    }

    private void SwichWeapon()
    {
        for (int j = 0; j < weapons.Length; j++)
        {
            weapons[j].gameObject.SetActive(false);
        }

        weapons[currentWeapon].gameObject.SetActive(true);
        ShotVFX = weapons[currentWeapon].transform.GetChild(0).Find("VFX").GetComponent<ParticleSystem>();

        UIController.RefreshWeaponStats(weapons[currentWeapon]);
    }

    public Weapon GetWeapon()
    {
        return weapons[currentWeapon];
    }
    public void AddBulletsToWeapons(int bullets0, int bullets1)
    {
        weapons[0].bulletsAll += bullets0;
        weapons[1].bulletsAll += bullets1;

        UIController.RefreshWeaponStats(weapons[currentWeapon]);
    }
}
