using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarRightLeft : MonoBehaviour
{
   
    //создаем константу 
    private const float ROAD_STEP = 3.3f;
    //переменная панели проигрыша
    [SerializeField] private  GameObject loosePanel;
    //очки подсчета собранных монет
    [SerializeField] private int count;
    [SerializeField] private Text textCount;
    [SerializeField] private AudioSource triggerCoin;
    [SerializeField] private ParticleSystem crashEffects;
    private Animator animator;
    
    


    void Start()
    {//делаем так чтобы игра продолжалась после нажатия рестарта
        Restarts();
        animator = GetComponent<Animator>();

    }

    
   
    /// <summary>
    /// Начинаем играть заново после нажатия кнопки рестарт 
    /// С возвращениием начальной скоростии объекта
    /// </summary>
    private void Restarts()
    {
        Time.timeScale = 1;
        RoadTileMoovement.speed = 5;
    }  
    void Update()
    {
        MooveRightLeft();
      
               
    }
    /// <summary>
    /// Метод реализует движение вправо и влево 
    /// </summary>
    private void MooveRightLeft()
    {
        //GetKeyDown используем чтобы машина реагировала не сильно на нажатие клавиатуры,тк используя просто GetKey машинка уедет далеко

        if (Input.GetKeyDown(KeyCode.RightArrow) && gameObject.transform.position.x < ROAD_STEP)
        {
          // gameObject.transform.Translate(new Vector3(ROAD_STEP, 0, 0));
            animator.SetBool("MooveRight", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameObject.transform.position.x > -ROAD_STEP)
        {
            //gameObject.transform.Translate(new Vector3(-ROAD_STEP, 0, 0));
           animator.SetBool("MooveLeft", true);
        }
    }

   



    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Coin"))
        {
            count++;//счетчик монеток
            textCount.text = count.ToString();
            Destroy(other.gameObject);
            triggerCoin.Play();
            
        }

        //Столкновение с машинами и появление панели рестарта
        if (other.gameObject.CompareTag("AnotherC"))
        {
            //  gameObject.SetActive(false);
            // Destroy(gameObject);
           
            loosePanelActive(); 
            crashEffects.Play();
        }


    }

    
    /// <summary>
    /// Реализуем появление панели Рестарта и останавливаем счетчик времени
    /// </summary>
   private  void loosePanelActive()
    {
        loosePanel.SetActive(true);
        Time.timeScale = 1;
        

    }
    
    
}
