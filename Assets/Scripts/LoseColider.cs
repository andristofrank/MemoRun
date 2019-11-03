using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
       GameObject player= GameObject.FindWithTag("Player");
        player.GetComponent<MyPlayer>().ReSpawn();
    }
}
