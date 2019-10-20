using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startTimeMinutes;
    [SerializeField] private float _startTimeSeconds;

    public float TimeRemaining { get; private set; }
	public float StartTime => (_startTimeMinutes * 60) + _startTimeSeconds;

    [SerializeField] private bool _running = false;

    private TMPro.TMP_Text _text;

    private void Start()
    {
        //_text = GetComponent<TMPro.TMP_Text>();
        TimeRemaining = _startTimeSeconds + _startTimeMinutes * 60;
    }

    private void Update()
    {
        if (_running)
        {
            TimeRemaining -= Time.deltaTime;

            var minutes = Mathf.Floor(TimeRemaining / 60).ToString("00");
            var seconds = Mathf.RoundToInt(TimeRemaining % 60).ToString("00");

            //_text.text = $"{minutes}:{seconds}";
        }
    }
}
