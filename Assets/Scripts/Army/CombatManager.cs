namespace AFSInterview.Army
{
	using UnityEngine;
	using System.Collections.Generic;
	using System;
	
	public class CombatManager : MonoBehaviour
	{
		[SerializeField] private ArmyController army1;
		[SerializeField] private ArmyController army2;
		
		private CombatTimeline timeline = new ();

		public CombatTimeline Timeline => timeline;

		public event Action onNext;
		public event Action onEnd;
		
		private void Awake()
		{
			army1.Init(this);
			army2.Init(this);

			List<Unit> allUnits = new ();
			allUnits.AddRange(army1.Units);
			allUnits.AddRange(army2.Units);
			// Pseudo random unit order
			allUnits.Sort((x, y) => x.GetInstanceID().CompareTo(y.GetInstanceID()));

			foreach (var unit in allUnits)
			{
				timeline.AddNewUnit(unit);
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				NextTurn();
			}
		}

		public Unit GetRandomUnitFromOtherArmy(ArmyController army)
		{
			ArmyController enemyArmy = army == army1 ? army2 : army1;

			int randomEnemyIndex = UnityEngine.Random.Range(0, enemyArmy.Units.Count);
			return enemyArmy.Units[randomEnemyIndex];
		}

		public void EndCombat(ArmyController losingArmy)
		{
			Debug.Log("The End");
			onEnd?.Invoke();
			enabled = false;
		}

		public void RemoveUnit(Unit unit)
		{
			timeline.RemoveUnit(unit);
		}

		private void NextTurn()
		{
			timeline.Next();
			onNext?.Invoke();
		}
	}
}