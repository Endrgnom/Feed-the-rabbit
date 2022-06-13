using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
   
  public void Select () {
    Debug.LogFormat("Hello!");
  }
   
  public void Deselect () {
     Debug.LogFormat("Buy!");
  }
}
