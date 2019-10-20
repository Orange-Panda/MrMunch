using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarCrash : MonoBehaviour
{
    [SerializeField] private int _spawnAmount;
    [SerializeField] private List<GameObject> _carPrefabs;


    public void Smash()
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            Instantiate(_carPrefabs[Random.Range(0, _carPrefabs.Count)], transform.position, Quaternion.identity, null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
