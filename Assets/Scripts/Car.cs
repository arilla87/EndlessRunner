using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float speed;
    public float Speed{get{return speed;}set{speed = value;}}

    protected void Update(){
        transform.position += Vector3.back * (speed * Time.deltaTime);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4))
        {
            if(hit.collider.CompareTag("Car"))
            {
                speed = hit.collider.gameObject.GetComponent<Car>().Speed;
            }
        }
    }
}
