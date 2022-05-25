using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationOfGravity : MonoBehaviour
{
    Vector3 velocity;
    float gravity = -9.81f;
    
    void Update()
    {
        Rigidbody ObjectRigid = transform.gameObject.GetComponent<Rigidbody>();
        velocity.y += gravity * Time.deltaTime;
        ObjectRigid.AddForce(velocity * Time.deltaTime);
    }

}
