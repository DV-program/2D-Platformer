using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Game.Sripts.Interfaces;
using Assets.Game.Sripts;
using Assets.Game.Interfaces;
public class Player 
{
	private IMovablePlayer _move;
	private PlayerAnimationController _controller;
	private Dictionary<Type,IPlayerBehavior> _behavioursMap = new();
	private IPlayerBehavior _currentBehavior;
	public Player(IMovablePlayer move, PlayerAnimationController controller)
	{
		_move = move;
		_controller = controller;
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
    }
}