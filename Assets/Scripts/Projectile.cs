using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

  public float initialSpeed = 40f;

  Rigidbody2D body;

  // Use this for initialization
  void Start() {
    body = GetComponent<Rigidbody2D>();
    var angle = body.rotation;
    var vel = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
    body.AddForce(vel.normalized * initialSpeed, ForceMode2D.Impulse);
  }

  // Update is called once per frame
  void Update() {
    
  }
}
