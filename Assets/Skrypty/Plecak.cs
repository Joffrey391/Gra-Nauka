using System.Collections.Generic;
using UnityEngine;

public class Plecak : MonoBehaviour {

	public int maksymalnaPojemnosc = 5;
	public List<Item> itemki;

	private void Start () {
		itemki = new List<Item> ();
	}

	private void OnTriggerStay (Collider other) {
		if (other.tag == "Item") {
			if (Input.GetKeyDown("i")) {
				itemki.Add (other.GetComponent<ItemRzeczywisty> ().item);
				Destroy (other.gameObject);
				Debug.Log (itemki[0].nazwa);
			}
		}
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