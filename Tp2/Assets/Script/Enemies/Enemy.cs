using UnityEngine;
using Physics;
public class Enemy : MonoBehaviour
{
    [SerializeField]private float speed;
    private Vector3 dir;

    private void Start() {
        dir = new Vector3(0,-1,0);
        CollisionManager.Instance.addBox(transform.GetComponent<Box>());
    }

    private void Update() {
        transform.position = Physics.Movements.CalculateMRU(transform.position,speed,dir);
    }
}
