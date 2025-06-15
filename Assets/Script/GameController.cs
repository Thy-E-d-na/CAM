using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Image loadingImg;
    public int spawnAmount;
    public Spawner spawner;
    public PlayerScript player;

    [Header("Xu Picking")]
    public TMP_Text _countText;
    private int coinBag = 444;
    public GameObject shopPnl;

    // void Start()
    // {
    //     int check = PlayerPrefs.GetInt("Intro");
    //     if (check == 0)
    //     {
    //         PlayerPrefs.SetInt("Intro", 1);
    //         PlayerPrefs.Save();
    //         SceneManager.LoadScene("Intro");
    //     }
    //     else return;
        
    // }
    // void OnAppOpen()
    // {
    //     loadingImg.gameObject.SetActive(true);
    //     targetLoad();
    //     spawner.spawn_onExit(spawnAmount);
    //     loadingImg.gameObject.SetActive(false);
    // }
    // void targetLoad()
    // {
    //     float lastTime = PlayerPrefs.GetFloat("LastTime",Time.time);
    //     float t = Time.time - lastTime;
    //     spawnAmount = (int)Math.Round((double)t / 5);
    // }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("LastTime", Time.time);
        PlayerPrefs.SetInt("playerLv",player._currentLv);
        PlayerPrefs.SetInt("xp",player._currentXP);
        PlayerPrefs.Save();
    }

    void OnEnable()
    {
        XuScript.OnXuDrop += pickXu;
    }
    void OnDisable()
    {
        XuScript.OnXuDrop -= pickXu;
    }
    void pickXu(XuScript xu)
    {
        coinBag++;
        _countText.text = coinBag + " ";
    }
    public void muaItem()
    {
        int gia = 222;
        if (coinBag >= gia)
        {
            SoundEffectManager.Play("btn");
            coinBag -= gia;
            shopPnl.SetActive(false);
            spawner.activateBoost();
            Time.timeScale = 1;
        }
        else
        {
            SoundEffectManager.Play("error");
        }

        _countText.text = coinBag + " ";
    }

}
