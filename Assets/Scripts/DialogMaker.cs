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
    private int messCounter=0;
    private int whoTalk = 1;
    private bool toChoose = false;
    

    // Start is called before the first frame update
    void Start()
    {
        AnswerButtons = Instantiate (AnswerButtonsPref, Vector3.zero,Quaternion.identity) as GameObject;
            AnswerButtons.SetActive(false);

        myCloud  = Instantiate (TextCloud, TextCloudPosition.position,Quaternion.identity) as GameObject;
        himCloud  = Instantiate (TextCloud, new Vector3(TextCloudPosition.position.x+distance,TextCloudPosition.position.y,TextCloudPosition.position.z),Quaternion.identity) as GameObject;
               myCloud.SetActive(false);
               himCloud.SetActive(false);

    }

    void Update()
    {
        messCounter = myCounter+himCounter;
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
