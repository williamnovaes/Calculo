using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragDrop : MonoBehaviour {
    public float speed = 1f;
    public UnityEvent OnClickAfterCount;
    protected Camera cam;
    private Vector2 m_Offset;
    private float m_Zcoord;
    private Rigidbody2D bolaRigidbody;
    private float gravityScale;
    [HideInInspector] public bool prontoContar = false;
        
    void Start() {
        cam = Camera.main;
        bolaRigidbody = GetComponent<Rigidbody2D>();
        gravityScale = bolaRigidbody.gravityScale;
    }

    private void OnMouseDown() {
        if (prontoContar) {
            OnClickAfterCount?.Invoke();
        } else {
            m_Zcoord = cam.WorldToScreenPoint(bolaRigidbody.position).z;
            m_Offset = bolaRigidbody.position - GetMouseWorldPos();
            bolaRigidbody.gravityScale = 0f;
        }
    }

    private Vector2 GetMouseWorldPos() {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = m_Zcoord;
        return cam.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag() {
        if (!prontoContar) {
            bolaRigidbody.velocity = (GetMouseWorldPos() - (Vector2) transform.position) * speed * Time.deltaTime;
        }
    }

    private void OnMouseUp() {
        bolaRigidbody.gravityScale = gravityScale;
    }
}
