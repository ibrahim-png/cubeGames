using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bariyer : MonoBehaviour
{private GameObject human;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         human = GameObject.FindWithTag("Player");


        if (human.transform.position.z - transform.position.z > 10) //eger player diamond dan uzaklasmıssa öldür bariyeri 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other){
		
		//Debug.Log("bariyere carpti");
	}
}
