using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int targetCount = 0;
    private int targetLimit = 15;

    private GameArea Edge;
    private Vector3 spawnPos;

    [SerializeField] GameObject targetLv1;
    private PlayerScript playerLv;
    [SerializeField] private List<Target> targets;


    void Start()
    {
        Edge = transform.GetComponent<GameArea>();
        playerLv = FindAnyObjectByType<PlayerScript>();
        int load = PlayerPrefs.GetInt("loadspawn");
        PlayerPrefs.DeleteKey("loadspawn");
        spawn_onExit(load);
        StartCoroutine(Spawn());
    }

    void OnEnable()
    {
        TargetBehaviour.OndeadTarget += targetDead;
    }
    void OnDisable()
    {
        TargetBehaviour.OndeadTarget -= targetDead;
    }
    IEnumerator Spawn()
    {

        while (true)
        {
            if (targetCount < targetLimit)
            {
                spawnPos = Edge.LimitArea();
                if (playerLv._currentLv > 3)
                {
                    Target selected = GetTargetByRate();
                    Instantiate(selected.pref, spawnPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(targetLv1, spawnPos, Quaternion.identity);
                }
                targetCount++;

            }
            
            yield return new WaitForSeconds(Random.Range(5f, 10f));
        }
    }
    private Target GetTargetByRate()
    {
        int total = targets.Sum(t => t.spawnRate);
        int roll = Random.Range(0, total);
        foreach (var t in targets)
        {
            if (roll < t.spawnRate)
                return t;
            roll -= t.spawnRate;
        }
        return null;
    }

    void targetDead()
    {
        targetCount--;
    }

    public void activateBoost()
    {
        MusicManager.pauseMusic();
        SoundEffectManager.Play("boost");
        InvokeRepeating("Boosting", 0f,0.1f);
        Invoke("EndBoost", 15f);
    }
    void EndBoost()
    {
        CancelInvoke("Boosting");
        StartCoroutine(Spawn());
        CharacterMove _char = FindAnyObjectByType<CharacterMove>();
        MusicManager.playMusic(false);
        _char.boost = false;
    }
    private void Boosting()
    {
        if (targetCount < targetLimit)
        {
            spawnPos = Edge.LimitArea();
            if (playerLv._currentLv > 3)
            {
                Target selected = GetTargetByRate();
                Instantiate(selected.pref, spawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(targetLv1, spawnPos, Quaternion.identity);
            }
            targetCount++;

        }
    }
    public void spawn_onExit(int amount)
    {
        for (int i = 0; i < amount && targetCount < targetLimit; i++)
        {
            Vector3 pos = Edge.LimitArea();
            if (playerLv._currentLv > 3)
            {
                Target selected = GetTargetByRate();
                Instantiate(selected.pref, pos, Quaternion.identity);
            }
            else
            {
                Instantiate(targetLv1, pos, Quaternion.identity);
            }
            targetCount++;
        }
    }
}
