using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Army
{
	public class CombatTimeline : MonoBehaviour
	{
		[SerializeField]
		private int currentTurnIndex = 1;

		[SerializeField]
		private List<CombatTurn> plannedTurns = new();
		
		private CombatTurn CurrentTurn => plannedTurns[0];

		public void AddNewUnit(Unit unit)
		{
			if (plannedTurns.Count == 0)
			{
				plannedTurns.Add(new CombatTurn());
			}
			CurrentTurn.AddUnit(unit);
		}

		public void RemoveUnit(Unit unit)
		{
			foreach (var plannedTurn in plannedTurns)
			{
				if (plannedTurn.RemoveUnit(unit))
				{
					break;
				}
			}
		}

		public void Next()
		{
			while (CurrentTurn.RemainingUnits == 0)
			{
				NextTurn();
				currentTurnIndex++;
			}
			var unit = CurrentTurn.GetNextUnit();
			unit.ProcessTurn();
			
			int turnsToWait = unit.AttackInterval;
			while (plannedTurns.Count <= turnsToWait)
			{
				plannedTurns.Add(new CombatTurn());
			}
			plannedTurns[turnsToWait].AddUnit(unit);
		}

		private void NextTurn()
		{
			plannedTurns.RemoveAt(0);
		}
	}
}