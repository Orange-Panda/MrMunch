using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
	private CinemachineFreeLook freeLook;

	private Dictionary<MonsterScale, CameraProperties> cameraProperties = new Dictionary<MonsterScale, CameraProperties>() {
		{ MonsterScale.Tiny, new CameraProperties(new CinemachineFreeLook.Orbit(1, 2), new CinemachineFreeLook.Orbit(0.5f, 1.5f), new CinemachineFreeLook.Orbit(0.3f, 1f)) },
		{ MonsterScale.Small, new CameraProperties(new CinemachineFreeLook.Orbit(2, 3), new CinemachineFreeLook.Orbit(1.5f, 3), new CinemachineFreeLook.Orbit(0.5f, 3)) },
		{ MonsterScale.Medium, new CameraProperties(new CinemachineFreeLook.Orbit(2, 3), new CinemachineFreeLook.Orbit(1.5f, 3), new CinemachineFreeLook.Orbit(0.5f, 3)) },
		{ MonsterScale.Large, new CameraProperties(new CinemachineFreeLook.Orbit(2, 3), new CinemachineFreeLook.Orbit(1.5f, 3), new CinemachineFreeLook.Orbit(0.5f, 3)) },
		{ MonsterScale.Huge, new CameraProperties(new CinemachineFreeLook.Orbit(2, 3), new CinemachineFreeLook.Orbit(1.5f, 3), new CinemachineFreeLook.Orbit(0.5f, 3)) }
	};

	private void Awake()
	{
		freeLook = GetComponent<CinemachineFreeLook>();
		SetCameraScale(MonsterScale.Tiny);
		InvokeRepeating("CheckForPlayer", 0f, 1f);
	}
	
	public void CheckForPlayer()
	{
		if (freeLook.Follow == null)
		{
			Transform target;
			if (target = FindObjectOfType<Monster>().transform)
			{
				freeLook.Follow = target;
				freeLook.LookAt = target;
			}
		}
	}

	/// <summary>
	/// Sets the scale of the camera based on the given monster scale.
	/// </summary>
	public void SetCameraScale(MonsterScale scale)
	{
		freeLook.m_Orbits[0] = cameraProperties[scale].topRig;
		freeLook.m_Orbits[1] = cameraProperties[scale].midRig;
		freeLook.m_Orbits[2] = cameraProperties[scale].botRig;
	}
}

/// <summary>
/// Saves the scales needed for the camera.
/// </summary>
public struct CameraProperties
{
	public CinemachineFreeLook.Orbit topRig;
	public CinemachineFreeLook.Orbit midRig;
	public CinemachineFreeLook.Orbit botRig;

	public CameraProperties(CinemachineFreeLook.Orbit topRig, CinemachineFreeLook.Orbit midRig, CinemachineFreeLook.Orbit botRig)
	{
		this.topRig = topRig;
		this.midRig = midRig;
		this.botRig = botRig;
	}
}