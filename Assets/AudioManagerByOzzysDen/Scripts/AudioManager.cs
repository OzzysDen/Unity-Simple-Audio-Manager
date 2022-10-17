using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
#region Singleton
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            if (DontDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        SetObjects();
        CreatePool(true);
    }
    #endregion

    private AudioScriptableObject AudioListObject;
    private List<Audio> AudioList;
    public int PoolSize=5;
    public bool DontDestroy;
    private GameObject AudioPlayer;

    
    private void SetObjects()
    {
        AudioPlayer = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/AudioManagerByOzzysDen/Prefabs/AudioPlayer.prefab", typeof(Object));
        AudioListObject = (AudioScriptableObject)AssetDatabase.LoadAssetAtPath("Assets/AudioManagerByOzzysDen/Audio Data/AudioFiles.asset", typeof(ScriptableObject));
        AudioList = AudioListObject.Audios;
    }


    private void CreatePool(bool isInitial=false)
    {
        if (isInitial)
        {
            for (int i = 0; i < PoolSize; i++)
            {
                Instantiate(AudioPlayer, transform);
            }
        }
        else
        {
            Instantiate(AudioPlayer, transform);
        }
    }


    //helper
    private AudioSource UseFromPool()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (!transform.GetChild(i).GetComponent<AudioSource>().isPlaying)
            {
                return transform.GetChild(i).GetComponent<AudioSource>();
            }
        }
            CreatePool();
            return transform.GetChild(transform.childCount - 1).GetComponent<AudioSource>();
    }


    #region Play Audio
    private Audio GetAudio(string audioName)
    {
        if (PoolSize==0)
        {
            CreatePool();
        }
        for (int i = 0; i < AudioList.Count; i++)
        {
            if (audioName==AudioList[i].name)
            {
                return AudioList[i];
            }
        }
        return null;
    }

    public void PlayAudio(string audioName, int volume = 1, int pitch = 1, bool loop = false)
    {
        AudioSource audioSource = UseFromPool();

        audioSource.clip = GetAudio(audioName).audioClip;
        audioSource.volume = GetAudio(audioName).volume;
        audioSource.pitch = GetAudio(audioName).pitch;
        audioSource.loop = GetAudio(audioName).isLoop;

        audioSource.Play();
    }
    #endregion


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayAudio("Correct");
        if (Input.GetKeyDown(KeyCode.Alpha2))
            PlayAudio("Jump");
        if (Input.GetKeyDown(KeyCode.Alpha3))
            PlayAudio("Win");
        if (Input.GetKeyDown(KeyCode.Alpha4))
            PlayAudio("Zonk");

    }



}


