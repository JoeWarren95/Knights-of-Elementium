using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public float ExplosionSpeed;
    public float ProjectileFloat;
    public Rigidbody2D RigidBody;
    public GameObject Player;
    public Animator SpellMaster;
    public bool Direction1;
    public bool Direction2;

    // Start is called before the first frame update
    //void Update()
    //{
        //transform.Rotate(new Vector3(0, 0, 30 * Time.deltaTime));
    //}
    void Update()
    {

    }
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        SpellMaster.SetBool("Exploding", false);
        Player = GameObject.Find("Player");
        ProjectileSpeed = 15;
        ExplosionSpeed = 12;
        ProjectileFloat = 3;

        if (Player.GetComponent<DashMove>().direction == 1)
        {
            RigidBody.velocity = new Vector3(-ProjectileSpeed, ProjectileFloat, 1) * 1;
            Direction1 = true;
            Direction2 = false;
        }
        if (Player.GetComponent<DashMove>().direction == 2)
        {
            RigidBody.velocity = new Vector3(ProjectileSpeed, ProjectileFloat, 1) * 1;
            Direction2 = true;
            Direction1 = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            SpellMaster.SetBool("Exploding", true);
            if (Direction1 == true && Direction2 == false)
            {
                RigidBody.velocity = -transform.right * ExplosionSpeed;
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
                RigidBody.velocity = -transform.right * ExplosionSpeed;
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
                RigidBody.velocity = -transform.right * ExplosionSpeed;
            }
            if (Direction2 == true && Direction1 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
        }
        if (collision.tag == "PlayerEarthSpellCollider")
        {
            SpellMaster.SetBool("Exploding", true);
            if (Direction1 == true && Direction2 == false)
            {
                RigidBody.velocity = -transform.right * ExplosionSpeed;
            }
            if (Direction2 == true && Direction1 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
        }
        if (collision.tag == "PlayerFireSpellCollider")
        {
            SpellMaster.SetBool("Exploding", true);
            if (Direction1 == true && Direction2 == false)
            {
                RigidBody.velocity = -transform.right * ExplosionSpeed;
            }
            if (Direction2 == true && Direction1 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
        }
        if (collision.tag == "PlayerWaterCollider")
        {
            SpellMaster.SetBool("Exploding", true);
            if (Direction1 == true && Direction2 == false)
            {
                RigidBody.velocity = -transform.right * ExplosionSpeed;
            }
            if (Direction2 == true && Direction1 == false)
            {
                RigidBody.velocity = transform.right * ExplosionSpeed;
            }
        }
        if (collision.tag == "LightningCollider")
        {
            SpellMaster.SetBool("Exploding", true);
            if (Direction1 == true && Direction2 == false)
            {
                RigidBody.velocity = -transform.right * ExplosionSpeed;
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
}
