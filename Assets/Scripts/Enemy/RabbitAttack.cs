using UnityEngine;

namespace Enemy
{
    public class RabbitAttack : MonoBehaviour
    {
        private readonly int Attack = Animator.StringToHash("Attack");
    
        [SerializeField] private float _attackPeriod = 7f;
        [SerializeField] private Animator _animator;
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _attackPeriod)
            {
                _timer = 0;
                _animator.SetTrigger(Attack);
            }
        }
    }
}