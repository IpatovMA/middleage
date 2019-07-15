using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelBuilder : MonoBehaviour
{
    public GameObject[] Blocks;
    public GameObject FinalBlock;
    public Transform BlockSpawnerPos;
    public Vector3 StartSpawnerPos;
    
    private int BlockCount =0;
    public float NewPos = 5.0f;
    public int LevelLenght = 1;
    public static Vector3 vLevelLenth;
    public int blockVariants = 5;

    private float waitTime = 2.0f;
    private GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawnerPos = BlockSpawnerPos.position;
        levelCreation();
     //  vLevelLenth = new Vector3 (BlockSpawnerPos.position.x,BlockSpawnerPos.position.y) - StartSpawnerPos;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void levelCreation(){
      for (BlockCount=1; BlockCount< LevelLenght; BlockCount++){
        Block();
      }
      block = Instantiate (FinalBlock, BlockSpawnerPos.position,Quaternion.identity) as GameObject;
    }


    private void Block()
    {
      block = Instantiate (Blocks[Random.Range(0,blockVariants)], BlockSpawnerPos.position,Quaternion.identity) as GameObject;
      Vector3 temp = BlockSpawnerPos.position;
      temp.x += NewPos;
      temp.y = 0;
      temp.z  = 0;
      BlockSpawnerPos.position = temp;
    }

}
