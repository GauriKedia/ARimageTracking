using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject gameObject;
    bool active = false;

    public void OpenClose(){
        if (active == false)
        {
            gameObject.transform.gameObject.SetActive(true);
            active = true;

        }
        else{
            gameObject.transform.gameObject.SetActive(false);
            active = false;
        }
    }
}
