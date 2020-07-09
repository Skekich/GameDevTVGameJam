using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private TextMeshProUGUI gameOver;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObjectRuntimeSet scoreRunTime;
    
    private Camera currentActiveCamera;

    private Vector2 currentScreenSize;
    private int posX;
    private int posY;
    private int screenOffset = 1;
   
    private InstantiateList bombsList;
    private List<GameObject> currentBombsList;
    
    private float bombSize;

    private float timer = .7f;
    private ScoreUIScript scoreScript;
    private int test;
    
    private void OnEnable()
    {
        EventHandler.OnInvokeDeath -= RemoveFromCurrentList;
        EventHandler.OnInvokeDeath += RemoveFromCurrentList;
        EventHandler.OnTimeZero -= TimeOut;
        EventHandler.OnTimeZero += TimeOut;

    }

    private void Start()
    {
        bombsList = new InstantiateList();
        currentBombsList = bombsList.CreateList(6);
        currentBombsList.Clear();
        currentActiveCamera = Camera.main;
        bombSize = bomb.GetComponent<CircleCollider2D>().radius;
        GetScreenSize();
        scoreScript = scoreRunTime.GetItemIndex(0).GetComponent<ScoreUIScript>();
    }

    private void Update()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        if (bombsList.CheckIfFull()) return;
        for (var i = 0; i < bombsList.FreePlaces(); i++)
        {
            timer -= Time.deltaTime;
            if (!(timer <= 0)) continue;
            GenerateRandomSpawnPosition();
            timer = UnityEngine.Random.Range(.7f, 1.5f);
        }
    }

    private void RemoveFromCurrentList()
    {
        bombsList.RemoveFromList();
    }
    
    private void GetScreenSize()
    {
        if (currentActiveCamera != null)
        {
            currentScreenSize = currentActiveCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        posX = Mathf.RoundToInt(currentScreenSize.x);
        posY = Mathf.RoundToInt(currentScreenSize.y);
    }

    private void GenerateRandomSpawnPosition()
    {
        var randomX = UnityEngine.Random.Range(-posX + screenOffset, posX);
        var randomY = UnityEngine.Random.Range(-posY + screenOffset, posY);
        var spawnPosition = new Vector2(randomX, randomY);
        CheckForOverlap(spawnPosition);
    }
    
    private void CheckForOverlap(Vector2 position)
    {
        var bombOverlap = Physics2D.OverlapCircle(position, bombSize);
        if (bombOverlap)
        {
            GenerateRandomSpawnPosition();
            return;
        }

        SpawnBomb(position);
    }

    private void SpawnBomb(Vector2 spawnPosition)
    {
        var currentBomb = Instantiate(bomb, spawnPosition, Quaternion.identity);
        bombsList.AddToList(currentBomb);
    }

    private void TimeOut()
    {
        StartCoroutine(TimeOutEnum());
    }
    
    private IEnumerator TimeOutEnum()
    {
        gameOver.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
        score.text = $"Score {scoreScript.CurrentScore.ToString()}";
        yield return new WaitForSeconds(.3f);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        currentBombsList.Clear();
        EventHandler.OnInvokeDeath -= RemoveFromCurrentList;
        EventHandler.OnTimeZero -= TimeOut;
    }
}