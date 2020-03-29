using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer playerSprite;

    [SerializeField]
    private float graceTimeDuration = 2f;
    private float graceTimer = 0f;

    private bool isHit = false;
    private int lives = 3;

    private void Update()
    {
        if(graceTimer >= graceTimeDuration && isHit)
        {
            playerSprite.enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;

            Invoke("Hit", graceTimeDuration);
            isHit = false;
        }
        graceTimer += Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isHit = true;
        }
    }

    public void Hit()
    {
        lives -= 1;
        if(lives < 1)
        {
            Die();
        }

        playerSprite.enabled = true;

        //gameObject.GetComponent<PlayerMovement>().ResetPlayerPosition();

        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    public void Die()
    {

    }
}
