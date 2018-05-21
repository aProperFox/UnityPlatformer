using UnityEngine;
using System.Collections;

public class PacingFoe : MonoBehaviour {

  public float waitTime = 3f;
  public float walkSpeed = 10f;

  private Rigidbody2D body;
  private BoxCollider2D box;
  private Animator anim;

  private int direction = -1;
  private bool isWalking;

  // Use this for initialization
  void Start() {
    body = GetComponent<Rigidbody2D>();
    box = GetComponent<BoxCollider2D>();
    anim = GetComponent<Animator>();
    isWalking = true;
  }

  // Update is called once per frame
  void Update() {
    float deltaX = direction * walkSpeed * Time.deltaTime;
    Vector2 movement = new Vector2(deltaX, body.velocity.y);
    body.velocity = movement;
    anim.SetFloat("speed", Mathf.Abs(deltaX));
    if (isWalking) {
      transform.localScale = new Vector3(direction, 1f, 1f);
      float x = (direction > 0 ? box.bounds.max.x : box.bounds.min.x) + (direction * box.bounds.size.x / 2);
      Vector3 min = box.bounds.min;
      Collider2D hit = Physics2D.OverlapArea(new Vector2(x, min.y - .1f), new Vector2(x, min.y - .5f));
      if (hit == null) {
        StartCoroutine(HandleReverse());
      }
    }
  }

  IEnumerator HandleReverse() {
    isWalking = false;
    int newDir = direction * -1;
    direction = 0;
    yield return new WaitForSeconds(waitTime);
    direction = newDir;
    isWalking = true;
  }
}
