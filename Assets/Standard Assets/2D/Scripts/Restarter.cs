using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D {
  public class Restarter : MonoBehaviour {
    private static String[] destroyables = { "Projectile", "NPC" };

    private void OnTriggerEnter2D(Collider2D collision) {
      if (collision.tag == "Player") {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
      } else if (Array.IndexOf(destroyables, collision.tag) > -1) {
        Destroy(collision.gameObject);
      }
    }
  }
}
