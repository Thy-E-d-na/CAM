using System.Collections;
using UnityEngine;
public class CharacterMove : MonoBehaviour
{
    Vector2 waypoint;
    float Hei;
    float Wid;
    bool isFlip;
    public Animator anim;
    [SerializeField] float speed = 0.8f;
    [SerializeField] float range = 0.2f;
    [SerializeField] float maxDistance;

    [SerializeField] GameObject blood;
    public bool boost = false;
    void Start()
    {
        Hei = Camera.main.orthographicSize;
        Wid = Camera.main.aspect * Hei;
        maxDistance = Wid * 0.8f;
        newPos();
        StartCoroutine(Wandering());

    }
    void Update()
    {
        if (player != null && player.pnl.activeSelf)
        {
            anim.SetFloat("isWalk", 0f);
        }
        Flip();
        if (toTarget && target != null)
        {
            movetoTarget();
        }
    }
    void newPos()
    {
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance * 2, maxDistance));
    }
    void Flip()
    {
        if (isFlip && waypoint.x < 0f || !isFlip && waypoint.x > 0f)
        {
            isFlip = !isFlip;
            Vector3 flip = transform.localScale;
            flip.x *= -1f;
            transform.localScale = flip;
        }
    }
    IEnumerator Wandering()
    {
        while (!toTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            anim.SetFloat("isWalk", 0.1f);
            if (Vector2.Distance(transform.position, waypoint) < range)
            {
                newPos();

            }
            yield return null;
        }

    }

    [Header("Exterminate")]
    private bool toTarget = false;
    public Transform target;
    public Target data;

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
        toTarget = true;
    }

    void movetoTarget()
    {
        var deadTarget = target.GetComponent<TargetBehaviour>();
        transform.position = Vector2.MoveTowards(transform.position, target.position, 10f * speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {

            anim.SetTrigger(deadTarget.data.tarName == "Fish" ? "atk" : "atk2");
            if (boost == true)
            {
                Instantiate(blood,transform.position, Quaternion.identity);
            }
            SoundEffectManager.instance.PlayDelayed("stab", 0.5f);
            if (deadTarget != null)
            {
                int xp = deadTarget.data.xpReward;
                deadTarget.Dead(false);
                StartCoroutine(GiveXp(xp, 2f));

            }
            target = null;
            toTarget = false;
            newPos();
            StartCoroutine(Wandering());

        }
    }
    IEnumerator GiveXp(int xp, float t)
    {
        yield return new WaitForSeconds(t);
        XPManager.instance?.AddXP(xp);

    }

    public PlayerScript player;
    public void OnMouseDown()
    {
        anim.SetTrigger("dia");
        int lv = player._currentLv;
        switch (lv)
        {
            case 1: SoundEffectManager.Play("lv1"); break;
            case 2: SoundEffectManager.Play("lv2"); break;
            case 3: SoundEffectManager.Play("lv3"); break;
            case 4: SoundEffectManager.Play("lv4"); break;
            case 5: SoundEffectManager.Play("lv5"); break;
            case 6: SoundEffectManager.Play("lv6"); break;
            default: SoundEffectManager.Play("lv7"); break;
        }

    }

}
