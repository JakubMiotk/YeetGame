using UnityEngine;

public class DragForceSphere : MonoBehaviour
{
    public float DragCoefficient = 0.47f;
    public Vector3 Dragforce;
    public float AirDensity = 1.225f;
    public float LimitingSpeed = 0f;    
    float Gravity = 9.81f;
    void Update()
    {
        Vector3 Dragforce1;
        Rigidbody ObjectRigid = transform.gameObject.GetComponent<Rigidbody>();
        float AxialSextion = (Mathf.PI * (transform.localScale.x/2) * (transform.localScale.x/2));
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