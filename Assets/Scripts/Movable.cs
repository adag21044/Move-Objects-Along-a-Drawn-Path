using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 5f;

    private int currentWaypointIndex = 0;
    private Vector2 lastPosition; // En son pozisyonu saklamak için

    public GameObject GameObject;

    void Start()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer not assigned!");
            return;
        }
    }

    void Update()
    {
        if (currentWaypointIndex < lineRenderer.positionCount)
        {
            Vector2 targetPosition = lineRenderer.GetPosition(currentWaypointIndex);

            // Objeyi hedef noktaya doğru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Eğer obje hedef noktaya ulaştıysa, bir sonraki noktaya geç
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        Debug.Log("ResetPosition called");
        currentWaypointIndex = 0; // currentWaypointIndex'i sıfırla

        // En son pozisyonu kaydet
        lastPosition = transform.position;

        // Objeyi ilk noktaya yerleştir
        transform.position = new Vector2(0, 0);

        // Çizgiyi sıfırla
        lineRenderer.positionCount = 0;

        // En son pozisyona geri dön
        gameObject.transform.position = lastPosition;
    }
}