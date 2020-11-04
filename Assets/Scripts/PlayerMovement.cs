using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject rightFrontWheel;
    [SerializeField] private GameObject leftFrontWheel;
    [SerializeField] private GameObject rightRearWheel;
    [SerializeField] private GameObject leftRearWheel;
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform camSpawn;
    private float time = 0;
    private bool running;
    public bool Running{set{running = value;}}

    protected void Start(){
        GameManager.instace.SetPlayerSpawnPos(gameObject);
        cam.transform.position = camSpawn.transform.position;
        cam.transform.parent = camSpawn.transform;
    }
 
    protected void Update(){
        time += Time.deltaTime;
        speed = speedCurve.Evaluate(time);
    }

    protected void FixedUpdate(){
        if(running){
           MoveCar();
           RotateWheels();
        }
    }

    private void MoveCar(){
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void RotateWheels(){
        rightFrontWheel.transform.Rotate(Time.deltaTime * -(speed * 100), 0, 0);
        leftFrontWheel.transform.Rotate(Time.deltaTime * -(speed * 100), 0, 0);
        rightRearWheel.transform.Rotate(Time.deltaTime * -(speed * 100), 0, 0);
        leftRearWheel.transform.Rotate(Time.deltaTime * -(speed * 100), 0, 0);
    }
}
