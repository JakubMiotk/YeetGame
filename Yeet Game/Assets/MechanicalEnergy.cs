using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalEnergy : MonoBehaviour
{
    public float PotentialEnergy = 0f;
    public Vector3 KinematicEnergy;
    float gravity = 9.81f;
    private void Start()
    {
        Rigidbody ObjectRigid = transform.gameObject.GetComponent<Rigidbody>();
        PotentialEnergy = (ObjectRigid.mass * gravity * transform.position.y);
    }
    void Update()
    {
        Rigidbody ObjectRigid = transform.gameObject.GetComponent<Rigidbody>();
        PotentialEnergy = (ObjectRigid.mass * gravity * transform.position.y);
        KinematicEnergy.x = (ObjectRigid.mass * ObjectRigid.velocity.x * ObjectRigid.velocity.x / 2);
        KinematicEnergy.y = (ObjectRigid.mass * ObjectRigid.velocity.y * ObjectRigid.velocity.y / 2);
        KinematicEnergy.z = (ObjectRigid.mass * ObjectRigid.velocity.z * ObjectRigid.velocity.z / 2);
    }
}
