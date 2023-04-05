using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleGenerator
{
    public class ObstacleGeneratorBehaviour : MonoBehaviour
    {
        [Header("Spawn Set Up")]
        [SerializeField, Tooltip("Drag and drop the obstacle that needs to be spawned here.")]
        private GameObject _obstacle;
        [SerializeField, Tooltip("Set the amount of time it takes to spawn a new obstacle.")]
        private float _spawnDelay;
        [SerializeField, Tooltip("The amount of obstacles to spawn. Set to -1 if obstacle count is infinite.")]
        private int _spawnCount = -1;

        [Header("Randomization")]
        [SerializeField, Tooltip("If true, the location of each obstacle will be spawned a random distance away from the spawner.")]
        private bool _randomizeSpawnLocation;
        [SerializeField, Tooltip("This is the max distance on each axis that randomly spawned objects will appear.")]
        private Vector3 _randomSpawnOffset;

        [Header("Movement")]
        [SerializeField, Tooltip("If true, obstacles that are spawned will move in the given direction.")]
        private bool _moveObstacles;
        [SerializeField, Tooltip("The velocity that will be applied to an obstacle's movement script if movement is allowed.")]
        private Vector3 _obstacleVelocity;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnObstacles());
        }

        /// <summary>
        /// Coroutine to spawn obstacles continuously in a loop.
        /// </summary>
        private IEnumerator SpawnObstacles()
        {
            //Loop until all obstacles have been spawned.
            for (int i = _spawnCount; i != 0; i--)
            {
                //Wait for spawn delay to end before continuing.
                yield return new WaitForSeconds(_spawnDelay);

                Vector3 spawnPosition = transform.position;
                
                //If the location should be randomized...
                if (_randomizeSpawnLocation)
                {
                    //...calculate a random value for each axis and add it to the spawner position to get an offset.
                    float randX = Random.Range(-_randomSpawnOffset.x, _randomSpawnOffset.x);
                    float randY = Random.Range(-_randomSpawnOffset.y, _randomSpawnOffset.y);
                    float randZ = Random.Range(-_randomSpawnOffset.z, _randomSpawnOffset.z);

                    spawnPosition = transform.position + new Vector3(randX, randY, randZ);
                }

                //Spawn obstacle at the new position, but keep its original rotation.
                GameObject obstacle = Instantiate(_obstacle, spawnPosition, _obstacle.transform.rotation);

                //If obstacles should be moved...
                if (_moveObstacles)
                {
                    //...attach the movement script and assign the velocity.
                    ObstacleMovementBehaviour movement = obstacle.AddComponent<ObstacleMovementBehaviour>();
                    movement.Velocity = _obstacleVelocity;
                }
            }
        }
    }
}