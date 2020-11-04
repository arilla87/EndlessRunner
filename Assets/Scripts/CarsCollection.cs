using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsCollection : MonoBehaviour
{
    public static CarsCollection instance;
    private List<GameObject> carList = new List<GameObject>();
    protected void Awake(){
        instance = this;
    }

    public void AddCarToList(GameObject go){
        carList.Add(go);
    }

    public List<GameObject> GetCarsList(){
        return carList;
    }

    public void RemoveCarFromList(GameObject go){
        carList.Remove(go);
    }

}
