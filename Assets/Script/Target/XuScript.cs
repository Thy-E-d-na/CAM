
using System;
using UnityEngine;
public class XuScript : MonoBehaviour, IItem
{
   public static event Action<XuScript> OnXuDrop;
   [SerializeField] float bouncy;

    public void Collected()
    { 
        Destroy(gameObject);
        
    }
    void OnMouseDown()
    {
        OnXuDrop?.Invoke(this);
        Collected();
        SoundEffectManager.Play("pickXu");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Rigidbody2D rg = GetComponent<Rigidbody2D>();
            if(rg != null)
            {
                rg.linearVelocity = Vector2.zero;
                rg.bodyType = RigidbodyType2D.Static;
            }
        }
       
    }

}

internal interface IItem
{
    public void Collected();
}