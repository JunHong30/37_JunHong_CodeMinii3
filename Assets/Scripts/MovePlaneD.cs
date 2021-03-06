﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlaneD : MonoBehaviour
{
    public GameObject playerGO;

    float zUpperLimit = 85.0f;
    float zLowerLimit = 70.0f;
    float moveSpeed = 5.0f;

    bool isMoveFwd = false;
    bool isMoveBack = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerGO.GetComponent<PlayerController>().trigSwitch)
        {
            if (isMoveBack && !isMoveFwd)
            {
                if (transform.position.z >= zLowerLimit)
                {
                    transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
                }
                else
                {
                    isMoveBack = !isMoveBack;
                    isMoveFwd = !isMoveFwd;
                }
            }
            if (isMoveFwd && !isMoveBack)
            {
                if (transform.position.z <= zUpperLimit)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
                }
                else
                {
                    isMoveBack = !isMoveBack;
                    isMoveFwd = !isMoveFwd;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerGO.transform.SetParent(transform);
        }
    }
}
