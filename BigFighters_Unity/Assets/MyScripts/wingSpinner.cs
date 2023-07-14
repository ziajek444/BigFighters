using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wingSpinner : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;

    void Awake()
    {
        
    }

    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
