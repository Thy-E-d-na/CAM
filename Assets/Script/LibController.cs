using UnityEngine;
using UnityEngine.UI;

public class LibController : MonoBehaviour
{
    public GameObject libPnl;
    public Button libBtn;
    public Button X;
    public GameObject ComicEndPnl;


        void Start()
    {
        libPnl.SetActive(false);
    }

    public void openLib()
    {
        SoundEffectManager.Play("btn");
        libPnl.SetActive(!libPnl.activeSelf);
    }
    public void closeLib()
    {
        SoundEffectManager.Play("btn");
        libPnl.SetActive(false);
    }
    public void ChooseEndingA()
    {
        if (PlayerPrefs.GetInt("ending1")==1)
        {
            ComicEndPnl.SetActive(true);
        }
         else
        {
            SoundEffectManager.Play("error");
        }
    }
    public void ChooseEndingB()
    {
       if (PlayerPrefs.GetInt("ending2")==1)
        {
            ComicEndPnl.SetActive(true);
        }
         else
        {
            SoundEffectManager.Play("error");
        }
    }
}


