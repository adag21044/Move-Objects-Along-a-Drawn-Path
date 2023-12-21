using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 previousPosition;
    private Vector3 startPosition = Vector3.zero; // Yeni eklenen satır
    
    [SerializeField] private float minDistance = 0.1f;

    

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;

        if (Input.GetMouseButtonDown(0)) // MouseButtonUp ile değiştirildi
        {
            // Fare tuşuna basıldığında başlangıç pozisyonunu al
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition.z = 0;

            // Çizgi çizmeye başlamadan önce başlangıç pozisyonunu kaydet
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, startPosition);

            previousPosition = startPosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0;

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
                previousPosition = currentPosition;
            }
        }
    }

    
    
}