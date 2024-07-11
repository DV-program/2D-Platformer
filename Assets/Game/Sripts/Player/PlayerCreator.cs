using Assets.Game.Interfaces;
using Assets.Game.Sripts.Interfaces;
using UnityEngine;
namespace Assets.Game.Sripts
{
	public class PlayerCreator
	{
		private Player _player;
		public PlayerCreator(GameObject playerModel, int healthPoint)
		{
			Health health = playerModel.GetComponent<Health>();
			health.Initialize(healthPoint);
			MoveEnemy moveEnemy = playerModel.GetComponent<MoveEnemy>();
			PlayerAnimationController controller = playerModel.GetComponent<PlayerAnimationController>();
			_player = new(moveEnemy, controller);	
		}
	}
}
