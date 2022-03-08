using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadController : MonoBehaviour
{
    [SerializeField]
    private GameObject barrierGameObject;
    [SerializeField]
    private GameObject diamondGameObject;
    [SerializeField]
    private GameObject diamond5GameObject;
    [SerializeField]
    private GameObject finishLineGameObject;
    [SerializeField]
    private GameObject human;


    public int roadCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider other){
		transform.position+= new Vector3(0,0,transform.GetChild(0).GetChild(1).GetComponent<Renderer>().bounds.size.z *20 ); //yolu en uca tasıyor
          
          
          Instantiate(barrierGameObject , new Vector3(Random.Range(-1, 2),0,human.transform.position.z + Random.Range(80, 85)) ,  Quaternion.Euler(new Vector3(0, 90, 0))  );
          Instantiate(diamondGameObject , new Vector3(Random.Range(-1, 2),1,human.transform.position.z + Random.Range(86, 92)) ,  Quaternion.Euler(new Vector3(0, 90, 0))  );
          Instantiate(diamond5GameObject , new Vector3(Random.Range(-1, 2),1,human.transform.position.z + Random.Range(95, 110)) ,  Quaternion.Euler(new Vector3(0, 90, 0))  );
        //Debug.Log("yoldan dolayı olustu");


        roadCount++; // her yol olustugunda bir arttır.
        if (roadCount == 4) // yol olusturma sayısı 4 e ulastıgında
        {
           // Debug.Log("ilerideki finishLine objesi olusturuldu");
            Instantiate(finishLineGameObject, new Vector3(0, 1, human.transform.position.z +100), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
	}
}
