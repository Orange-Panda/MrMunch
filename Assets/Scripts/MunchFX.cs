using UnityEngine;

/// <summary>
/// Manages playing the particle system for food crumbs
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class MunchFX : MonoBehaviour
{
    private ParticleSystem _system;
    private ParticleSystemRenderer _renderer;

    private void Start()
    {
        _system = GetComponent<ParticleSystem>();
        _renderer = _system.GetComponent<ParticleSystemRenderer>();
    }

    /// <summary>
    /// Plays the particle system with the given mesh and material data
    /// </summary>
    /// <remarks>
    /// Particle system works like an audio One-shot
    /// </remarks>
    /// <param name="type">Object type</param>
    public void PlayMunchParticles(MunchType type)
    {
        _renderer.mesh = type.ParticleMesh;
        _renderer.material = type.ParticleMaterial;

        _system.Play();
    }
}
