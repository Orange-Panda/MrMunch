using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MusicMaster;

public class CallMusicExample : MonoBehaviour
{
    private Monster monster;

	public float Progress;
	bool playedSong = false;

    // Start is called before the first frame update
    void Start()
    {
        monster = FindMonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (monster == null) monster = FindMonster();
        else
        {
            if (playedSong == false)
            {
                playedSong = true;
                MusicController.PlaySong(1);
            }
            MusicController.SetProgress(monster.PercentageFull); // 0 = starting, .5 = halfway there, 1 = finished!

            Progress = monster.PercentageFull;
        }
    }

    public Monster FindMonster()
    {
        var monster = FindObjectOfType<Monster>();
        if (monster == null) Debug.LogWarning("Could not find monster!");
        return monster;
    }
}
