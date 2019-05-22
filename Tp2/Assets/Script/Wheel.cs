using UnityEngine;
using Physics;

public class Wheel : MonoBehaviour
{
    float wheelRadius = 2.0f;
    float angleI;
    float timeI;
    float angleF;
    float timeF;
    public float angVelocity;
    public float speed = 1;
    public float maxSpeed = 10.0f;
    public float maxAngVel = 10.0f;

    private void Start()
    {
        angleI = 0;
        timeI = 0;
        angleF = 0;
        timeF = 0;
        angVelocity = 0;
    }

    private void Update()
    {
        angleI += Time.deltaTime * speed;
        timeI += Time.deltaTime;  
        angVelocity = Physics.Movements.CalculateAngularVelocity(angleI, angleF, timeI, timeF);
        angleF += Time.deltaTime * speed;
        timeF += Time.deltaTime;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        angVelocity = Mathf.Clamp(angVelocity, -maxAngVel, maxAngVel);
    }

    public float TractionForce(){
        return (angVelocity / wheelRadius);
    }
}
