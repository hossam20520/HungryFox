﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityHelper : MonoBehaviour
{
    // Start is called before the first frame update
 
   private void OnTriggerEnter2D(Collider2D coll){
	   
	   if(coll.gameObject.tag == "Player"){
		   
		   
	   coll.gameObject.GetComponent<PlayerController>().enabled = false;
   }
   }
 
 
}
