using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Handles stuff necessary to "eat", and later on mouth animation
/// </summary>
public class MonsterMouth : MonoBehaviour
{
    private Monster _monster;
    private MonsterAudio _audio;

    [SerializeField] private float _eatSpeed = 1;
    [SerializeField] private MunchFX _munchFX;
    [SerializeField] private Transform _mouthOrigin;

    private Queue<Consumable> _foodQueue = new Queue<Consumable>();

    private float _timeSinceLastEat = 0;

    private void Start()
    {
        _monster = GetComponent<Monster>();
        _audio = GetComponent<MonsterAudio>();

        Assert.IsNotNull(_monster);
        Assert.IsNotNull(_audio);
        Assert.IsNotNull(_munchFX);
    }

    private void Update()
    {
        if (_foodQueue.Count > 0)
        {
            if (Time.time - _timeSinceLastEat > _eatSpeed)
            {
                Process(_foodQueue.Dequeue());
                _timeSinceLastEat = Time.time;
            }
        }
    }

    public void Eat(Consumable consumable)
    {
        consumable.transform.position = _mouthOrigin.position;
        consumable.transform.parent = _mouthOrigin;

        _foodQueue.Enqueue(consumable);
    }

    public void Process(Consumable consumable)
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
