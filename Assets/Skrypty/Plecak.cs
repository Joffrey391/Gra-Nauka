using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plecak : MonoBehaviour {

	public const int maksymalnaPojemnosc = 7;
	public List<Item> itemki;
	public Button[] przyciski = new Button[maksymalnaPojemnosc];
	public GameObject kostka;
	bool czyWyswietlic = false;

	private void Start () {
		itemki = new List<Item> ();
	}

	private void OnTriggerStay (Collider other) {
		if (other.tag == "Item") {
			czyWyswietlic = true;
			if (Input.GetKeyDown("i")) {
				itemki.Add (other.GetComponent<ItemRzeczywisty> ().item);
				przyciski[itemki.Count - 1].GetComponent<RawImage> ().texture = itemki[itemki.Count - 1].ikona;
				przyciski[itemki.Count - 1].GetComponentInChildren<Text> ().text = itemki[itemki.Count - 1].nazwa;
				int a = itemki.Count-1;
				przyciski[itemki.Count - 1].onClick.AddListener (delegate { Klikniecie (a.ToString()); });
				Destroy (other.gameObject);
				Debug.Log (itemki[0].nazwa);
				czyWyswietlic = false;
			}
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.tag == "Item")
			czyWyswietlic = false;
	}

	void Klikniecie (string i) {
		//Debug.Log (itemki[int.Parse(i)].nazwa);
		GameObject temp = Instantiate (kostka, transform.position + transform.forward*3, Quaternion.identity);
		temp.GetComponent<ItemRzeczywisty> ().item = itemki[int.Parse (i)];
		itemki.RemoveAt (int.Parse (i));
		przyciski[int.Parse (i)].GetComponent<RawImage> ().texture = null;
		przyciski[int.Parse (i)].GetComponentInChildren<Text> ().text = "";
		przyciski[int.Parse (i)].onClick.RemoveAllListeners ();
	}
	
	private void OnGUI () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		/*for (int i = 0; i < itemki.Count; i++) {
			if (GUI.Button (new Rect (100 + i * 60, 100, 50, 50), itemki[i].ikona)) {
				Debug.Log ("Wybrałeś item: " + itemki[i].nazwa);
			}
		}*/
		if (czyWyswietlic == true)
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 3 * 2, 200, 30), "Aby podniesc item kliknij I");
	}

}

[System.Serializable]
public class Item {

	public string nazwa;
	public Texture2D ikona;

	public Item (string n, Texture2D texture2D) {
		nazwa = n;
		ikona = texture2D;
	}

}