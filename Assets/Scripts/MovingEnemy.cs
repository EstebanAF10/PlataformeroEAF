using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy //Que herede de enemy y no de MonoBehaviour
{
    public float speed = 5f;
    public float direction = 1f;
    public float directionTimeChange = 3f;
    private Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(DirectionChange());
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
        rigidBody2D.velocity = new Vector2(direction, rigidBody2D.velocity.y);
    }

    IEnumerator DirectionChange()
    {
        while(true){
        yield return new WaitForSeconds(directionTimeChange);
        direction = direction * -1;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
