using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform targetPlayer;
    public float speed;
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    // Update is called once per frame
   // void Update()
   // {
   //     transform.position = Vector2.MoveTowards
    //}
}
