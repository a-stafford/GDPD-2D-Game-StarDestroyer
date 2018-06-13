using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour
{

    public float maxSpeed = 5f;
    Camera cam;
    Transform my;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);


        transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0));


    }
}
