using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public GameObject Player;
    public float MovementSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
          Player.transform.position, MovementSpeed * Time.deltaTime);
    }
}
