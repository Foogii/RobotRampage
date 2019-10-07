using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int armour;
    public GameUI gameUI;
    private GunEquipper gunEquipper;
    private Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        int healthDamage = amount;

        if (armour > 0)
        {
            int effectiveArmour = armour * 2;
            effectiveArmour -= healthDamage;

            // If there is still armour, don't need to process
            // health damage
            if (effectiveArmour > 0)
            {
                armour = effectiveArmour / 2;
                return;
            }
            armour = 0;
        }

        health -= healthDamage;
        Debug.Log("Health is " + health);

        if(health <= 0)
        {
            Debug.Log("GameOver");
        }
    }

    // 1
    private void pickupHealth()
    {
        health += 50;
        if (health > 200)
        {
            health = 200;
        }
    } 

    private void pickupArmour()
    {
        armour += 15;
    }

    // 2
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
    } 

    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
    }

    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
    }

    public void PickUpItem(int pickupType)
    {
        switch(pickupType)
        {
            case Constants.PickUpArmour:
                pickupArmour();
                break;
            case Constants.PickUpHealth:
                pickupHealth();
                break;
            case Constants.PickUpAssaultRifleAmmo:
                pickupAssaultRifleAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                pickupPistolAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                pickupShotgunAmmo();
                break;
            default:
                Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
}
