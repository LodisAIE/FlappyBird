using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
