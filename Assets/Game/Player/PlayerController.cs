using System;
using Ashsvp;
using UnityEngine;
using IInitializable = Zenject.IInitializable;

namespace Game
{
	public sealed class PlayerController : IInitializable
	{
		private readonly RaceStateManager _raceStateManager;
		private readonly GameObject _player;
		private Vector3 _playerInitialPosition;
		private Quaternion _playerInitialRotation;

		public PlayerController(GameObject player, RaceStateManager raceStateManager)
		{
			_player = player;
			_raceStateManager = raceStateManager;
		}

		public void Initialize()
		{
			_playerInitialPosition = _player.transform.position;
			_playerInitialRotation = _player.transform.rotation;
			_raceStateManager.OnStateChanged += OnStateChanged;
		}

		private void OnStateChanged(RaceState state)
		{
			switch (state)
			{
				case RaceState.None:
					break;
				case RaceState.Start:
					Start();
					break;
				case RaceState.Finish:
					Finish();
					break;
				case RaceState.Reset:
					Reset();
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(state), state, null);
			}
		}

		private void Start()
		{
			_player.GetComponent<SimcadeVehicleController>().enabled = true;
			_player.GetComponent<Rigidbody>().isKinematic = false;
		}

		private void Finish()
		{
			_player.GetComponent<SimcadeVehicleController>().enabled = false;
			_player.GetComponent<Rigidbody>().isKinematic = true;
		}

		private void Reset()
		{
			_player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
			_player.GetComponent<Rigidbody>().isKinematic = true;
			_player.GetComponent<SimcadeVehicleController>().enabled = false;
			_player.transform.position = _playerInitialPosition;
			_player.transform.rotation = _playerInitialRotation;
		}
	}
}