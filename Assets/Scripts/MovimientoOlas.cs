using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    private float _posIni;
    public enum DirIni
    {
        left,
        right
    }
    public DirIni dirIni = DirIni.right;
    // Start is called before the first frame update
    void Start()
    {
        _posIni = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (dirIni == DirIni.right && transform.position.x < _posIni + _range)
        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            dirIni = DirIni.left;
        }

        if (dirIni == DirIni.left && transform.position.x > _posIni - _range)
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);
        }
        else
        {
            dirIni = DirIni.right;
        }
    }
}
