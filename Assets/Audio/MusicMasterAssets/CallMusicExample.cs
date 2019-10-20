using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MusicMaster;
using UnityEngine.SceneManagement;

public class CallMusicExample : MonoBehaviour
{
    private Monster monster;

	public float Progress;
	bool playedSong = false;

    public int songNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        monster = FindMonster();

        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    //void OnEnable()
    //{
    //    SceneManager.sceneLoaded += ResetForLoad;
    //}

    //void OnDisable()
    //{
    //    SceneManager.sceneLoaded -= ResetForLoad;
    //}

    //void ResetForLoad(Scene scene, LoadSceneMode mode)
    //{
    //    sceneIndex = GetSongNumber(scene.buildIndex);
    //    playedSong = false;
    //}

    // Update is called once per frame
    void Update()
    {
        if (monster == null) monster = FindMonster();
        else
        {
            if (playedSong == false)
            {
                playedSong = true;
                MusicController.PlaySong(songNumber);
            }
            MusicController.SetProgress(monster.PercentageFull); // 0 = starting, .5 = halfway there, 1 = finished!

            Progress = monster.PercentageFull;
        }
    }

    //public int GetSongNumber(int buildindex)
    //{
    //    switch (buildindex)
    //    {
    //        case 0:
    //            return 0;
    //        case 1:
    //            return 0;
    //        case 2:
    //            return 1;
    //        case 3:
    //            return 1;
    //        case 4:
    //            return 2;
    //    }

    //    return 0;
    //}

    public Monster FindMonster()
    {
        var monster = FindObjectOfType<Monster>();
        if (monster == null) Debug.LogWarning("Could not find monster!");
        return monster;
    }
}
