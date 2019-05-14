using UnityEngine;
using UnityEngine.AI;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject[] enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

       public int enemyAmoun = 0;
        public int enemyMax = 10;

        public int EnemyAmoun
        {
            get
            {
                return enemyAmoun;
            }

            set
            {
                enemyAmoun = value;
            }
        }

        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }


        void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f || EnemyAmoun == enemyMax)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            int spawnEnemytIndex = Random.Range(0, enemy.Length);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate (enemy[spawnEnemytIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            EnemyAmoun++;
        }
    }
}