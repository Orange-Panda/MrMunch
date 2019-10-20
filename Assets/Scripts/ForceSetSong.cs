using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSetSong : MonoBehaviour
{
    public int songnumber;
    private CallMusicExample _caller;

    // Start is called before the first frame update
    void Awake()
    {
        _caller = FindObjectOfType<CallMusicExample>();

        _caller.songNumber = songnumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
