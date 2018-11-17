using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plecak : MonoBehaviour {

	//Stała określająca
	public const int maksymalnaPojemnosc = 5;
	public List<Item> itemki;
	public Button[] przyciski = new Button[maksymalnaPojemnosc];
	public GameObject kostka;
	bool czyWyswietlic = false;

	private void Start () {
		itemki = new List<Item> ();
	}
    //tworzymy listę zawierającą imetki
	private void OnTriggerStay (Collider other)
    // jeśli w coś wejdziemy, czyli nasze collidery się stykają
    {
		if (other.tag == "Item") {
			czyWyswietlic = true;
			if (Input.GetKeyDown("i"))
            // jeśli klikniemy i
            {
				itemki.Add (other.GetComponent<ItemRzeczywisty> ().item);
				przyciski[itemki.Count - 1].GetComponent<RawImage> ().texture = itemki[itemki.Count - 1].ikona;
				przyciski[itemki.Count - 1].GetComponentInChildren<Text> ().text = itemki[itemki.Count - 1].nazwa;
                // wczytujemy obrazek i nazwę danego itemka
				int a = itemki.Count-1;
				przyciski[itemki.Count - 1].onClick.AddListener (delegate { Klikniecie (a.ToString()); });
                //w przypadku kliknięcia odsyłamy do fukcji kliknięcie, która jest opisana poniżej
				Destroy (other.gameObject);
				Debug.Log (itemki[0].nazwa);
				czyWyswietlic = false;
                // usuwamy objekt ze świata i napis z naszego UI
			}
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.tag == "Item")
			czyWyswietlic = false;
        //opis tego, że gdy odejdziemy od itemka, informacje o nim nie będą się wyświetlać
	}

	void Klikniecie (string i) {
		//Debug.Log (itemki[int.Parse(i)].nazwa);
		GameObject temp = Instantiate (kostka, transform.position + transform.forward*3, Quaternion.identity);
        // postawienie objektu w świecie gry
		temp.GetComponent<ItemRzeczywisty> ().item = itemki[int.Parse (i)];
		itemki.RemoveAt (int.Parse (i));
        // usunięcie go z plecaka
		przyciski[int.Parse (i)].GetComponent<RawImage> ().texture = null;
		przyciski[int.Parse (i)].GetComponentInChildren<Text> ().text = "";
		przyciski[int.Parse (i)].onClick.RemoveAllListeners ();
        // usunięcie jego własności z plecaka
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
        //opis funkcji która wyświetli nam napis gdy staniemy obok itemka
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