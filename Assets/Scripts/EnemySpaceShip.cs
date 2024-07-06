using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpaceShip : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private int lives = 2;

    private void Start()
    {
        StartCoroutine(StartShooting());
    }

    public void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + .2f, transform.position.y);
    }
    public void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - .2f, transform.position.y);
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            lives--;
            Destroy(collision.gameObject);
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator StartShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Shoot();
        }
    }

    private void OnDestroy()
    {
        Text scoreCount = GameObject.Find("ScoreCount").GetComponent<Text>();
        scoreCount.text = (int.Parse(scoreCount.text) + 1).ToString();
    }
}
