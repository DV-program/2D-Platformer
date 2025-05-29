using UnityEngine;
using Assets.Game.Sripts.Health;
namespace Assets.Game.Sripts.Player
{
	public class PlayerCreator
	{
		private Player _player;
		public PlayerCreator(GameObject playerModel, int healthPoint)
		{
			HealthEnemy health = playerModel.GetComponent<HealthEnemy>();
			health.Initialize(healthPoint);
			MoveEnemy moveEnemy = playerModel.GetComponent<MoveEnemy>();
			moveEnemy.Initialize();
			PlayerAnimationController controller = playerModel.GetComponent<PlayerAnimationController>();
			controller.Initialize();
			_player = new(moveEnemy, controller);	
		}
	}
}
