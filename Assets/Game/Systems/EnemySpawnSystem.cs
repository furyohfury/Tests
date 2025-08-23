using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
	public sealed class EnemySpawnSystem : MonoBehaviour
	{
		[SerializeField]
		private Transform[] _spawnPoints;
		[SerializeField]
		private GameObject _enemyPrefab;
		[SerializeField]
		private float _initialInterval = 1f;
		private float _interval;
		private float _time;

		private void Awake()
		{
			_interval = _initialInterval;
			StartCoroutine(IncreaseIntervalCoroutine());
		}

		private void Update()
		{
			if (_time <= 0)
			{
				SpawnEnemy();
				_time = _interval;
			}

			_time -= Time.deltaTime;
		}

		private void SpawnEnemy()
		{
			var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
			Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
		}

		private IEnumerator IncreaseIntervalCoroutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(1);
				_interval = Mathf.Max(0.5f, _interval - 0.1f);
			}
		}
	}
}