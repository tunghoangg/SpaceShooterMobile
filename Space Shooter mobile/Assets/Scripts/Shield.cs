using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitsToDestroy = 2;
    public bool protection = false;
    private void OnEnable()
    {
        hitsToDestroy = 2;
        protection = true;
    }
    private void DamageShield()
    {
        hitsToDestroy--;
        if(hitsToDestroy <= 0)
        {
            protection = false;
            gameObject.SetActive(false);
        }
    }
    public void RepairShield()
    {
        hitsToDestroy = 2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(1000);
            DamageShield();
        }
        else
        {
            Destroy(collision.gameObject);
            DamageShield() ;    
        }
    }

}
