using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;

    public string descriprion;

    public Sprite itemImage;
}

public class Items : MonoBehaviour
{
    
    public Item item;

    public float healthCH;

    public float moveSpeedCH;

    public float attackSpeedCH;

    public float bulletSizeCH;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.itemImage;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if(collision.tag == "Player")
        {
            Player.collectedAmount++;
            Game.HealPlayer(healthCH);
            Game.MoveSpeedCH(moveSpeedCH);
            Game.FireRateCH(attackSpeedCH);
            Game.BulletSizeCH(bulletSizeCH);
            Game.instance.UpdateCollectedItems(this);
            Destroy(gameObject);
        }
    }
}
