using UnityEngine;
using Physics;
public class Enemy : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float KillY = -3;
    private Vector3 dir;

    private void Start() {
        dir = new Vector3(0,-1,0);
        CollisionManager.Instance.addBox(GetComponent<Box>());
    }

    private void Update() {
        transform.position = Physics.Movements.CalculateMRU(transform.position,speed,dir);
        if(transform.position.y <= KillY){
            CollisionManager.Instance.removeBox(GetComponent<Box>());
            Destroy(gameObject);
        }
    }
}
