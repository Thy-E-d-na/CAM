using UnityEngine;

public class GameArea : MonoBehaviour
{
    
    float Hei;
    float Wid;
    void Start()
    {
        Hei = Camera.main.orthographicSize - 1f;
        Wid = Hei * Screen.width/Screen.height + 1.8f;
    }

    public Vector3 LimitArea()
    {
        float x = Random.Range(-Wid/2,Wid/2);
        float y = Random.Range(-Hei-0.5f,Hei*0.2f);
        return new Vector3(x,y,0);
    }
    
}
