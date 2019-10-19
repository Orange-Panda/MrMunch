using UnityEngine;

public enum MonsterScale
{
    Tiny,
    Small,
    Medium,
    Large,
    Huge
}

/// <summary>
/// Marks a game object as consumable for the player
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class Consumable : MonoBehaviour
{
    [Tooltip("How big must the monster be to eat?")]
    [SerializeField] private MonsterScale _sizeRequirement;
    [Tooltip("How much should this fill up the monster?")]
    [SerializeField] private float _fillAmount;
    [Tooltip("What type of item is this?")]
    [SerializeField] private MunchType _type;

    public MonsterScale SizeRequirement => _sizeRequirement;
    public float FillAmount => _fillAmount;
    public MunchType Type => _type;

    // Allows checking to see if it is in the queue for the hand to grab yet
    [HideInInspector] public bool Flagged = false;


    // Cache this so we can disable it whenever it gets parented
    [HideInInspector] public Collider Collider;

    private void Start()
    {
        Collider = GetComponent<Collider>();
    }
}
