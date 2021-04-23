using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float ms = 6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
           if (Input.GetKey(KeyCode.UpArrow)){

               transform.Translate(Vector3.up * ms * Time.deltaTime);

           }

           if (Input.GetKey(KeyCode.DownArrow)){

               transform.Translate(Vector3.down * ms * Time.deltaTime);

           }

    }
}
