using System.Collections;
using UnityEngine;

public class Strzelanie : MonoBehaviour {

	public int ammo, maxAmmo, saveAmmo, maxSaveAmmo;
	public float damage;
	public float coolTime, reloadTime;
	private bool czyMogeStrzelac = true, czyPrzeladowujemy = false;
	//deklarujemy przydatne później zmienne
	public AudioSource audioSource;
	RaycastHit hit;
    //generacja promienia który sprawdza czy w coś byśmy trafili
  

	void Update () {

		if (ammo > 0) {
			if (Input.GetButton ("Fire1") && czyMogeStrzelac)
			// jeśli mamy amunicję i mamy przyciśnięty przycisk
			{
				if (Physics.Raycast (transform.position, transform.forward, out hit))
				//jeśli w coś trafimy
				{
					if (hit.collider.GetComponent<Wrog> () != null)
						hit.collider.GetComponent<Wrog> ().Obrazenia (damage);
					// Dla komponentu Wrog zabieramy zycie
				}
				ammo--;
				czyMogeStrzelac = false;
				StartCoroutine ("Czekaj");
				audioSource.Play ();
			}
		} else if(czyPrzeladowujemy == false) StartCoroutine ("Przeladuj");

		if (Input.GetKeyDown ("r") && czyPrzeladowujemy == false)
			StartCoroutine ("Przeladuj");

	}

	private void OnGUI () {
		GUI.Box (new Rect (Screen.width - 200, Screen.height - 50, 100, 30), string.Format ("{0}/{1} | {2}", ammo, maxAmmo, saveAmmo));
	}

	IEnumerator Czekaj () {
		yield return new WaitForSeconds (coolTime);
		czyMogeStrzelac = true;
		StopCoroutine ("Czekaj");
	}

	IEnumerator Przeladuj () {
		czyMogeStrzelac = false;
		if (saveAmmo > 0) {
			czyPrzeladowujemy = true;
			yield return new WaitForSeconds (reloadTime);
			ammo = maxAmmo;
			saveAmmo--;
			czyMogeStrzelac = true;
			czyPrzeladowujemy = false;
		}
		StopCoroutine ("Przeladuj");
	}

}
