using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    [SerializeField] private GameObject[] scenarioGO;
    private float size;
    private Vector3 amountToMove;

    protected void Start(){
        GameManager.instace.SetScenarioSpawnPos(scenarioGO);
        size = scenarioGO[0].GetComponent<BoxCollider>().bounds.size.z;
        amountToMove = new Vector3(0, 0, size * scenarioGO.Length);
    }
    public void MoveTerrain(GameObject terrain){
        terrain.transform.position = terrain.transform.position + amountToMove;
    }
}
