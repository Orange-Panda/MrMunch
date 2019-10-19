﻿using UnityEngine;

/// <summary>
/// Sort of an extendable data holding enum for different item types
/// e.g. a car is going to make metallic crunching sounds and might have a different particle effect than a tree
/// </summary>
[CreateAssetMenu(fileName = "Munch Type", menuName = "Scriptable Objects/Munch Type")]
public class MunchType : ScriptableObject
{
    [Header("Particle System Variables")]
    [SerializeField] private Mesh _munchMesh;
    [SerializeField] private Material _munchMaterial;

    [Header("Audio Variables")]
    [SerializeField] private AudioClip _munchSound;

    public Mesh ParticleMesh => _munchMesh;
    public Material ParticleMaterial => _munchMaterial;

    public AudioClip Clip => _munchSound;
}