using UnityEngine;

public class DragForceCube : MonoBehaviour
{
    public float DragCoefficient = 1.05f;
    public Vector3 Dragforce;
    public float AirDensity = 1.225f;
    public float LimitingSpeed = 0f;
    float Gravity = 9.81f;      
    void Update()
    {
        Vector3 Dragforce1;
        Rigidbody ObjectRigid = transform.gameObject.GetComponent<Rigidbody>();    
        float AxialSextion = (transform.localScale.x * transform.localScale.x);
        LimitingSpeed = Mathf.Sqrt((2 * ObjectRigid.mass * Gravity) / (DragCoefficient * AirDensity * AxialSextion));
        Dragforce1 = -(DragCoefficient * AirDensity * AxialSextion * ObjectRigid.velocity / 2);
        if (Dragforce1.y < LimitingSpeed)
        {
            Dragforce.y = Dragforce1.y;
        }
        else
        {
            Dragforce.y = LimitingSpeed;
        }
        ObjectRigid.AddForce(Dragforce);
    }   
}
