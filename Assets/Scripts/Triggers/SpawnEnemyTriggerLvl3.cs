using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemyTriggerLvl3 : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    private bool spawned = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "CharacterLvl3" && !spawned)
        {
            Debug.Log("DONKKKKK");
            spawned = true;
            foreach(Transform spawnPoint in _spawnPoints)
            {
                Instantiate(
                    _enemyPrefab,
                    spawnPoint.position, spawnPoint.rotation);
            }
        }
        Destroy(this.gameObject);
    }
}
 