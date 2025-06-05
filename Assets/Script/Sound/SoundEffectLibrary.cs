
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private SoundGroup[] SEGroups;
    private Dictionary<string,List<AudioClip>> soundDic;
    void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        soundDic = new Dictionary<string, List<AudioClip>>();
        foreach(SoundGroup segroup in SEGroups)
        {
            soundDic[segroup.name] = segroup.audioClips;
        }
    }
    public AudioClip GetRandomClip(string name)
    {
        if(soundDic.ContainsKey(name))
        {
            List<AudioClip> audioClips = soundDic[name];
            if(audioClips.Count > 0 )
            {
                return audioClips[Random.Range(0,audioClips.Count)];
            }
        }
        return null;
    }


}
[System.Serializable]
public struct SoundGroup
{
    public string name;
    public List<AudioClip> audioClips;
}
