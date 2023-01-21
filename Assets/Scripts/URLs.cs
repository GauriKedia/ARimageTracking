using UnityEngine;

public class URLs : MonoBehaviour
{
    public string Url;
   private Example ParentController;

void Start()
{

    ParentController = GetComponentInParent<Example>();
}
public void Open()
{
    Application.OpenURL(Url);
    Debug.Log("working");
    //ParentController.InteractedWith = true;
    }

 public void doExitGame() {
     Application.Quit();
     Debug.Log("leaving");
 }

}