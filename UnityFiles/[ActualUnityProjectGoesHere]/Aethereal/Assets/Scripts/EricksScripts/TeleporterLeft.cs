using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterLeft : MonoBehaviour
{
    public GameObject TeleportGoal;
    public float speed;
    private Vector3 Vel;
    private float angularVel;
    //STORING PLATFORMS
    List<Vector3> platformPos = new List<Vector3>();

    private void Start()
    {
        StorePlatforms();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Player").transform.position = TeleportGoal.transform.position;
        GameObject.Find("Player").transform.Rotate(Vector3.back, 90);
        //RESETTING PLATFORMS
        ResetPlatforms();
        StartCoroutine(RotateForSeconds());
    }

    IEnumerator RotateForSeconds()
    {
        float trials = 0;
        Rigidbody2D rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        rb.mass = 0.7f;
        rb.velocity = new Vector3(0f, 4f, 0f);
        rb.angularVelocity = 0f;

        while (trials < 90 / speed)
        {
            GameObject.Find("Player").transform.Rotate(Vector3.forward, speed);
            yield return null;
            trials += 1;
        }
        rb.mass = 2f;
    }
    //RESETTING PLATFORMS
    public void StorePlatforms()
    {
        List<GameObject> objs = new List<GameObject>();
        objs.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
        foreach (GameObject platform in objs)
        {
            platformPos.Add(platform.transform.position);
        }
    }
    public void ResetPlatforms()
    {
        List<GameObject> objs = new List<GameObject>();
        objs.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
        int i = 0;
        foreach (GameObject platform in objs)
        {
            platform.transform.position = platformPos[i];
            platform.GetComponent<Rigidbody2D>().isKinematic = true;
            platform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            platform.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            i++;
        }
    }

}