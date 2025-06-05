using UnityEngine;

public class OptMenu : MonoBehaviour
{
   

[SerializeField] private GameObject optPnl;
   
    public void openPnl()
    {
        SoundEffectManager.Play("btn");
        optPnl.SetActive(!optPnl.activeSelf);
    }
    
}
