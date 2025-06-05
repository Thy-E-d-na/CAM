using UnityEngine;
using TMPro;
using UnityEngine.UI;


using System;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public Image loadingImg;
    public int spawnAmount;
    public Spawner spawner;
    public PlayerScript player;

    [Header("Xu Picking")]
    public TMP_Text _countText;
    private int coinBag = 222;
    public GameObject shopPnl;

    void Start()
    {
        int check = PlayerPrefs.GetInt("Intro", 0);
        if (check == 0)
        {
            PlayerPrefs.SetInt("Intro", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Intro");
            return;
        }

        
    }
    void OnAppOpen()
    {
        loadingImg.gameObject.SetActive(true);
        targetLoad();
        spawner.spawn_onExit(spawnAmount);
        loadingImg.gameObject.SetActive(false);
    }
    void targetLoad()
    {
        float lastTime = PlayerPrefs.HasKey("LastTime")
        ? float.Parse(PlayerPrefs.GetString("LastTime")) : Time.time;
        float t = Time.time - lastTime;
        spawnAmount = (int)Math.Round((double)t / 5);
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastTime", Time.time.ToString());
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
    public void pauseGame()
    {
        Time.timeScale = 0;
    }
    public void resume()
    {
        Time.timeScale = 1;
    }

}
