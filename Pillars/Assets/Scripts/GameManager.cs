using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPlaying;
    private float spawnDistance = 20;
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject player;
    void Start()
    {
        isPlaying = false;
        InvokeRepeating("SpawnEnemy", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemy()
    {
        if (isPlaying)
        {
            int i = Random.Range(0, enemies.Length);

            float spawnAngle = Random.Range(0, 360);
            Vector3 spawnPosition = new Vector3(spawnDistance * Mathf.Cos(spawnAngle), spawnDistance * Mathf.Sin(spawnAngle), 0);

            Instantiate(enemies[i], spawnPosition, Quaternion.Euler(0, 0, 0));
        }
    }

    public void StartGame()
    {
        player.gameObject.SetActive(true);
        isPlaying = true;
        startButton.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        isPlaying = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
