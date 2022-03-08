using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{

    public bool isClickPlayButton = false;
    public gameOverScreen gameOverScreen;
public TextMeshProUGUI textMeshPoint;   
public TextMeshProUGUI textMeshLife;


    public GameObject playBackground;
    public GameObject finishBackground;
    public GameObject FloatTextPrefab;
    [SerializeField]
    private Text levelText;
    int totalPoints = 0;
    int life = 0;//başta sıfır olarak atıyoruz. Eger hiç oyuna girlmemişse start da kontrol edilip 3 atılıyor .
    public GameObject cameraObject;
    int level = 1;
    float speed = 10;
    Rigidbody rb;
    Vector3 moveDir = Vector3.zero;
    CharacterController kontrol;
    Animator anim;  
    int isPressW = 0;
    [SerializeField]
    private GameObject konfetiGameObject;

    [SerializeField]
    private GameObject yellowKonfeti;
    [SerializeField]
    private GameObject blueKonfeti;
    


    void Start()
    {
        if (PlayerPrefs.HasKey("isComingFromOtherScene"))
        {
            if (PlayerPrefs.GetInt("isComingFromOtherScene") == 1) //baska sahneden geliyorsa direkt olarak başlaması gerekiyor. o yüzden aşağıda sanki play butonuna basılmıs gibi gösterip background u yok ediyoruz.
            {
                setIsClickPlayButtonTrue();
                playBackground.SetActive(false);
            }
            PlayerPrefs.SetInt("isComingFromOtherScene", 0);//sonra tekrar 0 a eşitliyorum.
        }


        //load kontrolleri
        if (!PlayerPrefs.HasKey("Life")) //oyun en başta açıldıgında Life diye bir key yoksa can hakkına 3 ü tanımlıyorum.
        {
           PlayerPrefs.SetInt("Life",3);
        }
        else //varsa direkt olarak onu alıyorum.
        {
            life = PlayerPrefs.GetInt("Life");
            
        }



        if (!PlayerPrefs.HasKey("Diamond"))
        {
            PlayerPrefs.SetInt("Diamond",0);
        }
        else //varsa direkt olarak onu alıyorum.
        {
            textMeshPoint.text = PlayerPrefs.GetInt("Diamond").ToString();
        }



        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        else //varsa direkt olarak onu alıyorum.
        {
            level = PlayerPrefs.GetInt("Level");
        }

        if (!PlayerPrefs.HasKey("dimaondEarnMultiple")) //oyun en başta açıldıgında Life diye bir key yoksa can hakkına 3 ü tanımlıyorum.
        {
            PlayerPrefs.SetInt("dimaondEarnMultiple", 1);
        }


        textMeshLife.text = life.ToString();//ekran görsellerine yansıtılıyor
        levelText.text = "LEVEL " +level.ToString();//ekran görsellerine yansıtılıyor

        rb = GetComponent<Rigidbody>();

        kontrol = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.W) && isClickPlayButton == true)
        {
          isPressW = 1;
          
        }
        if (Input.GetKeyDown(KeyCode.D) && isClickPlayButton == true)
        {
         transform.position = new Vector3(transform.position.x + 1 ,transform.position.y,transform.position.z);
          if (transform.position.x >1)
          {
             transform.position = new Vector3( 1 ,transform.position.y,transform.position.z);
          }
        }
         if (Input.GetKeyDown(KeyCode.A) && isClickPlayButton == true)
        {
         transform.position = new Vector3(transform.position.x - 1 ,transform.position.y,transform.position.z);
          if (transform.position.x < -1)
          {
             transform.position = new Vector3( -1 ,transform.position.y,transform.position.z);
          }
        }
       // rb.AddForce(Vector3.forward*0.5f);
		if (isPressW == 1)
        {
            anim.SetInteger("hareket",1); // karekterin koşma animasyonu başlar
            Vector3 movement = new Vector3(0, 0, 1);//karaktere hareket hızını verir.
            transform.Translate(movement * speed * Time.deltaTime);
        }
        else if(isPressW == 0)
        {
            moveDir = new Vector3(0,0,0);// karekterin durma animasyonu başlar
            anim.SetInteger("hareket",0);
        }
        else if (isPressW == 2)
        {
            moveDir = new Vector3(0, 0, 0);// karekterin durma animasyonu başlar
            anim.SetInteger("hareket", 2);

            cameraObject.transform.Rotate(0, 10 * Time.deltaTime, 0); // bitişte kendi etrafında dönmesi
            

            if (cameraObject.transform.localRotation.eulerAngles.y > 100)
            {

                finishBackground.SetActive(true);
            }


}
    }
 private void OnTriggerEnter(Collider coll){
		Debug.Log(coll.gameObject.tag);

        if (coll.gameObject.tag == "diamond" || coll.gameObject.tag == "diamond5")
        {
            
            //alınan diamond u sil
            Destroy(coll.gameObject);
            //puan topla
            if (coll.gameObject.tag == "diamond")
            {
                Instantiate(blueKonfeti, transform.position, Quaternion.Euler(new Vector3(0, 0, 0) ) , cameraObject.transform); //mavi konfeti
                addPoint(1);
                createFloatText(1);
            }
            else
            {
                Instantiate(yellowKonfeti, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)) , cameraObject.transform); //sarı konfeti
                addPoint(2);
                createFloatText(2);
            }
            
        }
        else if (coll.gameObject.tag == "barrier")
        {
            //candan düş
            life--;
            textMeshLife.text =life.ToString();
            if (life == 0 )
            {
                //Debug.Log("game over");
                gameOverScreen.setPoint(totalPoints);
                isPressW = 0;//update fonksiyonu içerisinde w degerine baktıgında 0 görünce durduruyor.
            }
            createFloatText(-1);
        }
        else if (coll.gameObject.tag == "finishLine")
        {
           // Debug.Log("karakter finishe ulasti");
            //oyunun bu bölümü bitmiş oluyor. Player finish e gelmiş demektir.
            isPressW = 2; // update içerisindeki kod lkarakterin hem hıznı hem de o hızına göre olusan karakteri kontrol ediyor. o yüzden isPressW degeri yeterli olacaktır

            //konfetinin oluşması gerekiyor bölüm bittigi için. (update in içerisinde bunu yazsaydık sürekli olarak konfeti fırlatırdı)
            Instantiate(konfetiGameObject, new Vector3(0, 1, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));

            PlayerPrefs.SetInt("Diamond",totalPoints + PlayerPrefs.GetInt("Diamond")); //artık finish e geldigi için totalpointsleri Diamond key ine atayabilirim.

        }
	}

    private void createFloatText(int pointText)
    {
        
       var textObject= Instantiate(FloatTextPrefab,new Vector3(transform.position.x + 0.2f , transform.position.y + 1.7f , transform.position.z),Quaternion.identity,cameraObject.transform);

        textObject.GetComponent<TextMesh>().text = (pointText* PlayerPrefs.GetInt("dimaondEarnMultiple")).ToString();

        if (pointText == 1)
        {
            textObject.GetComponent<TextMesh>().color = new Color(0, 167, 237, 255);//mavi diamond
            
        }
        else if (pointText == 2)
        {
            textObject.GetComponent<TextMesh>().color = new Color(251, 255, 0, 255);//sari diamond
        }
        else if (pointText == -1)
        {
            textObject.GetComponent<TextMesh>().color = Color.red;//bariyerde kırmızı renk
        }
        
    }

    void addPoint(int point){
        point = point * PlayerPrefs.GetInt("dimaondEarnMultiple");// diamond kazanma çarpanı ile diamond puanını çarpıyoruz.
        totalPoints += point ; // halihazırdaki diamond sayısı ve kazandıgı puanı toplayıp yazıyoruz.
        //Debug.Log("total points" + totalPoints);
        textMeshPoint.text =(totalPoints + PlayerPrefs.GetInt("Diamond") ).ToString();
    }


    public void setIsClickPlayButtonTrue() {
        isClickPlayButton = true;

    }

public void nextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1); //level ı bir arttır
        PlayerPrefs.SetInt("isComingFromOtherScene",1); // baska bir sahneden basarılı olarak geldigini göster
        SceneManager.LoadScene("a"); // sahneyi yükle
        
    }


}
