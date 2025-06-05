using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public GameObject shopPnl;
    public Button xBtn;
    public Button muaBtn;
    public GameController GC;
    public Spawner spawner;
    public CharacterMove _char;
    void Start()
    {
        GC = GC.GetComponent<GameController>();
        _char = FindAnyObjectByType<CharacterMove>();
    }
    public void shopOpen()
    {
        shopPnl.SetActive(!shopPnl.activeSelf);
        SoundEffectManager.Play("btn");
        Time.timeScale = 0;
    }
    public void XShop()
    {
        shopPnl.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (!shopPnl.activeSelf)
        {
           Time.timeScale = 1; 
        }
    }
    public void mua()
    {
        GC.muaItem();
        _char.boost = true;
        
    }

}
