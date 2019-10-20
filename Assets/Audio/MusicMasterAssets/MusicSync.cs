using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicMaster;

namespace MusicMaster
{
	public class MusicSync : MonoBehaviour
	{
		AudioSource myAudioSource;
		public int SongIndexNumber;
		public int TrackIndexNumber;

		float _FadeSpeed = (1f / 60f);
		public float FadeSpeed { get { return _FadeSpeed; } set { _FadeSpeed = value; } }

		public int CurrentSample 
		{ 
			get { return myAudioSource.timeSamples; } 
			set { myAudioSource.timeSamples = value; }
		}
		public float Volume 
		{ 
			get { return myAudioSource.volume / MusicController.GlobalVolume; } 
			set { myAudioSource.volume = value * MusicController.GlobalVolume; } 
		}
		public bool Mute 
		{
			get { return myAudioSource.mute; }
			set { myAudioSource.mute = value; } 
		}
		public bool Loop
		{
			get { return myAudioSource.loop; }
			set { myAudioSource.loop = value; }
		}


		// Start is called before the first frame update
		void Start()
		{
			myAudioSource = gameObject.GetComponent<AudioSource>();
			myAudioSource.loop = true;
			MusicController.AddTrack(SongIndexNumber, TrackIndexNumber, this);
		}

		public void Play() { myAudioSource.Play(); }
		public void Stop() { myAudioSource.Stop(); }


	}
}
