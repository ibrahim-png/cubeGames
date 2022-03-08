using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamond4side : MonoBehaviour
{ 
private GameObject human;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(0, 60 * Time.deltaTime, 0);

        human = GameObject.FindWithTag("Player");


        if (human.transform.position.z - transform.position.z > 10) //eger player diamond dan uzaklasmıssa öldür diamond u 
        {
            Destroy(gameObject);
            
	Debug.Log("silindi" );
        }
         
    }
    private void OnTriggerEnter(Collider other){
		Debug.Log("diamond4side a carpti");
	}
}
