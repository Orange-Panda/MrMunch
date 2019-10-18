using UnityEngine;

/// <summary>
/// Marks a game object as consumable for the player
/// </summary>
public class Consumable : MonoBehaviour
{
    [Tooltip("How much should this fill up the monster?")]
    [SerializeField] private float _fillAmount;
    [Tooltip("What type of item is this?")]
    [SerializeField] private MunchType _type;

    public float FillAmount => _fillAmount;
    public MunchType Type => _type;

    // Allows checking to see if it is in the queue for the hand to grab yet
    [HideInInspector] public bool Flagged = false;
}
