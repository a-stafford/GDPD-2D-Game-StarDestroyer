using UnityEngine;
using System.Collections;

public class CameraMovment : MonoBehaviour
{

    public GameObject player;
    bool dead = true;

    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame

    void LateUpdate()
    {
        try
        {
            transform.position = player.transform.position + offset;
        }
        catch (MissingReferenceException)
        {
            //bool dead = true;
            if (dead)
            {
                Debug.Log("Player Dead GAME OVER");
                dead = false;
            }
        }
    }
}
