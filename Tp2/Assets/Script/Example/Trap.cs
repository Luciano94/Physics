using UnityEngine;
using Physics;

public class Trap : MonoBehaviour
{
    [SerializeField]private GameObject Objpos;
    [SerializeField]private float speed = 10;
    [SerializeField]private float radio = 1;
    private float angle;

    private void Start() {
        angle = 0;
    }

    private void Update() {
        angle += (Time.deltaTime * speed);

        if (angle == 360){
            angle = 0;
        }

        Objpos.transform.position = Physics.Movements.CalculateMCU(transform.position, radio, angle);
    }
}
