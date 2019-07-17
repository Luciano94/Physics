using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField]private GameObject roadOne;
    [SerializeField]private GameObject roadTwo;

    [SerializeField]private Transform up;
    [SerializeField]private Transform down;
    

    private int actual = 0;

    // Start is called before the first frame update
    void Start()
    {
        actual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(actual == 0){
            if(roadOne.transform.position.y <= down.position.y){
                roadOne.transform.position = up.position;
                actual = 1;
            }
                Debug.Log(roadOne.transform.position + "    " + down.position + "   " + actual);
        }
        if(actual == 1){
            if(roadTwo.transform.position.y <= down.position.y){
                roadTwo.transform.position = up.position;
                actual = 0;
            }
        }
    }
}
