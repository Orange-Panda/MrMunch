using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Handles stuff necessary to "eat", and later on mouth animation
/// </summary>
public class MonsterMouth : MonoBehaviour
{
    private Monster _monster;
    private MonsterAudio _audio;
    [SerializeField] private MunchFX _munchFX;
    
    private void Start()
    {
        _monster = GetComponent<Monster>();
        _audio = GetComponent<MonsterAudio>();

        Assert.IsNotNull(_monster);
        Assert.IsNotNull(_audio);
        Assert.IsNotNull(_munchFX);
    }

    public void Eat(Consumable consumable)
    {
        // Fill bar
        _monster.Fullness += consumable.FillAmount;

        // Play Audio
        _audio.PlayMunchSound(consumable.Type);

        // Play FX
        _munchFX.PlayMunchParticles(consumable.Type);

        // Destroy consumable
        Destroy(consumable.gameObject);

        // etc.
    }
}
