using UnityEngine;
using Physics;

public class PlayerMCU : MonoBehaviour{
    public Wheel leftWheel;
    public Wheel rightWheel;
    public float actualSpeed;
    public float acceleration;
    public float friction;
    public float yLimit;
    public float xLimit;
    private float timer;

    private void Update(){
        timer = Time.deltaTime;
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Z)){
            if (Input.GetKey(KeyCode.A))
                leftWheel.speed += acceleration * timer;
            if (Input.GetKey(KeyCode.Z))
                leftWheel.speed -= acceleration * timer;
        }
        else if(leftWheel.speed != 0){
            leftWheel.speed = Mathf.Lerp(leftWheel.speed, 0, friction);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.C)){
            if (Input.GetKey(KeyCode.D))
                rightWheel.speed += acceleration * timer;
            if (Input.GetKey(KeyCode.C))
                rightWheel.speed -= acceleration * timer;
        }
        else if (rightWheel.speed != 0){
            rightWheel.speed = Mathf.Lerp(rightWheel.speed, 0, friction );
        }

        if (leftWheel.TractionForce() == rightWheel.TractionForce()){
                transform.position = Physics.Movements.CalculateMRU(transform.position, rightWheel.TractionForce(), Vector3.up);
        }else if(leftWheel.TractionForce() > rightWheel.TractionForce()){
                transform.position = Physics.Movements.CalculateMRU(transform.position, 
                            leftWheel.TractionForce() + rightWheel.TractionForce(), Vector3.up + Vector3.left);
        }
        else if (leftWheel.TractionForce() < rightWheel.TractionForce()){
            transform.position = Physics.Movements.CalculateMRU(transform.position,
                                 rightWheel.TractionForce() + leftWheel.TractionForce(), Vector3.up + Vector3.right);
        }
        if (transform.position.y > 0 && leftWheel.TractionForce() == 0 && rightWheel.TractionForce() == 0) { 
            transform.position = Physics.Movements.CalculateMRU(transform.position,acceleration, Vector3.down);
        }

    }
       /* float axis = Input.GetAxis("Horizontal");
        if(axis == 0 ){
            if(Input.GetKey(KeyCode.LeftArrow) && transform.position.y < yLimit){
                leftWheel.speed += speed;
                rightWheel.speed += speed;
                transform.position = Physics.Movements.CalculateMRU(transform.position, 
                (rightWheel.TractionForce()+leftWheel.TractionForce()) * 0.5f, Vector3.up);
            }else{
                leftWheel.speed = 0;
                rightWheel.speed = 0;
                if(transform.position.y > 0)
                    transform.position = Physics.Movements.CalculateMRU(transform.position,
                                                     speed * Time.deltaTime, Vector3.down);
            }
        }else{
            if(axis > 0){
                leftWheel.speed += axis * speed * Time.deltaTime;
                transform.position = Physics.Movements.CalculateMRU(transform.position, 
                                    leftWheel.TractionForce(), Vector3.up + Vector3.right);
            }else{
                rightWheel.speed += axis * speed * Time.deltaTime *-1 ;
                transform.position = Physics.Movements.CalculateMRU(transform.position, 
                                    rightWheel.TractionForce(), Vector3.up + Vector3.left);
            }
        }*/
}
