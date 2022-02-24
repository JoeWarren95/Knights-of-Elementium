using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public float ExplosionSpeed;
    public float ProjectileFloat;
    public Rigidbody2D RigidBody;
    public GameObject FloatingEarthText;
    public GameObject Player;
    public GameObject Enemy;
    public Animator SpellMaster;
    public bool Direction1;
    public bool Direction2;
    public int EarthPower;
    public int FirePower;
    public int WaterPower;
    public int LightningPower;

    // Start is called before the first frame update
    //void Update()
    //{
    //transform.Rotate(new Vector3(0, 0, 30 * Time.deltaTime));
    //}
    void Update()
    {
        EarthPower = Enemy.GetComponent<EnemyHealth>().EarthPower;
        FirePower = Enemy.GetComponent<EnemyHealth>().FirePower;
        WaterPower = Enemy.GetComponent<EnemyHealth>().WaterPower;
        LightningPower = Enemy.GetComponent<EnemyHealth>().LightningPower;

        if (Enemy.GetComponent<Enemy_behavior>().direction == 1)
        {
            Direction1 = true;
            Direction2 = false;
        }
        if (Enemy.GetComponent<Enemy_behavior>().direction == 2)
        {
            Direction1 = false;
            Direction2 = true;
        }
    }
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        SpellMaster.SetBool("Exploding", false);
        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("Enemy");
        ProjectileSpeed = 15;
        ExplosionSpeed = 12;
        ProjectileFloat = 3;

        if (Enemy.GetComponent<Enemy_behavior>().direction == 1)
        {
            RigidBody.velocity = new Vector3(-ProjectileSpeed, ProjectileFloat, 1) * 1;
            Direction1 = true;
            Direction2 = false;
        }
        if (Enemy.GetComponent<Enemy_behavior>().direction == 2)
        {
            RigidBody.velocity = new Vector3(ProjectileSpeed, ProjectileFloat, 1) * 1;
            Direction2 = true;
            Direction1 = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Player.GetComponent<DashMove>().IsDashing == false && Player.GetComponent<PlayerHealth>().CanBeDamaged == true)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(EarthPower - Player.GetComponent<PlayerAttributes>().EarthResistance);   // Player takes enemy earth spell damage - resistance
            ShowEarthDamage((EarthPower - Player.GetComponent<PlayerAttributes>().EarthResistance).ToString());                     // show earth dmg done to player
            Player.GetComponent<PlayerMovement>().Staggered = true;                                                                 // Stagger Player
            Player.GetComponent<PlayerMovement>().StaggerTime = 0.05f * EarthPower - Player.GetComponent<PlayerAttributes>().Weight;        // lower duration of stagger by player weight
            SpellMaster.SetBool("Exploding", true);
            
            if (Direction1 == true && Direction2 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;

            }
            if (Direction2 == true && Direction1 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
        }
        if (collision.tag == "ResourceNode")
        {
            SpellMaster.SetBool("Exploding", true);
            if (Direction1 == true && Direction2 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
            if (Direction2 == true && Direction1 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
        }
        if (collision.tag == "ProjectileCollider")
        {
            SpellMaster.SetBool("Exploding", true);
            if (Direction1 == true && Direction2 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
            if (Direction2 == true && Direction1 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
        }
    }


    public void ExplodeProjectile()
    {
        Destroy(gameObject);
    }

    void ShowEarthDamage(string text)
    {
        if (FloatingEarthText)
        {
            GameObject prefab = Instantiate(FloatingEarthText, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
            prefab.transform.position = Player.transform.position + new Vector3(0, 1, 0);
        }
    }
}
