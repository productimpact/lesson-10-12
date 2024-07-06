using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private Transform leftPosition;
    [SerializeField] private Transform rightPosition;
    [SerializeField] private GameObject bullet;

    [SerializeField] private int lives = 3;
    public void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + .2f, transform.position.y);
    }
    public void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - .2f, transform.position.y);
    }

    public void ShootRight()
    {
        Instantiate(bullet, rightPosition);
    }

    public void ShootLeft()
    {
        Instantiate(bullet, leftPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            lives--;
            Destroy(collision.gameObject);
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void SaveProgress()
    {
        Text scoreCount = GameObject.Find("ScoreCount").GetComponent<Text>();
        int score = int.Parse(scoreCount.text);

        if (PlayerPrefs.GetInt("MaxScore", 0) < score)
        {
            PlayerPrefs.SetInt("MaxScore", score);
        }
    }

    private void OnDestroy()
    {
        SaveProgress();
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
