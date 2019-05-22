using UnityEngine;
using Physics;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]private Box[] objects;

    private void Update() {
        if(objects != null){
            foreach (var box1 in objects)
            {
                foreach (var box2 in objects)
                {
                    if(box1 != box2)
                    {
                        if(Physics.Collisions.CompareBox(box1.box, box2.box))
                        {
                            SceneManager.LoadScene(0);
                        }
                    }
                }
            }
        }
    }
}
