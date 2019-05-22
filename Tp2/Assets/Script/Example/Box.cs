using UnityEngine;
using Physics;

public class Box : MonoBehaviour
{
    public Physics.Box box;

    private void Start()
    {
        box = new Physics.Box();
        box.pos = transform.position;
        box.width = 1;
        box.height = 1;
    }

    private void Update()
    {
        box.pos = transform.position;
    }
}
