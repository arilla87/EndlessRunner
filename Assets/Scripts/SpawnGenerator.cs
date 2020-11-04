using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private Material[] carMaterials;

    [Header("Min and max speed for the cars in the slow lane")]
    [SerializeField, Range(0,100)] private float slowLaneSpeedMin;
    [SerializeField, Range(0,100)] private float slowLaneSpeedMax;

    [Header("Min and max speed for the cars in the medium lane")]
    [SerializeField, Range(0,100)] private float mediumLaneSpeedMin;
    [SerializeField, Range(0,100)] private float mediumLaneSpeedMax;

    [Header("Min and max speed for the cars in the fast lane")]
    [SerializeField, Range(0,100)] private float fastLaneSpeedMin;
    [SerializeField, Range(0,100)] private float fastLaneSpeedMax;

    [Header("Min and max cooldown for the cars in the fast slow")]
    [SerializeField, Range(0.15f, 10)] private float slowLaneCoolDownMin;
    [SerializeField, Range(0.15f, 10)] private float slowLaneCoolDownMax;

    [Header("Min and max cooldown for the cars in the fast medium")]
    [SerializeField, Range(0.15f,10)] private float mediumLaneCoolDownMin;
    [SerializeField, Range(0.15f,10)] private float mediumLaneCoolDownMax;

    [Header("Min and max cooldown for the cars in the fast fast")]
    [SerializeField, Range(0.15f,10)] private float fastLaneCoolDownMin;
    [SerializeField, Range(0.15f,10)] private float fastLaneCoolDownMax;

    private Lane slowLane;
    private Lane mediumLane;
    private Lane fastLane;

    protected void Awake(){
        slowLane = GameObject.FindGameObjectWithTag("SlowLane").GetComponent<Lane>();
        mediumLane = GameObject.FindGameObjectWithTag("MediumLane").GetComponent<Lane>();
        fastLane = GameObject.FindGameObjectWithTag("FastLane").GetComponent<Lane>();


        slowLane.SetUpLane(slowLaneSpeedMin, slowLaneSpeedMax, slowLaneCoolDownMin, slowLaneCoolDownMax, 0, this);
        mediumLane.SetUpLane(mediumLaneSpeedMin, mediumLaneSpeedMax, mediumLaneCoolDownMin, mediumLaneCoolDownMax, 1, this);
        fastLane.SetUpLane(fastLaneSpeedMin, fastLaneSpeedMax, fastLaneCoolDownMin, fastLaneCoolDownMax, 2, this);
    }

    public void CarSpawn(bool b){
        slowLane.StartSpawing(b);
        mediumLane.StartSpawing(b);
        fastLane.StartSpawing(b);
    }

    public void SpawnCar(int id, float speed){
        GameObject carGo = CarPool.instace.GetCar();
        CarsCollection.instance.AddCarToList(carGo);
        CarPool.instace.CurrentCar++;
        carGo.transform.position = spawnPoints[id].transform.position;
        carGo.SetActive(true);
        carGo.GetComponent<Car>().Speed = speed;
        carGo.GetComponent<MeshRenderer>().sharedMaterial = carMaterials[Random.Range(0, carMaterials.Length)];
    }
}
