using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
	private CinemachineFreeLook freeLook;
	private Monster monster;

	private Dictionary<MonsterScale, CameraProperties> cameraProperties = new Dictionary<MonsterScale, CameraProperties>() {
		{ MonsterScale.Tiny, new CameraProperties(new CinemachineFreeLook.Orbit(1, 2), new CinemachineFreeLook.Orbit(0.5f, 1.5f), new CinemachineFreeLook.Orbit(0.3f, 1f)) },
		{ MonsterScale.Small, new CameraProperties(new CinemachineFreeLook.Orbit(1, 2), new CinemachineFreeLook.Orbit(0.5f, 1.5f), new CinemachineFreeLook.Orbit(0.3f, 1f))  },
		{ MonsterScale.Medium, new CameraProperties(new CinemachineFreeLook.Orbit(5, 10), new CinemachineFreeLook.Orbit(2.5f, 6), new CinemachineFreeLook.Orbit(0.5f, 3)) },
		{ MonsterScale.Large, new CameraProperties(new CinemachineFreeLook.Orbit(5, 10), new CinemachineFreeLook.Orbit(2.5f, 6), new CinemachineFreeLook.Orbit(0.5f, 3)) },
		{ MonsterScale.Huge, new CameraProperties(new CinemachineFreeLook.Orbit(5, 10), new CinemachineFreeLook.Orbit(2.5f, 6), new CinemachineFreeLook.Orbit(0.5f, 3)) }
	};

	private void Awake()
	{
		freeLook = GetComponent<CinemachineFreeLook>();
		SetCameraScale(MonsterScale.Tiny);
		InvokeRepeating("CheckForPlayer", 0f, 1f);
	}
	
	public void CheckForPlayer()
	{
		if (monster == null)
		{
			if (monster = FindObjectOfType<Monster>())
			{
				freeLook.Follow = monster.transform;
				freeLook.LookAt = monster.transform;
			}
		}

		SetCameraScale(monster.Scale);
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