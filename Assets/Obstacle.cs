using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Player player;
    public int damage = 1;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D  other)
    {
        if (other.CompareTag("Player"))
        {
            // player terkena damage
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }

        if (other.CompareTag("PlayerSlide"))
        {
            // player terkena damage
            other.GetComponentInParent<Player>().health -= damage;
            Debug.Log(other.GetComponentInParent<Player>().health);
            Destroy(gameObject);
        }
    }
}
