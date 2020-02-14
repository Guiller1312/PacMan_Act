using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class IsLive : MonoBehaviour {
    public bool live = true;
 
    void onDestroy(){
        live = false;
    }
 
}