using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float health;

    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private Shield shield;

    private bool canShowAnimation = true;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health/maxHealth;
        EndGameManager.endManager.gameOver = false;
    }
    public void PlayerTakeDamage(float damage)
    {
        if (shield.protection)
        {
            return;
        }
        health -= damage;
        healthFill.fillAmount = health / maxHealth;
        if (canShowAnimation)
        {
            animator.SetTrigger("GetHit");
            StartCoroutine(PreventSpamAnimation());
        }
        
        if (health <= 0)
        {
            EndGameManager.endManager.gameOver = true;
            EndGameManager.endManager.StartResolveSequence();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator PreventSpamAnimation()
    {
        canShowAnimation = false;
        yield return new WaitForSeconds(0.15f);
        canShowAnimation = true;
    }
    public void AddHealth(int healAmount)
    {
        health += healAmount;
        if(health> maxHealth)
        {
            health = maxHealth;
        }
        healthFill.fillAmount = health / maxHealth;
    }
}
