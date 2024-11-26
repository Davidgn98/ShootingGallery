using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _patoPrefab;
    private GameObject _wave1;
    private GameObject _wave2;
    private GameObject _wave3;
    private int randomDirection;
    private int randomSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _wave1 = GameObject.FindWithTag("Wave1");
        _wave2 = GameObject.FindWithTag("Wave2");
        _wave3 = GameObject.FindWithTag("Wave3");
        InvokeRepeating("SpawnPato", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnPato()
    {

        randomSpawn = Random.Range(1, 4);
        randomDirection = Random.Range(0, 2);
        if (randomSpawn == 1)
        {
            if(randomDirection == 0)
            {
                Instantiate(_patoPrefab, _wave1.transform.position + new Vector3(-2f,0,0), _wave1.transform.rotation);
                _patoPrefab.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                Instantiate(_patoPrefab, _wave1.transform.position + new Vector3(2f, 0, 0), _wave1.transform.rotation);
                _patoPrefab.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            }

        }
        if (randomSpawn == 2)
        {
            if (randomDirection == 0)
            {
                Instantiate(_patoPrefab, _wave2.transform.position + new Vector3(-2f, 0, 0), _wave2.transform.rotation);
                _patoPrefab.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                Instantiate(_patoPrefab, _wave2.transform.position + new Vector3(2f, 0, 0), _wave2.transform.rotation);
                _patoPrefab.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            }
        }
        if (randomSpawn == 3)
        {
            if (randomDirection == 0)
            {
                Instantiate(_patoPrefab, _wave3.transform.position + new Vector3(-2f, 0, 0), _wave3.transform.rotation);
                _patoPrefab.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                Instantiate(_patoPrefab, _wave3.transform.position + new Vector3(2f, 0, 0), _wave3.transform.rotation);
                _patoPrefab.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            }
        }
    }
}
