using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    [SerializeField] private Hand _leftHand;
    [SerializeField] private Hand _rightHand;

    private void LeftHand()
    {
        _leftHand.EatPickUps();
    }

    private void RightHand()
    {
        _rightHand.EatPickUps();
    }
}
