using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;

    public Vector3[] Points => points;
    public Vector3 CurrentPosition => _curentPosition;

    private Vector3 _curentPosition;
    private bool _gameStarted;

    private void Start()
    {
        _gameStarted = true;
        _curentPosition = transform.position;
    }

    public Vector3 GetWaypointPosition(int index)
    {
        return CurrentPosition + Points[index];
    }

    private void OnDrawGizmos()
    {
        if (_gameStarted && transform.hasChanged)
            _curentPosition = transform.position;


        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(points[i] + _curentPosition, 0.5f);

            if (i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + _curentPosition, points[i + 1] + _curentPosition);
            }
        }
    }
}
