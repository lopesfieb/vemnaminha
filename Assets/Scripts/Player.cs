using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour{
    Rigidbody2D rig;
    public int speed = 5;
    bool chao, puloDuplo;
    public int jump = 4;
    void Start(){
        rig = GetComponent<Rigidbody2D>();
    }
    void Update(){
        Mover(); Pulo();
    }
    void Mover(){
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);
    }
    void Pulo(){
        if(Input.GetButtonDown("Jump")){
            if(chao){
                rig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = true;
            }else if(puloDuplo){
                rig.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D colisao){
        if(colisao.gameObject.CompareTag("Plataforma")){
            chao = true; puloDuplo = false;
        }
    }
}
