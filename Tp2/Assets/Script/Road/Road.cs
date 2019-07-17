using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField]private float speed;
    private Vector3 dir;

    private void Start() {
        dir = new Vector3(0,-1,0);
    }

    private void LateUpdate() {
        transform.position = Physics.Movements.CalculateMRU(transform.position,speed,dir);
    }
}
