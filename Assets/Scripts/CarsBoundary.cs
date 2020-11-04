using UnityEngine;

public class CarsBoundary : MonoBehaviour
{
    private int carsCounter = 0;
    protected void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Car")){
            GameManager.instace.AddNewCar(carsCounter.ToString());
            CarsCollection.instance.RemoveCarFromList(other.gameObject);
            other.gameObject.SetActive(false);
            carsCounter++;
        }
    }
}
