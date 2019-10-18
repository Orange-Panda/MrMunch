using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Handles procedural hand movement towards objects
/// </summary>
public class HandIK : MonoBehaviour
{
    [SerializeField] private Transform _handIKBone;
    [SerializeField] private Transform _handOrigin;
    [SerializeField] private Transform _mouthOrigin;

    [SerializeField] private Animator _animator;
    [SerializeField] private float _grabSpeed;

    [SerializeField] private MonsterMouth _mouth;

    private Queue<Consumable> _foodQueue = new Queue<Consumable>();

    private IEnumerator _routine;

    // Todo: implement
    private bool _hasEaten = false;

    private void Update()
    {
        // Todo: Something is wrong here!
        //if (_foodQueue.Count > 0 && (_routine is null || _hasEaten))
        //{
        //    Consumable target = null;

        //    while (target == null && _foodQueue.Count > 0)
        //    {
        //        target = _foodQueue.Dequeue();

        //        // handle out of range food
        //        // Todo: make this use the trigger collider
        //        if (Vector3.Distance(_mouth.transform.position, target.transform.position) > 3f)
        //        {
        //            target.Flagged = false;
        //            target.GetComponent<Renderer>().material.color = Color.red;
        //            target = null;
        //        }
        //        else
        //        {
        //            if (_hasEaten)
        //            {
        //                if (_routine != null) StopCoroutine(_routine);
        //            }
        //            _routine = GrabRoutine(target);
        //            StartCoroutine(_routine);
        //        }
        //    }
        //}

        if (_foodQueue.Count > 0 && _routine == null)
        {
            //if (_hasEaten && _routine != null) StopCoroutine(_routine);
            _routine = GrabRoutine(_foodQueue.Dequeue());
            StartCoroutine(_routine);
        }
    }

    public void Grab(Consumable consumable)
    {
        if (!consumable.Flagged)
        {
            consumable.Flagged = true;
            _foodQueue.Enqueue(consumable);
        }
    }

    private IEnumerator GrabRoutine(Consumable consumable)
    {
        var consumableCollider = consumable.GetComponent<Collider>();
        if (consumableCollider != null) consumableCollider.enabled = false;

        yield return StartCoroutine(LerpTo(_handIKBone, _handOrigin, consumable.transform, _grabSpeed));

        consumable.transform.parent = _handIKBone;

        yield return StartCoroutine(LerpTo(_handIKBone, _handIKBone, _mouthOrigin, _grabSpeed, .95f));
        
        _mouth.Eat(consumable);
        _hasEaten = true;

        yield return StartCoroutine(LerpTo(_handIKBone, _handIKBone, _handOrigin, _grabSpeed));

        _hasEaten = false;
        _routine = null;
    }

    private IEnumerator LerpTo(Transform move, Transform start, Transform finish, float speed, float finishAfter = 1)
    {
        bool isFinished = false;
        float startTime = Time.time;
        float totalLength = Vector3.Distance(start.position, finish.position);

        while (!isFinished)
        {
            float distanceCovered = (Time.time - startTime) * _grabSpeed;
            float percentageCovered = distanceCovered / totalLength;

            move.position = Vector3.Lerp(start.position, finish.position, percentageCovered);

            if (percentageCovered >= finishAfter) isFinished = true;

            yield return null;
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //_animator.SetBoneLocalRotation();
        //_handIKBone.localRotation = Quaternion.LookRotation();
    }
}
