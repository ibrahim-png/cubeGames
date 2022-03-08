using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{
    [SerializeField]
    private Text diamondText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPoint(int diamond)
    {

        gameObject.SetActive(true); //gameOver ekranınının gösterilmesi etkinleştiriliyor.
        diamondText.text = "-" + diamond.ToString() + " DIAMONDS";
    }


    public void restart()
    {
        SceneManager.LoadScene("a");
    }
}
