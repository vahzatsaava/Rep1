using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    //Массив Машин ,все машина храняться в данном массиве
    [SerializeField] private List<GameObject> cars;
    //константа перемещения по х(перемещение влево и вправо)
    private const float ROAD_STEP=3.3f;
    //дистанция машинок по оси z
    private const float SPAWN_DISTANCE = 15f;
    //время появления машинок
    private const float TIME_STEP = 2f;

    private float _time;
    
    // Статовые позиции машинок
    private List<Vector3> _spawnPoint=new List<Vector3>();

   
    void Start()
    {
        SetSpawnPoint();
        _time = TIME_STEP;
        CheckCarPosition();
    }
    /// <summary>
    /// Генерируем стартовые позиции машин
    /// </summary>
    private void SetSpawnPoint()
    {
        _spawnPoint.Add(new Vector3(-ROAD_STEP, 0, SPAWN_DISTANCE));
        _spawnPoint.Add(new Vector3(0, 0, SPAWN_DISTANCE));
        _spawnPoint.Add(new Vector3(ROAD_STEP, 0, SPAWN_DISTANCE));
    }
   
    void Update()
    {
        _time -= Time.deltaTime;//время вывода машинок
        if (_time<0)
        {
            SpawnCAR();
            _time = TIME_STEP;
             
        }
       
    
       
    }
    /// <summary>
    /// Реализуем случайное появление машин и случайной дорожки
    /// </summary>
    private void SpawnCAR()
    { //создаем переменную randomCar,котороя генерирует случайные значения от 0 до длины 
        GameObject randomCAR = cars[Random.Range(0, cars.Count)];
        //рандомные значения позиции
        Vector3 randomRoadPosition = _spawnPoint[Random.Range(0, _spawnPoint.Count)];
        Instantiate(randomCAR, randomRoadPosition, Quaternion.identity);
    }

  private void CheckCarPosition()
    {
        if (cars==null|| cars.Count==0)
        {
            return;

        }
        int numberOfCars = cars.Count;
        for (int i = 0; i < numberOfCars; i++)
        {
            if (cars[i].transform.position.z<-10)
            {
                Destroy(cars[i]);
                cars.Remove(cars[i]);
                
            }
        }
    }
   

}
