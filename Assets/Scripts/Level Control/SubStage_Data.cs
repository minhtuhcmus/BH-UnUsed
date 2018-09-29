using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Substage", menuName = "Stage_create/Substage", order = 1)]
[ExecuteInEditMode]
public class SubStage_Data : ScriptableObject {
	[Header("Substage")]
	public float minDistanceBetween2Saws = 50;
	public bool calculate = false;
	public List<SawData> listOfSaws = new List<SawData>();

	public void OnValidate() {
		if(calculate) {
			Debug.Log("abc");
			int numOfSaws = listOfSaws.Count;
			for(int i = 0; i < numOfSaws - 1; i++) {
				int j = i + 1;
				switch (listOfSaws[i].side) {
					case SawData.SIDE.left: 
						if(listOfSaws[j].side == SawData.SIDE.left) {
							alignSaws(listOfSaws[i], listOfSaws[j]);
						} 
						break;
					case SawData.SIDE.right:
						if(listOfSaws[j].side == SawData.SIDE.right) {
							alignSaws(listOfSaws[i], listOfSaws[j]);
						} 
						break;
				}
			}
			
			for(int i = 0; i < numOfSaws; i++) {
				if(listOfSaws[i].maxY < 0 || listOfSaws[i].minY < 0 || listOfSaws[i].maxY > 1334 || listOfSaws[i].minY > 1334) {
					listOfSaws[i].isOK = false;
				}
				else {
					listOfSaws[i].isOK = true;
				}
			}
			calculate = false;
		}
	}
	
	protected void alignSaws(SawData SawA, SawData SawB) {

		if(SawB.minY > SawB.maxY) SawB.maxY = SawB.minY;
		if(SawA.maxY < SawA.minY) SawA.minY = SawA.maxY;

		float realMaxY_A = SawA.maxY + SawA.range/2;
		float realMinY_B = SawB.minY - SawB.range/2 - minDistanceBetween2Saws;
		if(realMinY_B < realMaxY_A) {
			float touchedDistance_Half = (realMaxY_A - realMinY_B) / 2; 
			if(SawA.maxY - touchedDistance_Half >= 0) {
				SawA.maxY -= touchedDistance_Half;
				SawB.minY += touchedDistance_Half;
			}
			else {
				SawB.minY += touchedDistance_Half * 2;
			}
			if(SawB.minY > SawB.maxY) SawB.maxY = SawB.minY;
			if(SawA.maxY < SawA.minY) SawA.minY = SawA.maxY;
		}
	}
}

[System.Serializable]
public class SawData {
	public enum SIDE {left, right};
	[Range(0,1334)]
	public float minY;
	[Range(0,1334)]
	public float maxY;
	public SIDE side = new SIDE();
	public float range;
	public bool isOK = true;
}
