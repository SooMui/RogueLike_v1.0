using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,

    Away,

    Follow,

    Die,

    Attack
};

public enum EnemyType
{
    Melee,

    Ranged
}

public class Enemy : MonoBehaviour
{
    GameObject player;
    public EnemyState currState = EnemyState.Idle;
    public EnemyType enemyType;

    public float range;
    public float speed;
    public float attackRng;
    public float cd;
    private bool chDir = false;
    private bool dead = false;
    private bool cdAttack = false;
    public bool notInRoom = false;
    private Vector3 randomDir;
    public GameObject bulletPrefab;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        switch (currState )
        {
            case(EnemyState.Away):
                Away();
            break;
            case(EnemyState.Follow):
                Follow();
            break;
            case(EnemyState.Die): 
            break;
            case(EnemyState.Attack):
                Attack();
            break;
        }
        
        if(!notInRoom)
        {
            if(IsPlayerInRange(range) && currState != EnemyState.Die)
                { 
                    currState = EnemyState.Follow;
                }
                    else if(!IsPlayerInRange(range) && currState != EnemyState.Die)
                        {
                            currState = EnemyState.Away;
                        }
                        if(Vector3.Distance(transform.position, player.transform.position) <= attackRng)
                            {
                                currState = EnemyState.Attack;
                            } 
        }
        else
        {
            currState = EnemyState.Idle;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChooseDirection()
    {
        chDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chDir = false;
    }

    void Away()
    {
        if(!chDir)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if(IsPlayerInRange(range))
        {
            currState  = EnemyState.Follow;
        }

    }
    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    
    void Attack()
    {
        if(!cdAttack)
        {
            switch(enemyType)
            {
                    case(EnemyType.Melee):
                    Game.DamagePlayer(1);
                    StartCoroutine(CoolDown());
                break;
                case(EnemyType.Ranged):
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject; 
                    bullet.GetComponent<Bullet>().GetPlayer(player.transform);
                    bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
                    bullet.GetComponent<Bullet>().isEnemyBullet = true;
                    StartCoroutine(CoolDown());
                break;
            }
        }
    }

    private IEnumerator CoolDown()
    {
        cdAttack = true;
        yield return new WaitForSeconds(cd);
        cdAttack = false;
    }

    public void Death()
    {
        // RoomController.instance.UpdateRooms();
        Destroy(gameObject);
    }
}
