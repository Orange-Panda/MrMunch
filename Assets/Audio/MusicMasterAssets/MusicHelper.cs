using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicMaster 
{
	public class MusicHelper : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
            DontDestroyOnLoad(gameObject);

			MusicController._Start();
		}

		// Update is called once per frame
		void Update()
		{
			MusicController._Update();
		}
	}
}

