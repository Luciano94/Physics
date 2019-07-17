using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Physics;
using UnityEngine.SceneManagement;
public class CollisionManager : MonoBehaviour
{
    [SerializeField]private List<Box> objects;

    private static CollisionManager instance;

    public static CollisionManager Instance {
        get {
            instance = FindObjectOfType<CollisionManager>();
            if(instance == null) {
                GameObject go = new GameObject("CollisionManager");
                instance = go.AddComponent<CollisionManager>();
            }
            return instance;
        }
    }
    private void Awake() {
        objects = new List<Box>();
    }

    private void Update() {
        if(objects != null){
            foreach (var box1 in objects)
            {
                foreach (var box2 in objects)
                {
                    if(box1 != box2 && box1.layer != box2.layer)
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

    public void addBox(Box b){
        objects.Add(b);
    }

    public void removeBox(Box b){
        objects.Remove(b);
    }
}
