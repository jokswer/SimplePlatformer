using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public enum Direction
    {
        Left,
        Right
    }

    public class Walker : MonoBehaviour
    {
        [SerializeField] private Transform _leftTarget;
        [SerializeField] private Transform _rightTarget;
        [SerializeField] private float _speed;
        [SerializeField] private float _stopTime;
        [SerializeField] private Direction _currentDirection;
        [SerializeField] private Transform _rayStart;

        private bool _isStopped;

        public UnityEvent EventOnLeftTarget;
        public UnityEvent EventOnRightTarget;

        private void Start()
        {
            _leftTarget.parent = null;
            _rightTarget.parent = null;
        }

        private void Update()
        {
            if (_isStopped) return;
            
            MoveToFloor();
            Move();
            ToggleDirection(StopWalk);
        }

        private void MoveToFloor()
        {
            if (Physics.Raycast(_rayStart.position, Vector3.down, out var hit))
            {
                transform.position = hit.point;
            }
        }

        private void Move()
        {
            var direction = _currentDirection == Direction.Left ? -1 : 1;
            transform.position += direction * new Vector3(Time.deltaTime * _speed, 0, 0);
        }

        private void ToggleDirection(Action onChangeDirection)
        {
            if (transform.position.x < _leftTarget.position.x)
            {
                _currentDirection = Direction.Right;

                onChangeDirection?.Invoke();
                EventOnLeftTarget.Invoke();
            }
            else if (transform.position.x > _rightTarget.position.x)
            {
                _currentDirection = Direction.Left;

                onChangeDirection?.Invoke();
                EventOnRightTarget.Invoke();
            }
        }

        private void StopWalk()
        {
            _isStopped = true;

            StartCoroutine(ContinueWalk());
        }

        private IEnumerator ContinueWalk()
        {
            yield return new WaitForSeconds(_stopTime);
            _isStopped = false;
        }
    }
}