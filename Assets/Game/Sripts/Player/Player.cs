using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Game.Sripts.Interfaces;
using Assets.Game.Sripts.Player;
using Assets.Game.Interfaces;
namespace Assets.Game.Sripts.Player
{
	public class Player
	{
		private IMovablePlayer _move;
		private PlayerAnimationController _controller;
		private Dictionary<Type, IPlayerBehavior> _behavioursMap;
		private IPlayerBehavior _currentBehavior;
		public Player(IMovablePlayer move, PlayerAnimationController controller)
		{
			_move = move;
			_controller = controller;
			_behavioursMap = new();
			_controller.StayChangedToIdle += SetPlayerIdle;
			_controller.StayChangedToActive += SetPlayerActive;
			_controller.Disabled += Disable;
			InitializeBehavior();
		}
		private void InitializeBehavior()
		{
			this._behavioursMap[typeof(PlayerActive)] = new PlayerActive(_move);
			this._behavioursMap[typeof(PlayerIdle)] = new PlayerIdle(_move);
			SetBehavior(this._behavioursMap[typeof(PlayerIdle)]);
		}
		private void SetBehavior(IPlayerBehavior behaviour)
		{
			this._currentBehavior = behaviour;
			this._currentBehavior.Enter();
		}
		public void SetPlayerActive() => SetBehavior(_behavioursMap[typeof(PlayerActive)]);
		public void SetPlayerIdle() => SetBehavior(_behavioursMap[typeof(PlayerIdle)]);
		private void Disable()
		{
			_controller.StayChangedToIdle -= SetPlayerIdle;
			_controller.StayChangedToActive -= SetPlayerActive;
			_controller.Disabled -= Disable;
		}
	}
}