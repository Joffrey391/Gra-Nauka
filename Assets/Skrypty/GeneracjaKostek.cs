using System.IO;
using UnityEngine;

public class GeneracjaKostek : MonoBehaviour {

	public int ileKostek = 5;
	public GameObject kostka;

	private void Start () {
		string[] temp = Resources.Load<TextAsset> ("pytania").text.Split('\n');
		for (int i = 0; i < ileKostek; i++) {
			GameObject g = Instantiate (kostka, new Vector3 (Random.Range (0, 20f), 5, Random.Range (0, 20f)), Quaternion.Euler(new Vector3(Random.Range(-180, 180), Random.Range (-180, 180), Random.Range (-180, 180))));
			g.GetComponent<Zadanie> ().trescZadania = temp[i];
			g.GetComponent<Rigidbody> ().AddForce (Vector3.up * 50, ForceMode.Impulse);
		}
		//GameObject.Find ("RawImage").SetActive (false);
	}

}
