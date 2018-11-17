using UnityEngine;
using UnityEngine.UI;

public class Zadanie : MonoBehaviour {

	public Text trescZadaniaText;
	public GameObject trescZadaniaTlo;
	public string trescZadania;

	private void Start () {
		trescZadaniaText = GameObject.Find ("TrescZadania").GetComponent<Text>();
		trescZadaniaTlo = GameObject.Find ("RawImage");
        // pobieramy własności o treści i obrazku zadania
	}

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			trescZadaniaText.text = trescZadania;
			trescZadaniaTlo.gameObject.SetActive (true);
            // jeśli będziemy kolidować z objektem to wyświetli się treść zadania
		}
			
	}
	
	private void OnTriggerExit (Collider other) {
		if (other.tag == "Player")
			trescZadaniaTlo.gameObject.SetActive (false);
        // gdy oddalimy się od objektu, to zniknie okienko uprzednio wywołane
	}

}
