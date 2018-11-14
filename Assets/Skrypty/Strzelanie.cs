using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzelanie : MonoBehaviour {

	public int ammo, maxAmmo, saveAmmo, maxSaveAmmo;

	RaycastHit hit;

	void Update () {

		if (ammo > 0) {
			if (Input.GetButtonDown ("Fire1")) {
				if (Physics.Raycast (transform.position, transform.forward, out hit)) {
					if(hit.collider.GetComponent<Rigidbody> () != null)
						hit.collider.GetComponent<Rigidbody> ()?.AddForce (-transform.forward * 15, ForceMode.Impulse);
				}
			}
		}

	}
}
