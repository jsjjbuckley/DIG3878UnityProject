using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCloud : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public bool isRight = true;
    public float speed = 0.3f;
    private Vector3 pointAPosition;
    private Vector3 pointBPosition;
    private Vector3 ogPos;

    // Use this for initialization
    void Start()
    {
        pointAPosition = new Vector3(pointA.position.x, 0, 0);
        pointBPosition = new Vector3(pointB.position.x, 0, 0);
        ogPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 thisPosition = new Vector3(transform.position.x, 0, 0);

        transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed);
        if (thisPosition.Equals(pointBPosition))
        {
            //Debug.Log ("Position b");
            ogPos = new Vector3(pointA.position.x, pointA.position.y, 0f);
        }   

    }

}
