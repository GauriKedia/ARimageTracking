// To use this example, attach this script to an empty GameObject.
// Create three buttons (Create>UI>Button). Next, select your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button, Your Second Button
// and Your Third Button fields in the Inspector.
// Click each Button in Play Mode to output their message to the console.
// Note that click means press down and then release.

using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button m_YourFirstButton, m_YourSecondButton, m_YourThirdButton;
    public int counter = 0;
    public GameObject Seen;
    public bool InteractedWith = false;

    
    
    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        // m_YourFirstButton.onClick.AddListener(TaskOnClick);
        // m_YourSecondButton.onClick.AddListener(delegate {TaskWithParameters("Hello"); });
        // m_YourThirdButton.onClick.AddListener(() => ButtonClicked(42));
        //m_YourThirdButton.onClick.AddListener(TaskOnClick);

        m_YourFirstButton.onClick.AddListener(TaskOnClick);
         m_YourSecondButton.onClick.AddListener(TaskOnClick);
          m_YourThirdButton.onClick.AddListener(TaskOnClick);
        Debug.Log(ImageCounter.MasterCounter);
        
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        counter++;
        InteractedWith = true;
    }

    // void TaskWithParameters(string message)
    // {
    //     //Output this to console when the Button2 is clicked
    //     Debug.Log(message);
    //     counter++;
    // }

    // void ButtonClicked(int buttonNo)
    // {
    //     //Output this to console when the Button3 is clicked
    //     Debug.Log("Button clicked = " + buttonNo);
    //     counter++;
    // }

   public void Update() 
 {
     
           Seen.SetActive (InteractedWith);
           Debug.Log("seen");
       
 }

//  public void Counter() {
// if (counter == 1){
//         Debug.Log("one");
//         ImageCounter.MasterCounter+= 1;
//         Debug.Log (ImageCounter.MasterCounter);
//        }

//  }
}
