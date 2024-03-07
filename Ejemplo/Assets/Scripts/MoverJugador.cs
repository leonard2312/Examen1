using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{
	private float movX, movY;
	public float velocidadMovimiento = 600,fuerzaSalto = 100,VEC;
    public Boolean TeclaSalto;
    public Boolean tocar;
    public int band=0;
    //public float fps;
	public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

        VEC = movX*movX+movY*movY;

        //Debug.Log("movx: "+movX+"movy: "+movY);
        //Debug.Log(band);
            
        //fps = 1/Time.deltaTime;

        if(Input.GetButton("Jump")){
            TeclaSalto = true;
        }
        else{
            TeclaSalto = false;
        }

        if(Input.GetButton("Horizontal") && Input.GetButton("Vertical")){
            //Debug.Log("dia" + VEC);
            if(movX<0){
                movX = -0.7071068f;
            }
            else{
                movX = 0.7071068f;
            }

            if(movY<0){
                movY = -0.7071068f;
            }
            else{
                movY = 0.7071068f;
            }
        }

        //Debug.Log("upt: "+Time.deltaTime);
    }

    
    void FixedUpdate(){
        if(TeclaSalto && (band < 2)){
            band += 1;
            Debug.Log(band);
            rb.AddForce(new Vector3(0,fuerzaSalto * Time.fixedDeltaTime,0),ForceMode.Impulse);
        }
        rb.velocity = new Vector3(movX * velocidadMovimiento * Time.fixedDeltaTime, rb.velocity.y, 
        movY * velocidadMovimiento * Time.fixedDeltaTime);
        VEC = movX*movX+movY*movY;
        Debug.Log("dia" + VEC);
        //Debug.Log("---Fixed: "+Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.transform.CompareTag("Piso")){
            band = 0;
            tocar = true;
        }
    }

    void OnCollisionExit(Collision collision){
        if(collision.transform.CompareTag("Piso")){
            tocar = false;
        }
    }
}

