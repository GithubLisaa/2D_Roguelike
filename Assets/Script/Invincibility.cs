using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class invicibilityframes : MonoBehaviour
{

    public float speed = 1f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float y = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        float z = gameObject.transform.position.z;

        gameObject.transform.Translate(x, y, z);
    }
    /*void OndiscCollision()
    {
        if (Collision.gameObject.tag == "disc")
        {
            Destroy(Collision.gameObject);
        }
    }*/
}