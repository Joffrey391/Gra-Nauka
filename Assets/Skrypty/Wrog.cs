using UnityEngine;

public class Wrog : MonoBehaviour {

	[SerializeField] private float hp;

	public void Obrazenia (float obrazenia) {
		hp -= obrazenia;
		if (hp <= 0)
			Destroy (gameObject);
	}

}