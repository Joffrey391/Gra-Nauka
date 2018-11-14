using UnityEngine;
using UnityEngine.UI;

public class Zadanie : MonoBehaviour {

	public Text trescZadaniaText;
	public GameObject trescZadaniaTlo;
	public string trescZadania;

	private void Start () {
		trescZadaniaText = GameObject.Find ("TrescZadania").GetComponent<Text>();
		trescZadaniaTlo = GameObject.Find ("RawImage");
	}

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			trescZadaniaText.text = trescZadania;
			trescZadaniaTlo.gameObject.SetActive (true);
		}
			
	}
	
	private void OnTriggerExit (Collider other) {
		if (other.tag == "Player")
			trescZadaniaTlo.gameObject.SetActive (false);
	}

}
