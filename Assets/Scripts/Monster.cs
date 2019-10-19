using UnityEngine;

public class Monster : MonoBehaviour
{
	[SerializeField] private float _fullness;
	[SerializeField] private float _max;

	private Material _material;

	public float PercentageFull => _fullness / _max;

	public float Fullness
	{
		get => _fullness;

		set
		{
			_fullness = value;
			AdjustColor();
			CheckValue();
		}
	}

	private void Start()
	{
		//_material = GetComponent<Renderer>().material;
	}

	public void AdjustColor()
	{
		// Change color over time
		_material.color += new Color(PercentageFull, 0, 0, 0);
	}

	public void CheckValue()
	{
		// Explode after threshold
	}
}
