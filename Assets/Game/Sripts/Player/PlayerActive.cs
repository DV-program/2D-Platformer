using UnityEngine;
using Assets.Game.Sripts.Interfaces;
public class PlayerActive : IPlayerBehavior
{
	private IMovablePlayer _move;
	public PlayerActive(IMovablePlayer move)
	{
		_move = move;
	}
	public void Enter()
	{
		_move?.Enable();
	}
}	