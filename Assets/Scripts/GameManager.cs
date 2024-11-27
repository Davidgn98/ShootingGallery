using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _patoPrefab;
    private GameObject _wave1;
    private GameObject _wave2;
    private GameObject _wave3;
    private bool onEnterState = true;
    public float remainingTime;
    private int randomDirection;
    private int randomSpawn;
    public enum GameStates
    {
        Start,
        Playing,
        End,
        Pause,
    }

    public GameStates state;

    // Start is called before the first frame update
    void Start()
    {
        // Start in playing state to test spawn enemies
        state = GameStates.Playing;
        _wave1 = GameObject.FindWithTag("Wave1");
        _wave2 = GameObject.FindWithTag("Wave2");
        _wave3 = GameObject.FindWithTag("Wave3");
    }
    void Update()
    {
        switch (state)
        {
            case GameStates.Start:
                Debug.Log("Start state");
                break;
            case GameStates.Playing:
                if(onEnterState)
                {
                    StartCoroutine("IE_StatePlaying");
                }
                break;
            case GameStates.End:
                Debug.Log("End State");
                break;
            case GameStates.Pause:
                Debug.Log("Pause state");
                break;
            default:
                Debug.LogError("ERROR - The state doesn't exist");
                break;
        }
    }
    private IEnumerator IE_StatePlaying()
    {
        // Set the onEnterState variable to false to only call once the corrutine
        float currentTime = 0f;
        onEnterState = false;
        float spawnTime = Random.Range(0.5f, 1f); 
        while (remainingTime > 0f)
        {
            // Decrease remainingTime
            remainingTime -= Time.deltaTime;
            currentTime += Time.deltaTime;
            if (currentTime >= spawnTime)
            {
                int numPatos = Random.Range(1, 4);
                SpawnPato(numPatos);
                spawnTime = currentTime + Random.Range(1f, 3f);
            }
            
            // Suspend corrutine until next frame
            yield return null;
        }
        onEnterState = true;
        state = GameStates.End;
    }

    private void SpawnPato(int numPatos)
    {
        for(int i = 0; i <= numPatos; i++)
        {
            randomSpawn = Random.Range(1, 4);
            randomDirection = Random.Range(0, 2);
            if (randomSpawn == 1)//Ola
            {
                if (randomDirection == 0)//Derecha
                {
                    GameObject currentDuck = Instantiate(_patoPrefab, _wave1.transform.position + new Vector3(-2f, 0, 0.1f), _wave1.transform.rotation);
                    currentDuck.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if (randomDirection == 1)//Izquierda
                {
                    GameObject currentDuck = Instantiate(_patoPrefab, _wave1.transform.position + new Vector3(2f, 0, 0.1f), _wave1.transform.rotation);
                    currentDuck.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
                }

            }
            if (randomSpawn == 2)
            {
                if (randomDirection == 0)
                {
                    GameObject currentDuck = Instantiate(_patoPrefab, _wave2.transform.position + new Vector3(-2.5f, 0, 0.1f), _wave2.transform.rotation);
                    currentDuck.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if (randomDirection == 1)
                {
                    GameObject currentDuck = Instantiate(_patoPrefab, _wave2.transform.position + new Vector3(2.5f, 0, 0.1f), _wave2.transform.rotation);
                    currentDuck.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
                }
            }
            if (randomSpawn == 3)
            {
                if (randomDirection == 0)
                {
                    GameObject currentDuck = Instantiate(_patoPrefab, _wave3.transform.position + new Vector3(-3f, 0, 0.1f), _wave3.transform.rotation);
                    currentDuck.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if (randomDirection == 1)
                {
                    GameObject currentDuck = Instantiate(_patoPrefab, _wave3.transform.position + new Vector3(3f, 0, 0.1f), _wave3.transform.rotation);
                    currentDuck.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
                }
            }
        }
        
    }
}
