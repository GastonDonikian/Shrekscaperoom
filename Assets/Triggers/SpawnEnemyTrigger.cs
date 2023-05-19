using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            foreach(Transform spawnPoint in _spawnPoints)
            {
                Instantiate(
                    _enemyPrefab,
                    spawnPoint.position, spawnPoint.rotation);
            }
            Destroy(gameObject);
        }
    }
}
 