using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorralController : MonoBehaviour {

    private int countSheep;
    public Text winText;
    public Text sheepCounter;
    public Text timerText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (countSheep == 10)
        {
            winText.text = "You Win!!";
        }
        else
        {
            timerText.text = Time.time.ToString("0.0");
        }        
    }    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sheep"))
        {
            Debug.Log("Sheep"+ countSheep);
            other.tag = "Sheep Corralled";
            countSheep++;
            sheepCounter.text = countSheep.ToString() + " / 10";           
        }
        
    }
}
