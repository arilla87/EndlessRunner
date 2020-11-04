using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    private float coolDown;
    private float minCoolDown;
    private float maxCoolDown;
    private float timer = 0;
    public bool startSpawn = false;
    private int id;
    private float speed;
    private float maxSpeed;
    private float minSpeed;
    private SpawnGenerator spawnGenerator;

    public void SetUpLane(float _minSpeed, float _maxSpeed, float _minCoolDown, float _maxCoolDown, int _id, SpawnGenerator _spawnGenerator)
    {
        minSpeed = _minSpeed;
        maxSpeed = _maxSpeed;

        minCoolDown = _minCoolDown;
        maxCoolDown = _maxCoolDown;

        id = _id;
        spawnGenerator = _spawnGenerator;
        RandomizeSpeedAndCoolDown();
    }

    public virtual void StartSpawing(bool b)
    {
        startSpawn = b;
    }

    private void Update()
    {
        if(startSpawn)
        {
            timer += Time.deltaTime;
            if(coolDown != 0 && timer > coolDown){
                SpawnCar();
                RandomizeSpeedAndCoolDown();
                timer = 0;
            }
        }
    }

    public virtual void SpawnCar()
    {
        spawnGenerator.SpawnCar(id, speed);
    }
    public virtual void RandomizeSpeedAndCoolDown()
    {
        coolDown = Random.Range(minCoolDown, maxCoolDown);
        speed = Random.Range(minSpeed, maxSpeed);
    }
}
