using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{  /// <summary>
/// Вращение Колес по Оси Х
/// </summary>
    void Update()
    {
        lightRotation();
      
    }

    private void lightRotation()
    {  
        transform.Rotate(new Vector3(10f, 0f, 0f));

    }
   

}
