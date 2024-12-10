using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject _patoPrefab;
    private GameObject _wave1;
    private GameObject _wave2;
    private GameObject _wave3;
    private bool onEnterState = true;
    public float remainingTime;
    private int randomDirection;
    private int randomSpawn;
    public TMP_Text guiScore;
    public TMP_Text guiFinalScore;
    public TMP_Text guiTime;
    private int gameScore;
    public GameObject uiHUD;
    public GameObject uiEndMenu;

    public enum GameStates
    {
        Start,
        Playing,
        End,
        Pause,
    }

    public GameStates state;

    private void Awake()
    {
        // Comprobar si ya existe una instancia de esta clase
        if (Instance == null)
        {
            // Si no existe, asignar esta instancia y mantenerla entre escenas
            Instance = this;
        }
        else
        {
            // Si ya existe otra instancia, destruir este objeto para asegurar que solo hay uno
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Start in playing state to test spawn enemies
        state = GameStates.Playing;
        uiHUD.SetActive(true);
        uiEndMenu.SetActive(false);
        gameScore = 0;
        _wave1 = GameObject.FindWithTag("Wave1");
        _wave2 = GameObject.FindWithTag("Wave2");
        _wave3 = GameObject.FindWithTag("Wave3");
        AudioManager.instance.StopMusic("Start");
        AudioManager.instance.PlayMusic("Stage1");
        AudioManager.instance.PlayFx("Ready");
        InvokeRepeating("PlayFxSecond", 1.3f,0f);
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
        float spawnTime = Random.Range(1, 3); 
        while (remainingTime > 0f)
        {
            // Decrease remainingTime
            remainingTime -= Time.deltaTime;
            currentTime += Time.deltaTime;
            guiTime.text = "Time: " + remainingTime.ToString("F1");
            if (currentTime >= spawnTime)
            {
                int numPatos = Random.Range(1, 4);
                SpawnPato(numPatos);
                spawnTime = currentTime + Random.Range(3, 5);
            }
            
            // Suspend corrutine until next frame
            yield return null;
        }
        uiHUD.SetActive(false);
        uiEndMenu.SetActive(true);
        guiFinalScore.text = gameScore.ToString();
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
    public void UpdateScore(int points)
    {
        gameScore += points;
        guiScore.text = "Score: " + gameScore.ToString();
    }
    public void LoadMainMenu(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void PlayFxSecond()
    {
        AudioManager.instance.PlayFx("Go");
    }
}
