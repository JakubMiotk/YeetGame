using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    public float PickUpRange = 6f;
    public float MoveForce = 250f;
    public float YeetForce = 100f;
    public Transform HoldParent;
    private GameObject HeldObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (HeldObject == null)
            {
                RaycastHit Hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, PickUpRange))
                {
                    PickingUpObject(Hit.transform.gameObject);
                }
            }
            else
            {
                DropObject(); 
            }
        }

        if(HeldObject != null)
        {
            MoveObject();
        }

        if (Input.GetButton("Fire1") && HeldObject != null)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            YeetForce += 100f * Time.deltaTime;           
        }

        if (Input.GetButtonUp("Fire1") && HeldObject != null)
        {
            Yeet();
            YeetForce = 100f;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        }
       
    }
    void MoveObject()
    {
        if(Vector3.Distance(HeldObject.transform.position, HoldParent.position) > 0.1f)
        {
            Vector3 MoveDirection = (HoldParent.position - HeldObject.transform.position);
            HeldObject.GetComponent<Rigidbody>().AddForce(MoveDirection * MoveForce);
        }
    }
    void PickingUpObject(GameObject PickedObject)
    {
        if (PickedObject.GetComponent<Rigidbody>())
        {
            Rigidbody ObjectRigid = PickedObject.GetComponent<Rigidbody>();
            ObjectRigid.useGravity = false;
            ObjectRigid.isKinematic = true;
            ObjectRigid.drag = 10;

            ObjectRigid.transform.parent = HoldParent;
            HeldObject = PickedObject;
        }
    }
    void DropObject()
    {
        Rigidbody HeldObjectRigid = HeldObject.GetComponent<Rigidbody>();
        HeldObjectRigid.useGravity = true;
        HeldObjectRigid.isKinematic = false;
        HeldObjectRigid.drag = 1;

        HeldObject.transform.parent = null;
        HeldObject = null;
    }
    void Yeet()
    {
        Rigidbody HeldObjectRigid = HeldObject.GetComponent<Rigidbody>();
        Vector3 MoveDirection = (HeldObject.transform.position - Camera.main.transform.position);
        HeldObjectRigid.useGravity = true;
        HeldObjectRigid.isKinematic = false;
        HeldObjectRigid.drag = 1;
        HeldObjectRigid.AddForce(MoveDirection * YeetForce);
        HeldObject.transform.parent = null;
        HeldObject = null;
    }
        
}
