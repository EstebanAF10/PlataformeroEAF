using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy //Que herede de enemy y no de MonoBehaviour
{
    public float speed = 2f;
    public float direction = 1f;
    public float directionTimeChange = 3f;
    private Rigidbody2D rigidBody2D;

    private GameObject wallL;
    private GameObject wallR;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        //StartCoroutine(DirectionChange());
        wallR = transform.parent.Find("WallR").gameObject;
        wallL = transform.parent.Find("WallL").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
     public void Hit(){
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(direction * speed, rigidBody2D.velocity.y);
    }

    // IEnumerator DirectionChange() //Funcionalidad de cambiar la direccion del enemigo con el tiempo. 
    // {
    //     while(true)
    //     {
    //     yield return new WaitForSeconds(directionTimeChange);
    //     Turn();
    //     }
    // }

      private new void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider); //base hace referencia a la clase padre que es Enemy. Se ejecuta primero lo que está en el padre y luego el resto del código
        if(collider.gameObject == wallL || collider.gameObject == wallR)
        {
            Turn();
        }
    }

    private void Turn()
    {
        direction = direction * -1;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
