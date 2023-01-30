using System;
using UnityEngine;

[Serializable]
public class SpawnerInfo
{
    [SerializeField] private Transform _fromPoint;
    [SerializeField] private Transform _toPoint;
    [SerializeField] private float _minAngle;
    [SerializeField] private float _maxAngle;
    [SerializeField] private int _priority;

    public Transform FromPoint => _fromPoint;
    public Transform ToPoint => _toPoint;
    public float MinAngle => _minAngle;
    public float MaxAngle => _maxAngle;
    public float Priority => _priority;
}
