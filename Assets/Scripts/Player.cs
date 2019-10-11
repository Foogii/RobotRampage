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

    public Game game;
    public AudioClip playerDead;

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

            // If there is still armour, don't need to process health damage
            if (effectiveArmour > 0)
            {
                armour = effectiveArmour / 2;
                gameUI.SetArmourText(armour);
                return;
            }
            armour = 0;
            gameUI.SetArmourText(armour);
        }

        health -= healthDamage;
        gameUI.SetHealthText(health);

        if (health <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(playerDead);
            game.GameOver();
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

        gameUI.SetPickUpText("Health picked up + 50 Health");
        gameUI.SetHealthText(health);
    } 

    private void pickupArmour()
    {
        armour += 15;
        gameUI.SetPickUpText("Armour picked up + 15 armour");
        gameUI.SetArmourText(armour);
    }

    // 2
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        gameUI.SetPickUpText("Assault rifle ammo picked up + 50 ammo");

        if (gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    } 

    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
        gameUI.SetPickUpText("Pistol ammo picked up + 20 ammo");

        if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }

    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
        gameUI.SetPickUpText("Shotgun ammo picked up + 10 ammo");

        if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
        }
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
