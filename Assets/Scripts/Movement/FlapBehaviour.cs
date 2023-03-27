using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlapBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _jumpPower;
    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.VelocityChange);
        }
    }
}
