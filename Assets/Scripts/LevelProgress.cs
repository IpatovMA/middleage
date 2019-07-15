using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelProgress : MonoBehaviour
{
        private float progress;
        public Transform Player;
        public levelBuilder levelBuilder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
         progress = (Player.position.magnitude - levelBuilder.StartSpawnerPos.magnitude+levelBuilder.NewPos*2)/(levelBuilder.GetComponent<Transform>().position.magnitude -levelBuilder.StartSpawnerPos.magnitude) ;
        GetComponent<Text>().text = "PROGRESS: " +progress*100 +"%"; 
    }
}
