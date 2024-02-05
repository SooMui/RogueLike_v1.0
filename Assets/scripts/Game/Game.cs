    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game instance;

    private static float health = 6;
    private static int maxHealth = 6;
    private static float moveSpeed = 5f;
    private static float fireRate = 0.5f;
    private static float bulletSize = 0.5f;

    private bool ammoCollected = false;
    private bool speedCollected = false;

    public List<string> collectedNames = new List<string>();

    public static float Health {get => health; set => health = value; }
    
    public static int MaxHealth{ get => maxHealth; set => maxHealth = value; }

    public static float MoveSpeed{ get => moveSpeed; set => moveSpeed = value; }

    public static float FireRate{ get => fireRate; set => fireRate = value; }

    public static float BulletSize{ get => bulletSize; set => bulletSize = value; }


    public Text healthText;
    
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health; 
    }

    public static void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerDie();
        }
    }
    
    public static void HealPlayer(float healAmount)
    {
        health = Mathf.Min(maxHealth, health + healAmount);
    }

    public static void MoveSpeedCH(float speed)
    {
        moveSpeed +=speed;
    }
    
    public static void FireRateCH(float rate)
    {
        fireRate -=rate;
    }
    
    public static void BulletSizeCH(float size)
    {
        bulletSize +=size;
    }

    public void UpdateCollectedItems(Items item)
    {
        collectedNames.Add(item.item.name);

        foreach(string i in collectedNames)
        {
            switch(i)
            {
                case "Speed_pill":
                    speedCollected = true;
                break; 
                case "Ammo":
                    ammoCollected = true;
                break;

            }
        }
        if(speedCollected && ammoCollected)
        {
            FireRateCH(0.25F);
        }
    }

    private static void PlayerDie()
    {

    }
}
