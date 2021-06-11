using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherGunRotation : MonoBehaviour
{
    public bool isGunFlipped;

    void Update()
    {
        GameObject Player = transform.parent.gameObject;
        Camera m_Camera = Camera.main;

        Vector3 playerPos = Player.transform.position;

        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePos3D = m_Camera.ScreenToWorldPoint(mousePos);

        Vector3 LookAtDirection = (mousePos3D - playerPos);
        float Angle = Mathf.Atan2(LookAtDirection.x, LookAtDirection.y) * Mathf.Rad2Deg - 90.0f;
        Quaternion rotation = Quaternion.AngleAxis(-Angle, Vector3.forward);

        transform.rotation = rotation;

        if (Mathf.Abs(transform.rotation.z) < Mathf.Cos(Mathf.PI / 4))
        {
            GetComponent<SpriteRenderer>().flipY = false;
            isGunFlipped = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = true;
            isGunFlipped = true;
        }
    }
}
