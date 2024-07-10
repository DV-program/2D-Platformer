using UnityEngine;
using Assets.Game.Sripts.Interfaces;
public class PlayerIdle : IPlayerBehavior
{
	private IMovablePlayer _move;
	public PlayerIdle(IMovablePlayer move)
	{
		_move = move;
	}

	public void Enter()
	{
		_move.Disable();
	}
}