using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System.Net.Mail;

public class SendEmail : MonoBehaviour
{
 
 public void Open()
 {
 Application.OpenURL("mailto:answers@gurudevonline.com");
 }
}