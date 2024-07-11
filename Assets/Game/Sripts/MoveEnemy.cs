using Assets.Game.Sripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Game.Sripts
{
    public class MoveEnemy : MonoBehaviour, IMovablePlayer
    {
		[SerializeField] private float _jumpVelocity = 25f;
		[SerializeField] private float _speedWalk = 10f;
		private Rigidbody2D _rbEnemy;
		private Transform _enemyTransform;
		private bool _isGrounded = true;
		private int _isLeft = 0;
		public void OnMove(Vector2 inputDirection) 
		{
			_rbEnemy.velocity = new Vector2(inputDirection.x * _speedWalk, _rbEnemy.velocity.y);
			if (Math.Abs(inputDirection.x) > 0) 
				_isLeft = inputDirection.x < 0 ? 1 : 0;
			_enemyTransform.rotation = Quaternion.Euler(0, 180 * _isLeft ,0);
			if (_isGrounded && inputDirection.y == 1) 
				_rbEnemy.velocity = new Vector2(_rbEnemy.velocity.x, _jumpVelocity); 
		}
		public void Initialize()
		{
			_enemyTransform = GetComponent<Transform>();
			_rbEnemy = GetComponent<Rigidbody2D>();
            EventBus.Instance.ButtonsRegistred += OnMove;
        }
		public void Enable()
		{
			EventBus.Instance.ButtonsRegistred += OnMove;
		}
		public void Disable()
		{
			EventBus.Instance.ButtonsRegistred -= OnMove;
			_rbEnemy.velocity = Vector2.zero;
		}
		void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Ground"))
				_isGrounded = true;
		}

		void OnCollisionExit2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Ground"))
				_isGrounded = false;
		}
	}
}
