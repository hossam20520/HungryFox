using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
	
	public Rigidbody2D rb;
	public Animator anim;
	private Collider2D coli; 
	
	[SerializeField] private float speed = 5f;
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private LayerMask ground;
	[SerializeField] private TextMeshProUGUI cheryText;
	[SerializeField] private float hurtForce = 10f;
	[SerializeField] private AudioSource footstep;
	[SerializeField] private AudioSource coinCollect;
	private bool moveLeft = false;
	private bool moveRight = false;
	 public int cherries = 0;
	
	private enum State { idle , running , jumping , falling , hurt}
	private State state = State.idle;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
          anim = GetComponent<Animator>();
          coli = GetComponent<Collider2D>();
         
    }

    // Update is called once per frame
    void Update()
    {
		
		rightTouch();
		leftTouch();
     
		 if(state !=  State.hurt )
		   {
				 InputManager();
		    }
			
			AnimationState();
			anim.SetInteger("state", (int)state);
			//Debug.Log((int)state);
    }
    
    
    
    private  void footStep(){
	footstep.Play();	
		
	}
	
	public void JumpButton(){
		if(coli.IsTouchingLayers(ground)){
			Jump();
			
		}
		
	}
	

	
	
	
	
	public void leftTouch(){
		
		if(moveLeft){
			
		 if(state !=  State.hurt )
		   {
				 rb.velocity = new Vector2(-speed , rb.velocity.y);
			     transform.localScale = new Vector2(-1 , 1);
			
		    }
			  
		}
		
		
	}
	
	
	public void  onKeyUpLeftButton(){
		
		moveLeft = false;
		
	}
	
	
		
	public  void onKeyDownLeftButton(){
		
		moveLeft = true;
		
	}
	
	
	
	
		
	public void rightTouch(){
		
		if(moveRight){
			
		 if(state !=  State.hurt )
		   {
				 rb.velocity = new Vector2(speed , rb.velocity.y);
			     transform.localScale = new Vector2(1 , 1);
		    }
			  
		}
		
		
	}
	
		public void  onKeyUpRightButton(){
		
		 moveRight = false;
		
	}
	
		public void  onKeyDownRightButton(){
		
		moveRight = true;
		
	}

    
    
    private void AnimationState(){
		
	if(state  == State.jumping){
		//Debug.Log("yes");
		
			if(rb.velocity.y < .1f){
				state = State.falling;
				
				
			}
			
			
		} else if(state == State.falling){
			if(coli.IsTouchingLayers(ground)){
				state = State.idle;
				
				}
			
			
			}else if(state == State.hurt){
				if(Mathf.Abs(rb.velocity.x) < .1f)
				{
					state = State.idle;
				}
				
				
				}else if(Mathf.Abs(rb.velocity.x) > 2f){
			//moving  //Mathf.Abs(rb.velocity.x) > 2f
			state = State.running;
			
			
			}else{
				
			state = State.idle;
				
			}
		
		
		
		
		}
		
		
		
		private void InputManager(){
			
			
				float hDir = Input.GetAxis("Horizontal");
         //  if(Input.GetKey(KeyCode.A)){
          if(hDir  < 0 ){
			     // anim.SetBool("running" , true);
			    //  state = State.running;
			   rb.velocity = new Vector2(-speed , rb.velocity.y);
			   transform.localScale = new Vector2(-1 , 1);
			  
			   //}else if(Input.GetKey(KeyCode.D)){
			}else if(hDir  > 0){
				 // anim.SetBool("running" , true);
			    //state = State.running;
			     rb.velocity = new Vector2(speed , rb.velocity.y);
			     transform.localScale = new Vector2(1 , 1);
			     
			}
			
			      //else{
				 //anim.SetBool("running" , false);
				//state = State.idle;
			   //}
			
		//  if(Input.GetKey(KeyCode.Space)){
			//    rb.velocity = new Vector2(rb.velocity.x , 10f);
			   
		//	}
		
		  if(Input.GetButtonDown("Jump") && coli.IsTouchingLayers(ground)){
			  
			   Jump();
		
			}
			
			}
			
			private void Jump(){
				 rb.velocity = new Vector2(rb.velocity.x , jumpForce);
			    state = State.jumping;
			}
			
		        	private void OnTriggerEnter2D(Collider2D collison){
				             if(collison.tag  == "Collectable")
				             {
								 coinCollect.Play();
								   Destroy(collison.gameObject);
								   cherries += 1; 
								   cheryText.text = cherries.ToString();
							 }
				
				}
				
				
				private void OnCollisionEnter2D(Collision2D others){
					
					if(others.gameObject.tag == "Enemy")
					    {
							Enemy f = others.gameObject.GetComponent<Enemy>();
							if(state == State.falling)
							{
								  //Destroy(others.gameObject);
								  f.jumpedOn();
								  
								  
								  Jump();
							}else{
								
								state = State.hurt;
								if(others.gameObject.transform.position.x > transform.position.x)
								{
									 rb.velocity = new Vector2(-hurtForce , rb.velocity.y);
								}else
								{
								 rb.velocity = new Vector2(hurtForce , rb.velocity.y);	
								}
								
							}
							
							
						
						}
					
					}
		
		
}
