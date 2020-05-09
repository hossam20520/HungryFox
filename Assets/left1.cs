using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left1 : MonoBehaviour
{
	
	public Rigidbody2D rb;
		public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
       public void OnButtonPress(){
		       anim.SetBool("running" , true);
			   rb.velocity = new Vector2(-5 , rb.velocity.y);
			   transform.localScale = new Vector2(-1 , 1);
		
		        Debug.Log("Button");
		}
}
