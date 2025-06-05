using UnityEngine;
using UnityEngine.UI;

public class LibController : MonoBehaviour
{
    public GameObject libPnl;
    public Button libBtn;
    public Button X;

    [Header("Details Page")]
    public LevelInfo[] details;
    public GameObject infoPnl;
    public Image idleChar;
    public Image textImg;
    public void ShowInfo(int lvIndex)
    {
        if (lvIndex >= 0 && lvIndex < details.Length)
        {
            idleChar.sprite = details[lvIndex].idle;
            //textImg.sprite = details[lvIndex].descript;
            infoPnl.SetActive(true);
        }
    }
    public void back()
    {
        infoPnl.SetActive(false);
    }
    void Start()
    {
        libPnl.SetActive(false);
    }
    void Update()
    {

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

}

[System.Serializable]
public class LevelInfo
{
    public Sprite idle;
    public Image descript;
}
