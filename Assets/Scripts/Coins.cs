using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private List<GameObject> coins;
    //константа перемещения по оси х
    private const float ROAD_STEP_COINS = 3.3f;
    // создание объекта по оси Y
    private const float SPAWN_DISTANCE_COINS= 20f;
    //секунды на создание монеток
    private const float TIME_STEP_COINS = 3f;


    private float time;
    //Стартовые позиции монеток
    private List<Vector3> _spawnCoins = new List<Vector3>();
    void Start()
    {
        
        SetspawnCoin();
        time = TIME_STEP_COINS;
    }

    private void SetspawnCoin()
    {     //позиция по центру
        _spawnCoins.Add(new Vector3(0, 0.5f, SPAWN_DISTANCE_COINS));
        //позиция справа
        _spawnCoins.Add(new Vector3(ROAD_STEP_COINS, 0.5f, SPAWN_DISTANCE_COINS));
        //позиция слева
        _spawnCoins.Add(new Vector3(-ROAD_STEP_COINS, 0.5f, SPAWN_DISTANCE_COINS));

    }

    // Update is called once per frame
    void Update()
    {
      
        time -= Time.deltaTime;

        if (time < 0)
        { SpawnCoin();
            time = TIME_STEP_COINS;
           

        }

      
        
    }
    
    private void SpawnCoin()
    {//переменная randomCoin котороя генерирует случайные значения монеток
        GameObject randomCoin = coins[Random.Range(0, coins.Count)];
        //рандомные значения позиции
        Vector3 randomCoinPosition = _spawnCoins[Random.Range(0, _spawnCoins.Count)];
        //создание объекта
        Instantiate(randomCoin, randomCoinPosition, Quaternion.identity);
    }


    
}
