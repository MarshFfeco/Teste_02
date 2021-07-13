using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject Player;
    public GameObject Bullet;

    float time = 1.5f;
    float curTime;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        transform.LookAt(Player.transform);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        curTime += Time.deltaTime;

        if (curTime > time)
        {
            if (Random.Range(0, 100) > 50)
            {
                GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
 
                Destroy(bullet, 2f);

            }
            curTime = 0;
        }
    }
}
