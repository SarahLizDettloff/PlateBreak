using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AccelerationControl : MonoBehaviour
{
    public GameObject plate;
    Vector3 accelerationDir;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        accelerationDir = Input.acceleration;

        if (accelerationDir.sqrMagnitude >= 5f)
        {
            plate.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            float movespeed = 0.1f;
            movespeed++;
            transform.position = new Vector3(transform.position.z + movespeed, transform.position.y);
        }

    }


    public void ResetScene()
    {
        SceneManager.LoadScene("RageScene");

    }


}
