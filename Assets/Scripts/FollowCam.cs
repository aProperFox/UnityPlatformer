﻿using UnityEngine;
using UnityEditor;

public class FollowCam : MonoBehaviour {
  public float smoothTime = 0.2f;
  private Vector3 velocity = Vector3.zero;
  public Transform target;

  private void LateUpdate() {
    Vector3 targetPosition = new Vector3(
      target.position.x, target.position.y, transform.position.z);
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
  }
}