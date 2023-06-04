using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniHaritaSabit : MonoBehaviour
{
    public Vector3 oldPosition;
    public Quaternion oldRotation;
    void Start()
    {
       oldPosition = transform.position;
       oldRotation = transform.rotation; 
    }

    
    void Update()
    {
        transform.position = oldPosition;
        transform.rotation = oldRotation;
    }
}
