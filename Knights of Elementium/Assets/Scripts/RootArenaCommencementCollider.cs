using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootArenaCommencementCollider : MonoBehaviour
{
    public GameObject MainPlayer;
    public GameObject PlayerCollider;
    public GameObject FogWallGrid;
    public GameObject RootKnight;
    public GameObject RootArenaCommencer;

    private void OnTriggerEnter2D(Collider2D collision) // Player Commences Root Arena Boss Battle
    {
        if (collision.CompareTag("Player"))
        {
            FogWallGrid.SetActive(true);
            RootKnight.SetActive(true);
            RootArenaCommencer.SetActive(false);
        }
    }
}
