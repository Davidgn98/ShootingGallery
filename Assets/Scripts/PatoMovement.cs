using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatoMovement : MonoBehaviour
{
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;
    [SerializeField] private float _rangeX;
    [SerializeField] private float _rangeY;
    private Vector3 _posIni;
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        _posIni = transform.position;
        scale = transform.localScale;
    }

    // Update is called once per frame
    
    public enum State
    {
        appear,
        walk,
        disapear
    }
    public State state = State.appear;
    void Update()
    {
        if (transform.position.y <= _rangeY + _posIni.y && state == State.appear)
        {
            transform.position += new Vector3(0, _speedY * Time.deltaTime, 0) ;

        }
        else if (state == State.appear)
        { 
            state = State.walk;
        }
        if(scale.x == 0.1f)
        {
            if (transform.position.x <= _rangeX + _posIni.x && state == State.walk)
            {
                transform.position += new Vector3(_speedX * Time.deltaTime, 0, 0);
            }
            else if (state == State.walk)
            {
                state = State.disapear;
            }
        }
        else if (scale.x == -0.1f)
        {
            if (transform.position.x >= _posIni.x - _rangeX && state == State.walk)
            {
                transform.position -= new Vector3(_speedX * Time.deltaTime, 0, 0);
            }
            else if (state == State.walk)
            {
                state = State.disapear;
            }
        }
        if (transform.position.y >= _posIni.y - _rangeY && state == State.disapear)
        {
            transform.position -= new Vector3(0, _speedY * Time.deltaTime, 0);
        }
        else if (state == State.disapear)
        {
            state = State.appear;
            Destroy(gameObject);
        }
    }
}
