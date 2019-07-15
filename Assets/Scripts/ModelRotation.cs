using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    public float speed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //BoxCollider collider = GetComponent<BoxCollider>();
                //transform.RotateAround(centar.transform.position, Vector3.up * speed * Time.deltaTime, 1f);
                transform.parent.Rotate(Vector3.up * speed * Time.deltaTime, 1f);
                //transform.RotateAroundLocal(Vector3.up, 10f);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.parent.Rotate(Vector3.up * speed * Time.deltaTime * -1, 1f);
                //transform.RotateAround(centar.transform.position, Vector3.up * speed * Time.deltaTime * -1, 1f);
            }
        }
       
    }
}
