﻿using System;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Sripts
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _playerAnimator;
        private Rigidbody2D _playerRigidbody;
        public event Action StayChangedToActive;
        public event Action StayChangedToIdle;
        public event Action Disabled;
        public void OnEnable()
        {
            _playerAnimator = GetComponent<Animator>();
            _playerRigidbody = GetComponent<Rigidbody2D>();
            EventBus.Instance.Damaged += OnHit;
            EventBus.Instance.PlayerDied += OnDie;
            EventBus.Instance.ButtonsRegistred += OnRunning;
            EventBus.Instance.Update += OnJump;
            EventBus.Instance.PlayerEntering += OnEnterDoor;
        }
        private void OnDisable()
        {
            EventBus.Instance.Damaged -= OnHit;
            EventBus.Instance.PlayerDied -= OnDie;
            EventBus.Instance.ButtonsRegistred -= OnRunning;
            EventBus.Instance.Update -= OnJump;
            EventBus.Instance.PlayerEntering -= OnEnterDoor;
        }
        public void OnRunning(Vector2 inputDirection)
        {
            bool isMoving = Math.Abs(inputDirection.x) > 0;
            _playerAnimator.SetBool("IsRunning", isMoving);
        }
        public void OnHit() => StartCoroutine(HitCoroutine());

        private IEnumerator HitCoroutine()
        {
            _playerAnimator.SetBool("IsHit", true);
            yield return new WaitForSeconds(2f);
            _playerAnimator.SetBool("IsHit", false);
        }
        private void OnDie()
        {
            _playerAnimator.SetBool("IsDead", true);
            StayChangedToIdle();
        }
        private void OnJump()
        {
            _playerAnimator.SetFloat("VerticalVelocity", _playerRigidbody.velocity.y);
        }
        private void OnEnterDoor()  
        {
            _playerAnimator.SetTrigger("IsEnterDoor");
            StayChangedToIdle?.Invoke();
        }
        private void OnOutDoor() => StayChangedToActive?.Invoke();
        public void LevelRestarted() => EventBus.Instance.LevelRestarting?.Invoke();
    }
}