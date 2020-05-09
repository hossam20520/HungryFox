using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : Enemy
{
	
	public float leftCap;
	 public float rightCap;
	
	 [SerializeField] private float jumpLen = 10f;
	 [SerializeField] private float jumpheigt = 15f;
	 [SerializeField] private LayerMask ground;
	  private bool facingLeft = true;
	  private Collider2D coli;
	
	  	public Rigidbody2D rb;
	 
    // Start is called before the first frame update
   protected override void Start()
    {

		base.Start();
		 rb = GetComponent<Rigidbody2D>();
         coli = GetComponent<Collider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
		
		if(anim.GetBool("jumping")){
			if(rb.velocity.y < .1){
				
				anim.SetBool("falling", true);
				anim.SetBool("jumping" , false);
			}
			
			}
			
			
			if(coli.IsTouchingLayers(ground) && anim.GetBool("falling")){
				anim.SetBool("falling", false);
				
				
				}
    
    }
    

    
    
    
    void move(){
		
		
		   if(facingLeft)
        {
			if(transform.position.x > leftCap){
				   if(transform.localScale.x != 1){
					   transform.localScale = new Vector3(1,1);
					   }
				   
				   if(coli.IsTouchingLayers(ground)){
					   rb.velocity = new Vector2(-jumpLen , jumpheigt);
					      anim.SetBool("jumping", true);
					   }
				   
				}else{
					facingLeft = false;
					}
			
		}else{
			
			
					if(transform.position.x < rightCap){
				   if(transform.localScale.x != -1){
					   transform.localScale = new Vector3(-1,1);
					   }
				   
				   if(coli.IsTouchingLayers(ground)){
					   rb.velocity = new Vector2(jumpLen , jumpheigt);
					    anim.SetBool("jumping", true);
					   
					   }
				   
				}else{
					facingLeft = true;
					}
					
			
			}
		
		}
}
