using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class D_Enemy : ScriptableObject
{
    //check distances
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;

    //agro distances
    public float minAgroDistance = 2f;
    public float midAgroDistance = 3f;
    public float maxAgroDistance = 4f;

    //layermasks
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
