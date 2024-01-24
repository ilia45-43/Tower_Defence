using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;

    private int curentWaypointIndex;
    private Vector3 CurentPointPosition;
    private Waypoint waypoint;
    private Vector3 _lastPointPosition;
    private SpriteRenderer _spriteRenderer;
    private bool isFree;
    public bool _death = false;

    void Start()
    {
        waypoint = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Waypoint>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lastPointPosition = transform.position;
        CurentPointPosition = waypoint.GetWaypointPosition(curentWaypointIndex);
    }

    void Update()
    {
        if (!_death)
        {
            Move();
            Rotate();

            if (CurrentPointPositionReached())
            {
                UpdateCurrentPointIndex();
            }
        }
    }

    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = waypoint.Points.Length - 1;
        if (curentWaypointIndex < lastWaypointIndex)
        {
            curentWaypointIndex++;
            CurentPointPosition = waypoint.GetWaypointPosition(curentWaypointIndex);
        }
    }

    private bool CurrentPointPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurentPointPosition).magnitude;
        if (distanceToNextPointPosition < 0.1f)
        {
            _lastPointPosition = transform.position;
            return true;
        }
        return false;
    }

    private void Rotate()
    {
        if (CurentPointPosition.x > _lastPointPosition.x)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void Move()
    {
        if (!isFree)
            transform.position = Vector3.MoveTowards(transform.position, CurentPointPosition, MoveSpeed * Time.deltaTime);
    }

    public void StopTime()
    {
        StartCoroutine(StopEnum());
    }

    private IEnumerator StopEnum()
    {
        yield return new WaitForSeconds(10);
        StopCoroutine(StopEnum());
    }
}
