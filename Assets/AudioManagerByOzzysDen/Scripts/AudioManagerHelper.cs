using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerHelper
{






}


[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume=1;
    [Range(-3, 3)] public float pitch=1;
    public bool isLoop=false;

}