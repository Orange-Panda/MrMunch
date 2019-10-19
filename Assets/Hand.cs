using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private MonsterMouth _mouth;

    private List<Consumable> _pickUps = new List<Consumable>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Consumable"))
        {
            var consumable = other.GetComponent<Consumable>();
            if (consumable != null)
                _pickUps.Add(consumable);

            other.transform.parent = transform;
        }
    }

    public void EatPickUps()
    {
        for (int i = 0; i < _pickUps.Count; i++)
        {
            _mouth.Eat(_pickUps[i]);
        }

        if (_pickUps.Count > 0) _pickUps.Clear();
    }
}
