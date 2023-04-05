using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleGenerator
{
    public class ObstacleMovementBehaviour : MonoBehaviour
    {
        private Vector3 _velocity;

        public Vector3 Velocity { get => _velocity; set => _velocity = value; }

        // Update is called once per frame
        void FixedUpdate()
        {
            transform.position += Velocity * Time.deltaTime;
        }
    }
}