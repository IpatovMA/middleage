using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogMaker : MonoBehaviour
{
    //public Transform TextCloudPosition;
    public GameObject TextCloudPrefab;
    public string[] questText;
    public string[] YesText;
    public string[] NoText;

    public GameObject AnswerButtons;
    private GameObject TextCloud;
    private int messCounter=0;
    

    // Start is called before the first frame update
    void Start()
    {
        TextCloud= Instantiate (TextCloudPrefab, GetComponent<Transform>().position,Quaternion.identity) as GameObject;
        if (Config.LevelState == 1){
            Config.Choose = -1;
            WriteText(questText[Config.levelComplete],TextCloud);
            AnswerButtons.SetActive(true);
        }
        if (Config.LevelState == 3){
            AnswerButtons.SetActive(false);

        if (Config.isDead){
            WriteText("Mission failed",TextCloud);
        } else{
            WriteText("Well done",TextCloud);
        }
        }

     //   AnswerButtons = Instantiate (AnswerButtonsPref, Vector3.zero,Quaternion.identity) as GameObject;


    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)&&(Config.Choose!=-1)){
           Config.LevelState = 2;
             SceneManager.LoadScene("Runner");

       }
/*        messCounter = myCounter+himCounter;
        if (Input.GetKeyDown(KeyCode.Space)&&(messCounter<TotalMesseangeNumber)){
           if (whoTalk>0){
               himCloud.SetActive(false);
               myCloud.SetActive(true);
               WriteText(mytext[myCounter],myCloud);
               myCounter++;  
           } else if (whoTalk<0) {
               myCloud.SetActive(false);
               himCloud.SetActive(true);
               WriteText(himtext[himCounter],himCloud);
               himCounter++; 
           }
            whoTalk = -whoTalk;  
            if (messCounter==TotalMesseangeNumber)  {
                Debug.Log("qqwe");
                messCounter++;}
       }

        Debug.Log(messCounter+"  "+TotalMesseangeNumber);
        if ((messCounter>=TotalMesseangeNumber)&&!AnswerButtons.activeSelf){
            AnswerButtons.SetActive(true);
        } */

    }

    private void WriteText(string text,GameObject textCloud){
        TextMesh mesh = textCloud.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
       mesh.text = text;
    }
    public void SayYes(){
      Config.Choose = 1;
      WriteText(YesText[Config.levelComplete],TextCloud);
    }
    public void SayNo(){
      Config.Choose = 0;
      WriteText(NoText[Config.levelComplete],TextCloud);
    }
}
