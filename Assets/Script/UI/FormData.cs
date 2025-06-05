using UnityEngine;

[CreateAssetMenu(fileName = "FormData", menuName = "Scriptable Objects/FormData")]
public class FormData : ScriptableObject
{
    public int lvR;
    public Sprite unlocked;
    public Sprite locked;
    public Sprite [] sprites;
}
