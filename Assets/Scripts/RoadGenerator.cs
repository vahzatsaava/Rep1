using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    #region First realization
    //создаем объект 
    [SerializeField] private GameObject roadTile;
    //увеличение плитки на 50 метров по оси z на 50 метров вперед
    [SerializeField] private Vector3 startRoadTilePosition = new Vector3(0, 0, 50);
    [SerializeField] private Vector3 finishRoadPOsition = new Vector3(0, 0, -10);

    [SerializeField] private int numberOfStartingTiles = 5;
    //создаем массив 
    private List<GameObject> _roadTiles;
    

    void Start()
    {
        _roadTiles = new List<GameObject>();
        startGenerate();

    }



    private void startGenerate()
    {
        for (int i = 0; i < numberOfStartingTiles * 10; i += 10)
        {
            GameObject tile = Instantiate(roadTile, new Vector3(0, 0, i), Quaternion.identity);
            //добавляем дорогу используя метод Add
            _roadTiles.Add(tile);
        }
    }

    // Update is called once per frame
    void Update()
    {//метод добавления дороги и удаления проезженной части дороги
        CheckRoadTile();
        //Метод реализации ускорения машинки
        CheckUserInput();
    }
    private void CheckUserInput()
    { //Генериция увеличения скорости Машинки 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseSpeed();

        }
    }
    //Генериция увеличения скорости Машинки (Метод)
    private void IncreaseSpeed()
    {
        RoadTileMoovement.speed *= 2;
    }

    private void CheckRoadTile()
    {//проверят создан ли массив     / есть ли Элементы в массиве
     // всегда проводить эту проверку
        if (_roadTiles == null || _roadTiles.Count == 0)
        {
            return;
        }
        int numberOfTiles = _roadTiles.Count;
        for (int i = 0; i < numberOfTiles; i++)

        {
            if (_roadTiles[i].transform.position.z < -10f)
            {
                Destroy(_roadTiles[i]);
                _roadTiles.Remove(_roadTiles[i]);
                CreateNewRoadTile();
                //GameObject newTile= Instantiate(roadTile, startRoadTilePosition, Quaternion.identity);
                // _roadTiles.Add(newTile);
            }

        }




    }
    //создаение и добавление в Массив новой дорожки
    private void CreateNewRoadTile()
    {
        GameObject tile = Instantiate(roadTile, startRoadTilePosition, Quaternion.identity);
        _roadTiles.Add(tile);

    }
    #endregion




}
