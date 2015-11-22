using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    Transform transform;
    Rigidbody2D rigidbody;
    int speed = 100;
    bool isGrounded = true;
    bool hasBall;
    GameObject ball;
    int force = 100;

	// Use this for initialization
	void Start () {
        transform = this.GetComponent<Transform>();
        rigidbody = this.GetComponent<Rigidbody2D>();
        hasBall = false;    
    }
	
	// Update is called once per frame
	void Update () {
        
        float x = transform.position.x ;

        if (Input.GetMouseButtonDown(0))
        {
            var distance = 4.5f;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var point = ray.origin + (ray.direction * distance);

            if (isGrounded)
            { 
                if (this.transform.position.x < point.x)
                    this.rigidbody.AddForce(new Vector2(1 * speed, 0));
                else
                    this.rigidbody.AddForce(new Vector2(-1 * speed, 0));

                if (this.transform.position.y < point.y)
                {
                    this.rigidbody.AddForce(new Vector2(0, 1 * speed));
                    isGrounded = false;
                }
            }
            else
            {
                if (hasBall)
                {
                    Vector3 ballPos = this.transform.position + new Vector3(0, 5, 0);
                    this.ball.transform.position = ballPos;
                    this.ball.SetActive(true);
                    this.ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * force, 1 * force));
                    hasBall = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
            isGrounded = true;

        if (collision.gameObject.name == "ball")
        {
            if (!hasBall)
            {
                this.ball = collision.gameObject;
                this.ball.SetActive(false);
                hasBall = true;

            }
        }            

        Debug.Log("Collision enter");
    }
}
