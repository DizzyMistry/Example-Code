using UnityEngine;
using System.Collections;

public class torch : MonoBehaviour {

    public GameObject fps;
    bool pickedUp = false;
    Vector3 coords;
    public AudioClip toggle;

	void Update () {
        coords = fps.transform.position;
        if (pickedUp)
            trigger_switch();
	}

    void OnTriggerEnter(Collider other) // Trigger Event: 'Display UI Text'
    {
        UI_canvas_text.cText = "Press 'E' to pick up the torch";
    }

    void OnTriggerStay(Collider other) // If collected, display message to user.
    {
        if (Input.GetKeyDown(KeyCode.E) && pickedUp == false)
        {
            torch_main();
            pickedUp = true;
            GetComponent<BoxCollider>().enabled = false;
            UI_canvas_text.cText = "You have picked up the torch. To turn on, left click your mouse.";
            StartCoroutine(quickCountdown());
        }
    }

    void OnTriggerExit(Collider other) //Deletes prior UI message upon picking torch.
    {
        UI_canvas_text.cText = "";
    }

    void torch_main() // display torch.
    {
        gameObject.transform.parent = fps.transform;
        transform.position = new Vector3(coords.x, coords.y + 0.1f, coords.z + 0.3f);
        transform.localEulerAngles = new Vector3(90f, 0f, 0f);
            //fps.transform.rotation;
    }

    void trigger_switch() // Torch controls, on and off.
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioSource a = GetComponent<AudioSource>();
            a.clip = toggle;
            a.Play();
            gameObject.GetComponentInChildren<Light>().enabled = !gameObject.GetComponentInChildren<Light>().enabled;
        }
    }

    IEnumerator quickCountdown() 
    {
        yield return new WaitForSeconds(4);
        UI_canvas_text.cText = "";
    }

}