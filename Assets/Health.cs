using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public static float maxHealth = 6;
    public static float currentHealth;
    public HealthNubs healthNubs;
    public SpriteRenderer rend;
    public Joystick controller;
    public bool IsInvulnerable = false;
    public float health;

    void Start()
    {
        currentHealth = maxHealth;
        healthNubs.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(float damage)
    {
        base.StartCoroutine(DamageFlash());
        currentHealth -= damage;
        PlayerPrefs.SetFloat("Health", currentHealth);
        healthNubs.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
  
    public void ApplyKnockBack(float knockbackX, float knockbackY)
    {
        controller.m_Rigidbody2D.AddForce(new Vector2(controller.FacingDirection * knockbackX, knockbackY));
    }
    private IEnumerator DamageFlash()
    {
        IsInvulnerable = true;
        for (int i = 0; i < 10; i++)
        {
            rend.forceRenderingOff = true;
            yield return new WaitForSecondsRealtime(0.1f);
            rend.forceRenderingOff = false;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        IsInvulnerable = false;
        yield break;
    }
   void Die()
    {
        Destroy(base.gameObject);
    }

}
