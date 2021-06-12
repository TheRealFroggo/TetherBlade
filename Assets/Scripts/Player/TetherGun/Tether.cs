using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public GameObject TetherEndLeft;
    public GameObject TetherEndRight;

    public GameObject Object1 = null;
    public GameObject Object2 = null;

    public SliderJoint2D Joint = null;
    private LineRenderer LineRenderer;

    private bool JointHasBeenCreated = false;

    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RenderLine();
        if (!Joint)
            CheckCreateJoint();
    }

    void FixedUpdate()
    {
        ShouldDestroy();
    }

    void RenderLine()
    {
        if (Object1)
        {
            LineRenderer.SetPosition(0, Object1.transform.position);
            if (Object2)
            {
                LineRenderer.SetPosition(1, Object2.transform.transform.position);
                return;
            }
            if (TetherEndLeft)
            {
                LineRenderer.SetPosition(1, TetherEndLeft.transform.transform.position);
                return;
            }
            if (TetherEndRight)
            {
                LineRenderer.SetPosition(1, TetherEndRight.transform.transform.position);
                return;
            }
        }
        else
        {
            if (TetherEndLeft != null && TetherEndRight != null)
            {
                LineRenderer.SetPosition(0, TetherEndLeft.transform.position);
                LineRenderer.SetPosition(1, TetherEndRight.transform.position);
            }
        }
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

            JointHasBeenCreated = true;
        }
    }

    void ShouldDestroy()
    {
        if (!JointHasBeenCreated)
        {
            if (TetherEndLeft == null && TetherEndRight == null)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (Object1 == null || Object2 == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
