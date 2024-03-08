using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBehavior : MonoBehaviour
{
    [SerializeField] public Transform RespawnPoint;
    public float pitdamage = 1;
    // Start is called before the first frame update
 
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            Health health = collider2D.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(pitdamage);
                collider2D.gameObject.transform.position = RespawnPoint.position;
            }
            
        }
    }
}
