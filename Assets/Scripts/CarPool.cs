using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPool : MonoBehaviour
{
	public static CarPool instace;
	[SerializeField] private GameObject[] carPrefab;
	[SerializeField] private int CarPoolSize;
	public int CurrentCar{get{return currentCar;} set{currentCar = value;}}
	[SerializeField]private GameObject[] cars;
	private int currentCar;

	protected void Awake(){
		instace = this;	
	}

	public void StartPool(){
		currentCar = 0;
		cars = new GameObject[CarPoolSize];
		int totalCars = 0;
		for (int i = 0; i < cars.Length; i++)
		{
			cars[i] = Instantiate(carPrefab[totalCars]);
			cars[i].SetActive(false);
			totalCars++;
			if(totalCars > carPrefab.Length - 1) totalCars = 0;
		}
	}
	
	public GameObject GetCar()	{
			if (currentCar >= CarPoolSize) currentCar = 0;
			cars[currentCar].SetActive(true);
			return cars[currentCar];
		}
	}