using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private MonsterMouth _mouth;
    [SerializeField] private bool _useAnimationEvents = true;

    private List<Consumable> _pickUps = new List<Consumable>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Consumable"))
        {
            var consumable = other.GetComponent<Consumable>();
            if (consumable is null) return;

            _pickUps.Add(consumable);
            consumable.Collider.enabled = false;

            if (_useAnimationEvents)
            {
                other.transform.position = transform.position;
                other.transform.parent = transform;
            }
            else EatPickUps();
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
