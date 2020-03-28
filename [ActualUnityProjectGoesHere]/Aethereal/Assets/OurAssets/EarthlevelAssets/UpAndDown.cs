using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    private bool upLimit = false;
    private bool downLimit = true;
    void Update()
    {
        if (gameObject.transform.position.y <= -0.95)
        {
            downLimit = true;
            upLimit = false;
        }
        else if (gameObject.transform.position.y >= 0.95)
        {
            upLimit = true;
            downLimit = false;
        }

        if (upLimit)
            gameObject.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        else if (downLimit)
            gameObject.transform.Translate(Vector3.up * Time.deltaTime, Space.World);

    }
}
