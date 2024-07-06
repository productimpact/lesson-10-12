using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Text scoreText;   
    
    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("MaxScore", 0).ToString();
        playButton.onClick.AddListener(()=> SceneManager.LoadScene("Game"));
    }

 
}
