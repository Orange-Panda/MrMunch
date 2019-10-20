using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicMaster
{
	public static class MusicController
	{
		public static int CurrentSong = 0;
		public static Dictionary<int, Dictionary<int, MusicSync>> Songs = new Dictionary<int, Dictionary<int, MusicSync>>(2);

		public static float GlobalVolume = 1f;

		private static float gameProgress = 0;

		private static bool hasStarted = false;

		public static void _Start()
		{
			if (hasStarted){ return; } 
			hasStarted = true;

			Songs.Add(0,new Dictionary<int,MusicSync>(5)); // Song 0
			Songs.Add(1, new Dictionary<int, MusicSync>(4)); // Song 1
			Songs.Add(2, new Dictionary<int, MusicSync>(4)); // Song 2
		}

		public static void AddTrack(int songId, int trackId, MusicSync newTrack)
		{
			if (hasStarted == false) { _Start(); }

			Songs[songId].Add(trackId, newTrack);
		}

		public static void FadeInTrack(MusicSync track, float time)
		{
			track.Volume = 0;
			track.Mute = false;
			track.FadeSpeed = (1f/time)*(1f/60f);
		}

		public static void _Update()
		{
			int currentGlobalSample = -1;
			foreach(KeyValuePair<int, MusicSync> trackpair in Songs[CurrentSong])
			{
				MusicSync track = trackpair.Value;
				if (currentGlobalSample >= 0)
				{
					track.CurrentSample = currentGlobalSample;
				}
				else
				{
					currentGlobalSample = track.CurrentSample;
				}

				if (track.Volume < 1)
				{
					track.Volume += track.FadeSpeed;
				}
				else if (track.Volume > 1)
				{
					track.Volume += 1;
				}
			}
		}

		public static void PlaySong(int song)
		{
			if (hasStarted == false)
			{
				Debug.Assert(true, "MusicController.PlaySong() was called too fast, the tracks have not registered themselves yet!");
				return;
			}

			foreach (KeyValuePair<int, MusicSync> trackpair in Songs[CurrentSong])
			{
				MusicSync track = trackpair.Value;
				track.Stop();
				track.Mute = true;
				track.Volume = 0;
				track.FadeSpeed = (1f / 60f);
			}

			CurrentSong = song;

			foreach (KeyValuePair<int, MusicSync> trackpair in Songs[CurrentSong])
			{
				MusicSync track = trackpair.Value;
				track.Play();
				track.Mute = true;
				track.Volume = 0;
				track.FadeSpeed = (1f / 60f);
			}

			if (CurrentSong == 0)
			{
				Songs[CurrentSong][0].Mute = false;
			}
			if (CurrentSong == 1)
			{
				Songs[CurrentSong][0].Mute = false;
			}
			if (CurrentSong == 2)
			{
				Songs[CurrentSong][0].Mute = false;
				Songs[CurrentSong][1].Mute = false;
				Songs[CurrentSong][2].Mute = false;
				Songs[CurrentSong][3].Mute = false;
			}

		}

		public static void SetProgress(float progress)
		{
			if (CurrentSong == 0)
			{
				if (progress >= (4f / 5f) && gameProgress < (4f / 5f))
				{
					FadeInTrack(Songs[CurrentSong][4], 5f);
				}
				if (progress >= (3f / 5f) && gameProgress < (3f / 5f))
				{
					FadeInTrack(Songs[CurrentSong][3], 5f);
				}
				if (progress >= (2f / 5f) && gameProgress < (2f / 5f))
				{
					FadeInTrack(Songs[CurrentSong][2], 5f);
				}
				if (progress >= (1f / 5f) && gameProgress < (1f / 5f))
				{
					FadeInTrack(Songs[CurrentSong][1], 5f);
				}
			}

			if (CurrentSong == 1)
			{
				if (progress >= (3f / 4f) && gameProgress < (3f / 4f))
				{
					FadeInTrack(Songs[CurrentSong][3], 5f);
				}
				if (progress >= (2f / 4f) && gameProgress < (2f / 4f))
				{
					FadeInTrack(Songs[CurrentSong][2], 5f);
				}
				if (progress >= (1f / 4f) && gameProgress < (1f / 4f))
				{
					FadeInTrack(Songs[CurrentSong][1], 5f);
				}
			}



			gameProgress = progress;
		}


	}
}

