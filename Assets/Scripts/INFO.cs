using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class INFO : MonoBehaviour
{
    public Text text;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform.gameObject.tag == "mouseHoverInfo" || hit.transform.gameObject.tag == "flipper")
            {
                text.text = hit.transform.name;
            }
            else {
                text.text = "";
            }


        }
    }
}
