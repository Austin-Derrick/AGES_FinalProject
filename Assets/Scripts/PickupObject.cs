using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    GameObject mainCamera;
    bool isCarrying;
    bool isRotating;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    float rotationSpeed = 3f;
    Rigidbody objectRB;
    [SerializeField]
    CameraBehavior controller;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");    

    }

    // Update is called once per frame
    void Update()
    {
        if (isCarrying)
        {
            //Carry(carriedObject);
            //CheckDrop();
        }
        else
        {
            Pickup();
        }
    }

    

    

    void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                PickupAble p = hitInfo.collider.GetComponent<PickupAble>();
                if (p != null)
                {
                    isCarrying = true;
                    carriedObject = p.gameObject;
                }
            }
        }
    }

    
}