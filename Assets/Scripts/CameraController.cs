﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerGo;

    Vector3 posOffSet = new Vector3(0, 3.0f, -4.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerGo.transform.position + posOffSet, 0.1f);
    }
}
