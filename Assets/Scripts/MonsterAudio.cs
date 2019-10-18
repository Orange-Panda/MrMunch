using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Handles playing audio clips for the monster
/// </summary>
public class MonsterAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _mouthSource;

    private void Start()
    {
        Assert.IsNotNull(_mouthSource);
    }

    /// <summary>
    /// Play a one-shot of the object type's munch sound clip
    /// </summary>
    /// <param name="type">Object type</param>
    public void PlayMunchSound(MunchType type)
    {
        _mouthSource.PlayOneShot(type.Clip);
    }
}
