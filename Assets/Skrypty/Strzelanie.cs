using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzelanie : MonoBehaviour {

	public int ammo, maxAmmo, saveAmmo, maxSaveAmmo;
    //deklarujemy przydatne później zmienne

	RaycastHit hit;
    //generacja promienia który sprawdza czy w coś byśmy trafili
  

	void Update () {

		if (ammo > 0) {
			if (Input.GetButtonDown ("Fire1"))
            // jeśli mamy amunicję i klikniemy przycisk
            {
                if (Physics.Raycast (transform.position, transform.forward, out hit))
                //jeśli w coś trafimy
                {
					if(hit.collider.GetComponent<Rigidbody> () != null)
						hit.collider.GetComponent<Rigidbody> ()?.AddForce (-transform.forward * 15, ForceMode.Impulse);
                    // to dodajemy objektowi komponent z siłą pchającą do przodu czyli jakby odrzut
                    
				}
			}
		}

	}
}
