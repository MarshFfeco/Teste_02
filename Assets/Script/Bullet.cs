using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float spd = 0.5f;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        transform.LookAt(Player.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * spd;
    }
}
