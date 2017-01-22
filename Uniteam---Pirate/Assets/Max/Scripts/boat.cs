using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class boat : MonoBehaviour {

	//[SerializeField] private GameObject fournace;
	private const int LIFE = 3;
	[SerializeField] private GameObject hull1;
	[SerializeField] private GameObject hull2;
	[SerializeField] private GameObject hull3;

	private List<GameObject> undamageHullParts;
	private List<GameObject> damageHullParts;

	private bool gameOver = false;

	void Awake() {
		//Assert.IsNotNull (hull1);
		//Assert.IsNotNull (hull2);
		//Assert.IsNotNull (hull3);
	}
	void Start () {
		undamageHullParts = new List<GameObject>(); 
		damageHullParts = new List<GameObject>(); 
		undamageHullParts.Add(hull1);
		undamageHullParts.Add(hull2);
		undamageHullParts.Add(hull3);

		for(int i =0; i < 100; i++){
			damageHull();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void startEvent(){

	}

	public void damageHull() {

        int index = Random.Range(0, undamageHullParts.Count);
        if (!gameOver){
            print("NBR hull: " + undamageHullParts.Count);
		    undamageHullParts[index].transform.Find("UnDmgHull").gameObject.SetActive(false);
		    undamageHullParts[index].transform.Find("DmgHull").gameObject.SetActive(true);
		    damageHullParts.Add(undamageHullParts[index]);
		    undamageHullParts.RemoveAt(index);

		    if(damageHullParts.Count == LIFE){
			    print("GameOver");
		        gameOver = true;
		    }
        }
    }
	public void repairHull(GameObject hullToBeRepaired) {
		if(!gameOver){
			int index = damageHullParts.IndexOf(hullToBeRepaired);
			undamageHullParts[index].transform.Find("DmgHull").gameObject.SetActive(false);
			undamageHullParts[index].transform.Find("UnDmgHull").gameObject.SetActive(true);
			undamageHullParts.Add(damageHullParts[index]);
			damageHullParts.RemoveAt(index);
		}
	}
	
}
