using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator anim;
    protected Rigidbody2D rb;
    protected  AudioSource death_s;
    // Start is called before the first frame update
     protected virtual void Start()
    {
     anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
      death_s = GetComponent<AudioSource>();
    }
  
    // Update is called once per frame

    
    public void jumpedOn(){
		
		anim.SetTrigger("Death");
		rb.velocity = Vector2.zero;
		death_s.Play();
	}
	
	private void Death(){
		
		Destroy(this.gameObject);
		
	  }

}
