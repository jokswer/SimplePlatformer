using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyVisibleService : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _maxDistance = 20f;
        [SerializeField] private float _checkRate = 0.5f;

        public ToggleEnemyVisible[] _enemies;

        private void Awake()
        {
            _enemies = FindObjectsOfType<ToggleEnemyVisible>(true);
        }

        private void Start()
        {
            StartCoroutine(DistanceCheckRoutine());
        }

        private IEnumerator DistanceCheckRoutine()
        {
            while (true)
            {
                for (var i = 0; i < _enemies.Length; i++)
                {
                    var enemy = _enemies[i];

                    if (enemy)
                    {
                        CheckDistance(enemy);
                    }
                }

                yield return new WaitForSeconds(_checkRate);
            }
        }

        private void CheckDistance(ToggleEnemyVisible enemy)
        {
            var distance = Vector3.Distance(enemy.transform.position, _target.position);

            if (distance < _maxDistance)
            {
                enemy.Show();
            }
            else
            {
                enemy.Hide();
            }
        }
    }
}