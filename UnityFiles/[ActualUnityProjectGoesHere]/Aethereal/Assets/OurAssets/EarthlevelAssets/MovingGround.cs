using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public GameObject plyr;
    public GameObject stoppingGround;
    private bool move = false;
    float speed = 1.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(plyr.transform.position, gameObject.transform.position);
        float dist2 = Vector2.Distance(stoppingGround.transform.position, gameObject.transform.position);

        //Debug.Log("dist " + dist2);

        if (dist <= 3f && dist2 >= 3f)
        {
            move = true;
            //gameObject.transform.position.x = Mathf.Sin(Time.time * speed) * amount;
        }

        if (move == true)
            gameObject.transform.Translate(Vector2.right * Time.deltaTime, Space.World);

        if (dist2 <= 3f)
        {
            move = false;
            gameObject.transform.Translate(Vector2.zero);
        }
    }
}
