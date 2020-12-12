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
            Carry(carriedObject);
            CheckDrop();
            CheckThrow();
        }
        else
        {
            Pickup();
        }
    }

    void CheckThrow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isCarrying = false;
            objectRB.isKinematic = false;
            objectRB.AddForce(gameObject.transform.forward * (65 / objectRB.mass), ForceMode.Impulse);
            carriedObject = null;
        }
    }

    void Carry(GameObject o)
    {
        objectRB = carriedObject.GetComponent<Rigidbody>();
        objectRB.isKinematic = true;
        Vector3 projectedPostion = mainCamera.transform.position + mainCamera.transform.forward * distance;
        o.transform.position = Vector3.Lerp(o.transform.position, projectedPostion, Time.deltaTime * (smooth / objectRB.mass));
        // use systems.diagnostics.debug.writeline(); to debug
        if (projectedPostion.y / 4 < 0.1)
        {
            BoxCollider collider = o.GetComponent<BoxCollider>();
            o.transform.position = new Vector3(o.transform.position.x, 0 + o.transform.localScale.y / 2, o.transform.position.z);
        }
        distance = distance + (Input.GetAxisRaw("Mouse ScrollWheel") * (6 / objectRB.mass));
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

    void CheckDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isCarrying = false;
            objectRB.isKinematic = false;
            carriedObject = null;
        }
    }


}