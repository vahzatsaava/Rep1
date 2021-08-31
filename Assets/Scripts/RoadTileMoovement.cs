using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTileMoovement : MonoBehaviour
{

    //переменная для установления скорости движения дороги
    public static float speed = 5;

    

    #region //Свойство для приватного поля
    //public float Speed { set { speed = value; } }
    #endregion

    /// <summary>
    /// Реализация движения дороги в обратном направлении
    /// </summary>
    void Update()
    {
        gameObject.transform.Translate(Vector3.back *speed*Time.deltaTime);
        
    }
}
