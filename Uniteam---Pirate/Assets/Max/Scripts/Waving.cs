using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving : MonoBehaviour {

	[SerializeField] Vector3 topPosition;
	[SerializeField] Vector3 bottomPosition;
	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		StartCoroutine (wave (topPosition));	
		//StartCoroutine (tangue (topPosition));	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator wave(Vector3 target) {
		while (Mathf.Abs ((target - transform.localPosition).y) > 0.20f) {
			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * speed * Time.deltaTime;

			//transform.Rotate(Vector3.back * 100 * Time.deltaTime);

			print(Mathf.Sin((target - transform.localPosition).y)*10);
			transform.localRotation = Quaternion.Euler( new Vector3(0,  Mathf.Sin((target - transform.localPosition).y)*10, 0));

			yield return null;
		}
		yield return new WaitForSeconds (0.25f);

		Vector3 newTarget = target.y == topPosition.y ? bottomPosition: topPosition;

		StartCoroutine (wave (newTarget));
	}

	//IEnumerator tangue(Vector3 target) {
		/*while (Mathf.Abs ((target - transform.localRotation)) > 0.20f) {
			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * speed * Time.deltaTime;

			//transform.Rotate(Vector3.back * 100 * Time.deltaTime);

			//print(transform.rotation);

			yield return null;
		}
		yield return new WaitForSeconds (0.25f);

		Vector3 newTarget = target.y == topPosition.y ? bottomPosition: topPosition;

		StartCoroutine (wave (newTarget));*/
	//}

}
