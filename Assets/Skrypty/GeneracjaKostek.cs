using System.IO;
using UnityEngine;

public class GeneracjaKostek : MonoBehaviour {

	public int ileKostek = 5;
	public GameObject kostka;
    // określamy ile kostek ma być

	private void Start () {
		string[] temp = Resources.Load<TextAsset> ("pytania").text.Split('\n');
        // ładujemy pyytania do każdej kostki z pliku
		for (int i = 0; i < ileKostek; i++)
        // standardowa pętla
        {
			GameObject g = Instantiate (kostka, new Vector3 (Random.Range (0, 20f), 5, Random.Range (0, 20f)), Quaternion.Euler(new Vector3(Random.Range(-180, 180), Random.Range (-180, 180), Random.Range (-180, 180))));
            // generujemy ileś kostek i losujemy ich pozycje w przedziałach
			g.GetComponent<Zadanie> ().trescZadania = temp[i];
			g.GetComponent<Rigidbody> ().AddForce (Vector3.up * 5, ForceMode.Impulse);
            // dodajemy do każdej kostki treść zadania oraz wywalamy ją w góre ( bo tak )
		}
		//GameObject.Find ("RawImage").SetActive (false);
	}

}
