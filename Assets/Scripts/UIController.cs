using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private Text carCounter;

    private void Start() {
        GameManager.instace.OnCarsCounterChanged += UpdateCarsValue;
    }

    private void OnDisable() {
        GameManager.instace.OnCarsCounterChanged -= UpdateCarsValue;
    }
    
    private void UpdateCarsValue(string currentCars) => carCounter.text = currentCars;
}
