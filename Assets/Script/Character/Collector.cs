using UnityEngine;

public class Collector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        IItem x = collision.GetComponent<IItem>();
        if(x != null && collision.CompareTag("Player"))
        {
            x.Collected();
        }
    }
}
