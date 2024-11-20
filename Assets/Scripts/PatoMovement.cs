using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoMovement : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;
    [SerializeField] private float _rangeX;
    [SerializeField] private float _rangeY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= _rangeY)
        {
            transform.position += new Vector3(0, Time.deltaTime, 0);
        }
    }
}
