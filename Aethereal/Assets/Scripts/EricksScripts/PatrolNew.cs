﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNew : MonoBehaviour
{
    public float speed = 2f;
    public float maxRotation = 45f;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }
}

