using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Vector3 speed = new Vector3(0f, 0f, 10f);
    void Start()
    {
        Destroy(gameObject,3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime;
    }

    public void SetSpeed(Vector3 speed)
    {
        this.speed = speed;
    }

    /*public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pato")
        {
            Destroy(other.gameObject);
        }
        //Destroy(gameObject);
    }*/
}
