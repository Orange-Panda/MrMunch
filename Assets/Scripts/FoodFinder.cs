using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFinder : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Consumable"))
        {
            var consumable = other.GetComponent<Consumable>();
            if (consumable is null) return;

            _animator.SetTrigger("Grab");

            //Vector3 heading = other.transform.position - transform.position;
            //float dotProduct = Vector3.Dot(heading, transform.right);
            //// use result for left or right
        }
    }
}
