using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMaker : MonoBehaviour
{
    public Transform TextCloudPosition;
    public GameObject TextCloud;
    public string[] mytext;
    public string[] himtext;
    public int TotalMesseangeNumber;
    public float distance =25f;

    public GameObject AnswerButtonsPref;
    private GameObject AnswerButtons;
    private GameObject myCloud;
    private int myCounter=0;
    private GameObject himCloud;
    private int himCounter=0;
    private int whoTalk = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        AnswerButtons = Instantiate (AnswerButtonsPref, Vector3.zero,Quaternion.identity) as GameObject;
            AnswerButtons.SetActive(false);
                    Debug.Log(AnswerButtons.activeSelf);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)&&(myCounter+himCounter<TotalMesseangeNumber)){
           if (whoTalk>0){//если четное касание
                if(myCounter==0){
            myCloud  = Instantiate (TextCloud, TextCloudPosition.position,Quaternion.identity) as GameObject;
                }
               WriteText(mytext[myCounter],myCloud);
               myCounter++;  
           } else if (whoTalk<0) {//если нечетное
                if(himCounter==0){
            himCloud  = Instantiate (TextCloud, new Vector3(TextCloudPosition.position.x+distance,TextCloudPosition.position.y,TextCloudPosition.position.z),Quaternion.identity) as GameObject;
                }

               WriteText(himtext[himCounter],himCloud);
                
               himCounter++; 
 
           }
            whoTalk = -whoTalk;  
            if (myCounter+himCounter==TotalMesseangeNumber)  {myCounter++;}

       }
        Debug.Log(AnswerButtons.activeSelf);
        if ((myCounter+himCounter>TotalMesseangeNumber)&&!AnswerButtons.activeSelf){
            AnswerButtons.SetActive(true);
        }

    }
    private GameObject ShowCloud(GameObject TextCloud,Vector3 position){
        var mess = Instantiate (TextCloud, position,Quaternion.identity) as GameObject;
        return mess;
    }
    private void WriteText(string text,GameObject textCloud){
        TextMesh mesh = textCloud.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
       mesh.text = text;
    }
}
