using System.Collections;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public Target data;
    public Spawner spawner;

    bool poke = false;

    [SerializeField] GameObject xuPrefab;
    public static event System.Action OndeadTarget;

    [Header("Wandering")]
    #region 
    [SerializeField] float speed = 0.01f;
    [SerializeField] float range = 0.2f;
    [SerializeField] float maxDistance;
    Vector2 waypoint;
    bool isFlip;
    float Hei, Wid;
    #endregion

    [Header("Zoom")]
    private Vector3 ogScale;
    public float zoomFactor = 1.2f;
    public float zoomSpeed = 5f;
    private bool isZoom = false;


    [SerializeField] GameObject clickPrf;

    void Start()
    {
        Hei = Camera.main.orthographicSize;
        Wid = Camera.main.aspect * Hei;
        maxDistance = Wid + 0.8f;
        newPos();
        StartCoroutine(Wandering());
        ogScale = transform.localScale;
    }

    void Update()
    {
        Flip();

    }

    void newPos()
    {
        waypoint = new Vector2(Random.Range(-maxDistance / 2f, maxDistance / 2f), Random.Range(-Hei, 1f));
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

    public void Dead(bool g = true)
    {
        Vector3 xuPos = transform.position;
        OndeadTarget?.Invoke();
        Destroy(gameObject, 0.5f);
        if (g) XPManager.instance?.AddXP(data.xpReward);

        dropXu(xuPos);

    }
    void OnMouseDown()
    {
        poke = true;

        Instantiate(clickPrf, transform.position, Quaternion.identity);
        SoundEffectManager.Play("poke");
        CharacterMove player = FindAnyObjectByType<CharacterMove>();
        if (player != null)
        {
            player.setTarget(transform);
        }
        isZoom = true;
        Zoom();

    }
    void Zoom()
    {
        transform.localScale = isZoom ? ogScale * zoomFactor : ogScale;
        //isZoom = false;
        
    }
    public void dropXu(Vector3 pos)
    {
        int xCount = data.xDrop;
        for (int i = 0; i < xCount; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
            var xu = Instantiate(xuPrefab, pos + offset, Quaternion.identity);
            SoundEffectManager.Play("xu");
            Destroy(xu, 30f);
        }

    }


    IEnumerator Wandering()
    {
        while (!poke)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) < range)
            {
                newPos();
            }
            yield return null;
        }

    }
}

