using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlapBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _jumpPower;
    [SerializeField]
    private ParticleSystem _deathEffect;
    private Rigidbody _rigidBody;
    private bool _isAlive;

    public bool IsAlive { get => _isAlive; }

    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _isAlive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Pipe"))
            return;

        gameObject.SetActive(false);
        _isAlive = false;
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Pipe"))
            return;

        GameManagerBehaviour.Score++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.VelocityChange);
        }
    }
}
