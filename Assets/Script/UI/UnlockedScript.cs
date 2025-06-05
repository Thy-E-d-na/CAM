using UnityEngine;
using UnityEngine.UI;

public class UnlockedScript : MonoBehaviour
{
    public FormData[] assets;
    public Image[] image;
    private int playerLv;
    void Start()
    {
        playerLv = PlayerPrefs.GetInt("playerLv", 0);
        for (int i = 0; i < assets.Length; i++)
        {
            image[i].sprite = (playerLv >= assets[i].lvR)
            ? assets[i].unlocked : assets[i].locked;
        }

    }
    void Update()
    {
        playerLv = PlayerPrefs.GetInt("playerLv", 0);
        updateLib();

    }
    void updateLib()
    {
        for (int i = 0; i < assets.Length; i++)
        {
            image[i].sprite = (playerLv >= assets[i].lvR)
            ? assets[i].unlocked : assets[i].locked;
        }
    }

    // public void unlockedBtn()
    // {
    //     for(int i = 0;i < )
    // }

}
