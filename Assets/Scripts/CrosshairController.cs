using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairController : MonoBehaviour
{

    public float bulletSpeed;
    public GameObject bullet;

    private void OnEnable()
    {
        //Hide mouse coursor
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
        // Set the position of the crosshair equal to the mouse position
        transform.position = Input.mousePosition;

        // Get right click on mouse
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.instance.PlayFx("Shoot");
            // Raycasting fron camera through the crosshair
            Ray ray = Camera.main.ScreenPointToRay(transform.position);
            RaycastHit castHit;

            if (Physics.Raycast(ray, out castHit, 50))
            {

                // Calculate de dir of the bullet
                Vector3 bulletDir = (castHit.point - Camera.main.transform.position);

                // Set the origin - start position -  of the bullet
                Vector3 bulletOrigin = Camera.main.transform.position;

                // Normalizamos el vector dirección para que su módulo valga 1 y así hacer independiente la velocidad
                // de avance con lo largo del vector dirección.
                // Lo multiplicamos por 10 para que avance a esa velocidad.
                Instantiate(bullet, bulletOrigin, Quaternion.identity).GetComponent<BulletController>().SetSpeed(bulletDir.normalized * bulletSpeed);

                //Debug.DrawRay(Camera.main.transform.position, bulletDir, Color.red, 10.0f);

            }
        }
    }

    public void OnDisable()
    {
        // Show mouse cursor
        Cursor.visible = true;
    }

}