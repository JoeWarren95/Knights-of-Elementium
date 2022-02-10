using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherits from ScriptableObject bc Scriptable Objects are
//data containers that can save large amounts of data independent
//of class instances

[CreateAssetMenu(fileName = "newMoveStateData", menuName = "Data/State Data/Move State")]

public class D_MoveState : ScriptableObject
{
    public float movementSpeed = 3f;
}
