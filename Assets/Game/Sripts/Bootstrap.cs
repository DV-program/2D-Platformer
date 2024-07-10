using Assets.Game.Sripts;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[Header("Player")]
	[SerializeField] GameObject _playerPrefab;
	[SerializeField] private int _healthPoint;
	[Header("Camera")]
	[SerializeField] GameObject _cameraPrefab;
	[SerializeField] private Vector3 _offcet = Vector3.zero;
	[SerializeField] private float _smothing = 1f;
	private CameraFollower _cameraFollower;
	private PlayerCreator _playerCreator;

    private void Awake()
	{
		MoveEnemy moveEnemy = _playerPrefab.GetComponent<MoveEnemy>();
		_playerCreator = new(_playerPrefab, _healthPoint, moveEnemy);
		_cameraFollower = new(_playerPrefab.transform, _cameraPrefab.transform, _offcet, _smothing);
	}
	private void OnDisable()
	{
		_cameraFollower.Disable();
	}
}
