using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float speed = 150.0f;
  public float jumpForce = 12.0f;
  public GameObject projectile;

  private Rigidbody2D body;
  private Animator anim;
  private BoxCollider2D box;

  private Vector2 spawn;

  // Use this for initialization
  void Start() {
    body = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    box = GetComponent<BoxCollider2D>();
    spawn = body.position;
  }

  // Update is called once per frame
  void Update() {
    float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    Vector2 movement = new Vector2(deltaX, body.velocity.y);
    body.velocity = movement;
    anim.SetFloat("speed", Mathf.Abs(deltaX));
    if (!Mathf.Approximately(deltaX, 0)) {
      transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
    }
    Vector3 max = box.bounds.max;
    Vector3 min = box.bounds.min;
    Collider2D hit = Physics2D.OverlapArea(new Vector2(max.x, min.y - .1f), new Vector2(min.x, min.y - .2f));
    bool grounded = false;
    if (hit != null) {
      grounded = true;
    }
    body.gravityScale = grounded && deltaX == 0 ? 0 : 1;
    if (grounded && Input.GetKeyDown(KeyCode.Space)) {
      body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    UpdatePlatform(hit, deltaX);
    HandleCreateProjectile();
  }

  void UpdatePlatform(Collider2D hit, float deltaX) {
    MovingPlatform platform = null;
    if (hit != null) {
      platform = hit.GetComponent<MovingPlatform>();
    }
    if (platform != null) {
      transform.parent = platform.transform;
    } else {
      transform.parent = null;
    }
    anim.SetFloat("speed", Mathf.Abs(deltaX));
    Vector3 pScale = Vector3.one;
    if (platform != null) {
      pScale = platform.transform.localScale;
      if (deltaX != 0) {
        transform.localScale = new Vector3(Mathf.Sign(deltaX) / pScale.x, 1 / pScale.y, 1);
      }
    }
  }

  void HandleCreateProjectile() {
    if (Input.GetKeyDown(KeyCode.Mouse0)) {
      Vector2 position = body.position;
      Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      
      float angle = Vector3.SignedAngle(position, mouse, Vector3.forward);
      Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);
      print(angle);
      Instantiate(projectile, position, quaternion);
    }
  }
}
