using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTerrrain : MonoBehaviour
{
    private TerrainManager terrainManager;

    protected void Awake(){
        terrainManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<TerrainManager>();
    }

   protected void OnTriggerEnter(Collider other){
       terrainManager.MoveTerrain(gameObject.transform.parent.gameObject);
   }
}
