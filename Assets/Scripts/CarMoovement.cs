using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoovement : MonoBehaviour
{/// <summary>
 ///Скрипт Движения  наших машинок
 /// </summary>
    //скорость рандомно назначаема нашим машинам

    private float _speed;
    [SerializeField] private AudioSource destroyPlayerSound;


    void Start()
    {
        //рандомное значение скорости
        _speed = 7f;   // Random.Range(1f, 6f);
        CheckInput();
       
    }

    /// <summary>
    /// движение назад по вектору
    /// </summary>
    void Update()
    {
        transform.Translate(Vector3.back * (_speed * Time.deltaTime));
        // CheckInput();
        DestroyCarsInPosition();
    }
    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _speed *= 2;
        }
    }
    private void DestroyCarsInPosition()
    {
        if (transform.position.z<-10)
        {
            Destroy(gameObject);

        }
    }

    /// <summary>
    /// Столкновение игрока с другими машинами
    /// </summary>
    /// <param name="Проигрывание мелодии авариии"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Destroy(other.gameObject);
           destroyPlayerSound.Play();       
        }



    }
}
