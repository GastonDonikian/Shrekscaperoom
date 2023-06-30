using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    private bool spawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character" && !spawned)
        {
            spawned = true;
            foreach(Transform spawnPoint in _spawnPoints)
            {
                Instantiate(
                    _enemyPrefab,
                    spawnPoint.position, spawnPoint.rotation);
            }
        }
        Invoke("setSpawned", 5f);
    }

    private void setSpawned()
    {
        spawned = false;
    }
}
 