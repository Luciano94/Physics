using UnityEngine;
using Physics;

public class PlayerMCU : MonoBehaviour{
    public Wheel leftWheel;
    public Wheel rightWheel;
    public float speed;
    public float yLimit;
    public float xLimit;

    private void Update()
    {
        float axis = Input.GetAxis("Horizontal");
        if(axis == 0 ){
            if(Input.GetKey(KeyCode.LeftArrow) && transform.position.y < yLimit){
                Debug.Log("Entre");
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
        }
    }
}
