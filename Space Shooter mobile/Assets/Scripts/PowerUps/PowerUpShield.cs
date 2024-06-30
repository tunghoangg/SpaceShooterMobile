using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerShieldActivate shieldActivate = collision.GetComponent<PlayerShieldActivate>();
            shieldActivate.ActivateShield();
            Destroy(gameObject);
        }
    }
}
