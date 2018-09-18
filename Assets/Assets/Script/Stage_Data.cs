using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "Stage_create/Stage", order = 1)]
public class Stage_Data : ScriptableObject {
	[Header("Stage")]
	public List<Stage> listOfStages = new List<Stage>();
	
}

[System.Serializable]
public class Stage {
	public List<SubStage_Data> listOfSubstages;
}