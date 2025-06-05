using UnityEngine;

[CreateAssetMenu(fileName = "Target", menuName = "Scriptable Objects/Target")]
public class Target : ScriptableObject
{
     public string tarName;
    public GameObject pref;
    public int spawnRate;
    public int lvRequirement;
    public int xpReward;
    public int xDrop;
}
