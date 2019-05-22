using UnityEngine;
using Physics;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPos.x = Physics.Movements.CalculateMRU(newPos.x, -speed);
            transform.position = newPos;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPos.x = Physics.Movements.CalculateMRU(newPos.x, speed);
            transform.position = newPos;
        }

    }
}
