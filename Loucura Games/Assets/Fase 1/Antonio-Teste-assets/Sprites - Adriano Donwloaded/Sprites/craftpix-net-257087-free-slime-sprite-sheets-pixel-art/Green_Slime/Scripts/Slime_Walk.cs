using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Slime_Walk : MonoBehaviour {
    private Animator SlimeAnim;
   private Rigidbody2D rb;
   public float speed = 2f;
   public Transform player;
   bool isFaceRight = true;
   SpriteRenderer sr;
   public float minDistanceXToTurn = 0.5f;
   public float minDistanceYToTurn = 0.5f;
   public float distanceToStop = 1.5f;

   void Awake(){
      rb = GetComponent<Rigidbody2D> ();
      sr = GetComponent<SpriteRenderer> ();
        SlimeAnim = GetComponent<Animator>();
   }

   void Update(){
        player = GameObject.Find("Player").transform;
      float right = 0;
      float up = 0;
      float distanceX = Vector2.Distance (new Vector2(player.transform.position.x,0),new Vector2(transform.position.x,0));
      float distanceY = Vector2.Distance (new Vector2(0,player.transform.position.y),new Vector2(0,transform.position.y));
      float distanceXY = distanceX + distanceY;

      if (distanceXY <= distanceToStop) {
         // FAZER ALGO QUANDO ESTIVER PERTO
         rb.velocity = Vector2.zero;
         SlimeAnim.SetBool("isWalking", false);
         SlimeAnim.SetBool("attack", true);
         
      } 
      else
      { 
            SlimeAnim.SetBool("isWalking", true);
            SlimeAnim.SetBool("attack", false);

         if (distanceX > minDistanceXToTurn) {
            if (player.position.x > transform.position.x)
               right = 1f;
            else
               right = -1;
         
            if (isFaceRight && right == -1f || !isFaceRight && right == 1f)
               Flip ();
         }

         if (distanceY > minDistanceYToTurn) {
            if (player.position.y > transform.position.y)
               up = 1f;
            else
               up = -1;
         }
         
         rb.velocity = new Vector2 (right, up) * speed * Time.deltaTime;
      }
   }

   void Flip(){
      sr.flipX = !sr.flipX;
      isFaceRight = !isFaceRight;
   }
}