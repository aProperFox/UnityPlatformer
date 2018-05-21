using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D {
  public class Restarter : MonoBehaviour {
    private void OnTriggerExit2D(Collider2D collision) {
      if (collision.tag == "Player") {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
      } else if (collision.tag == "Projectile") {
        Destroy(collision.gameObject);
      }
    }
  }
}
