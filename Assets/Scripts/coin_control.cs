using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class coin_control : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 25f;
    int initialPos;
    private void Awake()
    {
        System.Random rnd = new System.Random();
        initialPos = rnd.Next(-180, 180);
        transform.Rotate(0, 0, initialPos, Space.Self);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0 + rotationSpeed * Time.deltaTime, Space.Self);
    }
}
