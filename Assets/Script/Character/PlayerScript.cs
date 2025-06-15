using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public static PlayerScript Instance;

    [Header("Level Up")]
    public int _currentLv;
    public int _currentXP;
    public int _maxXP => (int)(40 + 30 * Math.Pow(_currentLv, 2));

    //GUI
    [SerializeField] Slider xpBar;
    [SerializeField] TMP_Text _xpText;
    [SerializeField] TMP_Text lvText;


    public GameObject Endpnl;
    [SerializeField] AudioClip storytell;

    [Header("Evolution")]

    public GameObject pnl;
    public Image formImage;
    public Sprite[] popUp;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorOverrideController[] animByLv;

    [Header("Ending")]

    public GameObject ComicEndPnl;
    void Awake()
    {
        if(Instance == null)
        Instance = this;
    }
    void Start()
    {
        _currentLv = PlayerPrefs.GetInt("playerLv");
        _currentXP = PlayerPrefs.GetInt("xp");
        animator.runtimeAnimatorController = animByLv[_currentLv - 1];

        updateXpUI();
        if (XPManager.instance != null)
        {
            XPManager.instance.ONXPChange += HandleXPChange;
        }
        else
        {
            Debug.Log("screw up");
        }

    }

    void OnEnable()
    {
        XPManager.instance.ONXPChange += HandleXPChange;
    }
    void OnDisable()
    {
        XPManager.instance.ONXPChange -= HandleXPChange;
    }

    private void HandleXPChange(int newXP)
    {
        _currentXP += newXP;

        if (_currentXP >= _maxXP)
        {
            _currentXP -= _maxXP;
            LvUp();
        }
        updateXpUI();
    }
    void updateXpUI()
    {

        PlayerPrefs.SetInt("xp", _currentXP);
        if (_currentLv >= 8)
        {
            _xpText.gameObject.SetActive(false);
        }
        else
        {
            _xpText.gameObject.SetActive(true);
            xpBar.maxValue = _maxXP;
            xpBar.value = _currentXP;
            _xpText.text = _currentXP + "/" + _maxXP;
            lvText.text = "Lv." + _currentLv;
        }
    }
    private void LvUp()
    {
        _currentLv++;
        PlayerPrefs.SetInt("playerLv", _currentLv);
        PlayerPrefs.Save();
        if (_currentLv < 8)
        {
            ShowPopUp();
            MusicManager.pauseMusic();
            SoundEffectManager.Play("lvup");
            animator.runtimeAnimatorController = animByLv[_currentLv - 1];
        }
        else if (_currentLv == 8)
        {
            MusicManager.pauseMusic();
            Endpnl.SetActive(true);
            MusicManager.playMusic(true, storytell);
        }

    }

    void ShowPopUp()
    {
        Time.timeScale = 0;
        int lv = _currentLv - 2;
        if (lv >= 0 && lv < popUp.Length)
        {
            pnl.SetActive(true);
            formImage.sprite = popUp[lv];
        }
    }
    public void OkClicked()
    {
        SoundEffectManager.Play("btn");
        Time.timeScale = 1;
        pnl.SetActive(false);
        MusicManager.playMusic(false);
    }
    public void ChooseEndingA()
    {
        SoundEffectManager.Play("btn2");
        PlayerPrefs.SetInt("ends", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("A");
        //ComicEndPnl.SetActive(true);
        Endpnl.SetActive(false);
    }
    public void ChooseEndingB()
    {
        SoundEffectManager.Play("btn2");
        PlayerPrefs.SetInt("ends", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene("B");
        //ComicEndPnl.SetActive(true);
        Endpnl.SetActive(false);
    }

}
