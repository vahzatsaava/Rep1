using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpeedBack : MonoBehaviour
{
    private float speed;
   
    
    private void Start()
    {
        speed = 8f;

    }
    // Update is called once per frame
    void Update()
    {
        Speed();
        DestroyCoinInPosition();
       
       
    }

   private void Speed()
    {
        transform.Translate(Vector3.back * (speed * Time.deltaTime));
 
    }
    /// <summary>
    /// Уничтожение монеток если их позиция больше или равна -10
    /// </summary>
    private void DestroyCoinInPosition()
    {
        
        if (transform.position.z<-10)
        {
            Destroy(gameObject);
        }
    }
    
    
}
