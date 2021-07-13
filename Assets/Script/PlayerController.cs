using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float seedH = 2.0f;
    public float speedV = 2.0f;
    public float yaw;
    public float pitch;

    public GameObject life;
    public GameObject[] lifes = new GameObject[3];

    public int lifCount = 3;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        for (int i = 0; i < lifes.Length; i++)
        {
            lifes[i] = Instantiate(life, new Vector3(0, 0, 0), Quaternion.identity);
            lifes[i].transform.SetParent(GameObject.Find("vidaUI").transform);

            RectTransform rt = lifes[i].GetComponent<RectTransform>();
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 1000 + (i * 80), rt.rect.width);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 12, rt.rect.height);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pitch -= speedV * Input.GetAxis("Mouse Y");
        yaw += seedH * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(pitch, yaw, 0);

        if (Input.GetMouseButtonDown(0))
        {
            ColisionRay();
        }
    }

    void ColisionRay()
    {
        RaycastHit ray;

        if (Physics.Raycast(transform.position, transform.forward, out ray, 100f))
        {
            GameObject bullet = ray.transform.gameObject;

            if (bullet.tag == "Bullet")
            {
                Destroy(bullet);
            }

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            lifCount--;
            Destroy(lifes[lifCount].gameObject);

            if (lifCount == 0)
            {
                Debug.Log("GameOver");
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
