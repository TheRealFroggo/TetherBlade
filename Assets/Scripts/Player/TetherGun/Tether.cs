using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public Projectile TetherEndLeft;
    public Projectile TetherEndRight;

    public GameObject Object1;
    public GameObject Object2;

    public SliderJoint2D Joint = null;

    void Update()
    {
        if (!Joint)
            CheckCreateJoint();
        
    }

    void CheckCreateJoint()
    {
        if (Object1 && Object2 && !Joint)
        {
            Joint = Object1.AddComponent<SliderJoint2D>();
            Joint.connectedBody = Object2.GetComponent<Rigidbody2D>();
            Joint.enableCollision = true;
            Joint.useMotor = true;

            JointMotor2D motor = Joint.motor;
            motor.motorSpeed = -10;
            Joint.motor = motor;
        }
    }
}
