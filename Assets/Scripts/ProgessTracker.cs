using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]
public class ProgessTracker : MonoBehaviour
{
    public int max;
    public int current;
    public Image mask;
    public GameObject finished;

     private void Awake(){

       
    }

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        FinishedEverything();

    }

    void GetCurrentFill(){
        float fillAmount = (float)current/(float)max;
        mask.fillAmount = fillAmount;

    }

    void FinishedEverything(){
        if(current == max){
            finished.SetActive(true);
        }
    }
}
