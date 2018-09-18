using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour {
    public SubStage_Data subStage;
    private List<SawData> listOfSaws;

	// Use this for initialization
	void Start () {
        listOfSaws = subStage.listOfSaws;
        for(int i = 0; i < listOfSaws.Count;  i++)
        {
            Saw newSaw = GameObject.Find("Saw (" + i + ")").GetComponent<Saw>();
            newSaw.intit(listOfSaws[i].minY, listOfSaws[i].maxY, listOfSaws[i].range, (int)listOfSaws[i].side);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
