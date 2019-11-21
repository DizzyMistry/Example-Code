using UnityEngine;
using System.Collections;

public class bridgeComputer : MonoBehaviour {

    public AudioSource source;
    public AudioClip clip;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>(); 
    }

    void OnTriggerEnter(Collider other) // display Ui message.
    {
        UI_canvas_text.cText = "Press E to open doors down the path ahead";
    }

    void OnTriggerStay(Collider other) 
    {
        if(Input.GetKeyDown(KeyCode.E)) // user input to activate
        {
            doorScript2.alarmPressed = 1;
            UI_canvas_text.cText = "Doors activated. Alarm Activated."; // unlocks door, plays alarm.
            source.Play();
            for (int i = 1; i <= 30; i += 1)
            {
                Debug.Log("test");
                GameObject.FindGameObjectWithTag("light").GetComponent<Light>().color = Color.red;
                GameObject.FindGameObjectWithTag("light").tag = "Untagged";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        UI_canvas_text.cText = "";
    }
}
