using UnityEngine;
using System.Collections;

public class doorScript2 : MonoBehaviour {

    bool isOpen;
    public static int alarmPressed = 0;  //public reference to 

    void OnTriggerEnter(Collider col)
    {
        if (alarmPressed == 1) // Unlocks door, only if 'activating alarm' objective is complete. 
        {
            if (col.gameObject.tag == "Player")
            {
                if (isOpen == true)
                {
                    this.GetComponent<Animator>().SetTrigger("Close");
                    isOpen = false;
                }
                else
                {
                    this.GetComponent<Animator>().SetTrigger("Open");
                    isOpen = true;
                }
            }
        } else // Dispay message to user.
        {
            UI_canvas_text.cText = "The door is locked! Maybe I should check the bridge for ways to open it.";
        }
    }

    void OnTriggerExit(Collider other)
    {
        UI_canvas_text.cText = ""; // Deletes prior displayed message.
    }

}
