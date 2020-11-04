using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instace;
    [SerializeField] private float timer;
    private GameObject[] scenarioGameObject;
    private GameObject playerGameObject;
    private float currentTime = 0;
    private Vector3[] scenarioSpawnPos;
    private Vector3 playerSpawnPos;
    
    public delegate void UpdateUITextDelegate(string text);
    public event UpdateUITextDelegate OnCarsCounterChanged;

    protected void Awake(){
        instace = this;    
    }

    protected void Start(){
        InitGame();
    }

    protected void Update(){
        currentTime += Time.deltaTime;

        if(currentTime > timer){
            MoveCars(CarsCollection.instance.GetCarsList());
            MovePlayer();
            MoveScenario();

            currentTime = 0;
        }
    }

    public void AddNewCar(string c){
        OnCarsCounterChanged?.Invoke(c);
    }

    public void InitGame(){
        CarPool.instace.StartPool();
        GameObject.FindGameObjectWithTag("CarsSpawner").GetComponent<SpawnGenerator>().CarSpawn(true);
        playerGameObject.GetComponent<PlayerMovement>().Running = true;
    }

    private void MovePlayer(){
        playerGameObject.transform.position = playerSpawnPos;
    }

    private void MoveScenario(){
        for(int i = 0; i < scenarioGameObject.Length; i++){
            scenarioGameObject[i].transform.position = scenarioSpawnPos[i];
        }
    }

    void MoveCars(List<GameObject> goList){
         for(int i = 0; i < goList.Count; i++){
            GameObject g = goList[i];
            float z = goList[i].transform.position.z -playerGameObject.transform.position.z;
            goList[i].transform.position = new Vector3(goList[i].transform.position.x, goList[i].transform.position.y, z) + new Vector3(0,0,playerSpawnPos.z);
         }
     }

    public void SetScenarioSpawnPos(GameObject[] scenario){
        scenarioGameObject = new GameObject[scenario.Length];
        scenarioSpawnPos = new Vector3[scenario.Length];
        for (int i = 0; i < scenario.Length; i++)
        {
            scenarioGameObject[i] = scenario[i];
            scenarioSpawnPos[i] = scenario[i].transform.position;
        }
    }

    public void SetPlayerSpawnPos(GameObject player){
        playerGameObject = player;
        playerSpawnPos = player.transform.position;
    }
}
