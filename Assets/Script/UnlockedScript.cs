using UnityEngine;
using UnityEngine.UI;

public class UnlockedScript : MonoBehaviour
{
    [Header ("Form")]
    public FormData[] assets;
    public Image[] image;
    PlayerScript curlv;
    private int _lv;
    [Header("Ending")]

    public Button BE;
    public Button GE;
    void Start()
    {
        curlv = GameObject.Find("CHARACTER").GetComponent<PlayerScript>();
        _lv = curlv._currentLv;
        for (int i = 0; i < assets.Length; i++)
        {
            image[i].sprite = (_lv >= assets[i].lvR)
            ? assets[i].unlocked : assets[i].locked;
        }

    }
    void Update()
    {
        _lv = curlv._currentLv;
        updateLib();

    }
    void updateLib()
    {
        for (int i = 0; i < assets.Length; i++)
        {
            image[i].sprite = (_lv >= assets[i].lvR)
            ? assets[i].unlocked : assets[i].locked;
        }
    }
    

}
