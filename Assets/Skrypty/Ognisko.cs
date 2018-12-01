using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Ognisko : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") //sprawdzam czy to co weszło w zderzacz to gracz 
        {
            if(other.GetComponent<Plecak>().itemki.Any(x =>x.nazwa=="Zapałki")) //jeśli zapałki znajdują się w plecaku gracza
            {
                if(Input.GetKeyDown("e")) //jeśli gracz naciście klawisz e
                {
                    GetComponent<Renderer>().material.color = Color.red;
                    //obiekt zmienia kolor na czerwony
                }
        
            }
        }

    }
}
