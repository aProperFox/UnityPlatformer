using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

  public float initialSpeed = 80f;

  Rigidbody2D body;

  // Use this for initialization
  void Start() {
    body = GetComponent<Rigidbody2D>();
    Camera camera = Camera.main;
    body.AddForce(Vector2.MoveTowards(body.position, camera.ScreenToWorldPoint(Input.mousePosition), 1f).normalized * initialSpeed, ForceMode2D.Impulse);
  }

  // Update is called once per frame
  void Update() {
    
  }
}
