using UnityEngine;
using Physics;

enum State
{
    NEGATIVE = -1,
    NULL = 0,
    POSITIVE = 1,
}

public class PlayerMCU : MonoBehaviour
{
    public Wheel leftWheel;
    public Wheel rightWheel;
    public float acceleration = 5.0f;

private void Start() {
    CollisionManager.Instance.addBox(transform.GetComponent<Box>());
}

    void Update()
    {
        switch ((int)Input.GetAxisRaw("Right"))
        {
            case (int)State.POSITIVE:
                if (rightWheel.accel < rightWheel.maxAccel)
                    rightWheel.accel += Time.deltaTime;
                break;
            case (int)State.NEGATIVE:
                if (rightWheel.accel > -rightWheel.maxAccel)
                    rightWheel.accel -= Time.deltaTime;
                break;
            case (int)State.NULL:
                if (rightWheel.accel != 0.0f)
                    rightWheel.accel = (rightWheel.speed > 0.0f) ? -rightWheel.friction : rightWheel.friction;
                break;
        }

        switch ((int)Input.GetAxisRaw("Left"))
        {
            case (int)State.POSITIVE:
                if (leftWheel.accel < leftWheel.maxAccel)
                    leftWheel.accel += Time.deltaTime * acceleration;
                break;
            case (int)State.NEGATIVE:
                if (leftWheel.accel > -leftWheel.maxAccel)
                    leftWheel.accel -= Time.deltaTime * acceleration;
                break;
            case (int)State.NULL:
                if (leftWheel.accel != 0.0f)
                    leftWheel.accel = (leftWheel.speed > 0.0f) ? -leftWheel.friction : leftWheel.friction;
                break;
        }

        float minRightWheelSpeed = (rightWheel.accel == -rightWheel.friction) ? 0f : -rightWheel.maxSpeed;
        float minLeftWheelSpeed  = (leftWheel.accel  == -leftWheel.friction)  ? 0f : -leftWheel.maxSpeed;
        float maxRightWheelSpeed = (rightWheel.accel ==  rightWheel.friction) ? 0f :  rightWheel.maxSpeed;
        float maxLeftWheelSpeed  = (leftWheel.accel  ==  leftWheel.friction)  ? 0f :  leftWheel.maxSpeed;

        Physics.Movements.ConstAccelCirc2D(rightWheel.radius, rightWheel.accel, ref rightWheel.speed, minRightWheelSpeed, maxRightWheelSpeed);
        Physics.Movements.ConstAccelCirc2D(leftWheel.radius, leftWheel.accel, ref leftWheel.speed, minLeftWheelSpeed, maxLeftWheelSpeed);

        float carSpeedRight = rightWheel.radius * rightWheel.speed;
        float carSpeedLeft = leftWheel.radius * leftWheel.speed;

        Vector3 dirRight = Mathf.Sign(carSpeedRight) * transform.up + transform.right;
        if (rightWheel.speed < 0.0f)
        {
            dirRight.x *= -1.0f;
            dirRight.y *= -1.0f;
        } 
        dirRight.Normalize();
        
        Vector3 dirLeft = Mathf.Sign(carSpeedLeft) * transform.up - transform.right;
        if (leftWheel.speed < 0.0f)
        {
            dirLeft.x *= -1.0f;
            dirLeft.y *= -1.0f;
        }    
        dirLeft.Normalize();

        transform.position = Physics.Movements.CalculateMRU(transform.position, carSpeedLeft, dirLeft);
        transform.position = Physics.Movements.CalculateMRU(transform.position, carSpeedRight, dirRight);
    }
}
