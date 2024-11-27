using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    public Material material;
    public float offsetX;
    public float offsetY;
    public Vector2 offset;
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
        if (dirIni == DirIni.left)
        {
            offset.x += _speed * Time.deltaTime;
        }
        if (dirIni == DirIni.right)
        {
            offset.x -= _speed * Time.deltaTime;
        }

        if (offset.x > 1f)
        {
            offset.x -= 1f;
        }
        if (offset.x < -1f)
        {
            offset.x += 1f;
        }
        material.mainTextureOffset = offset;

        /*if (dirIni == DirIni.right && transform.position.x < _posIni + _range)
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
        }*/
    }
}
