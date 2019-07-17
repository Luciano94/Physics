using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonding : MonoBehaviour
{
    [SerializeField]private float minX;
    [SerializeField]private float maxX;
    [SerializeField]private float minY;
    [SerializeField]private float maxY;

    private Vector3 pos;
    void Update()
    {
        pos = transform.position;
        if(transform.position.x > maxX){
            pos.x = maxX;
            transform.position = pos;
        }
        if(transform.position.x < minX){
            pos.x = minX;
            transform.position = pos;
        }
        if(transform.position.y > maxY){
            pos.y = maxY;
            transform.position = pos;
        }
        if(transform.position.y < minY){
            pos.y = minY;
            transform.position = pos;
        }
    }
}
