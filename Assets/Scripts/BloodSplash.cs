using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplash : MonoBehaviour
{
    public float Lifetime;
    private float MaxLifetime;

    void Start()
    {
        MaxLifetime = Lifetime;
    }

    void Update()
    {
        Lifetime -= Time.deltaTime;

        if (Lifetime < 0.0f)
            Destroy(gameObject);
    }
}
