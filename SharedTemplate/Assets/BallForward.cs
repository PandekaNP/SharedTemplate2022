using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForward : MonoBehaviour
{
    int distanceTravelled = 90;
    [SerializeField] Transform player;
    [SerializeField,Range(0.125f, 5f)] float smoothSpeed;

    void Start()
    {
        smoothSpeed = 1f;
    }
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (transform.position.z < distanceTravelled)
        {
            transform.Translate(0, 0, smoothSpeed * Time.deltaTime);
        }
    }
}
