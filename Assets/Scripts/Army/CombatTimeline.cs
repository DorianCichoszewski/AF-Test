namespace AFSInterview.Army
{
	using System.Collections.Generic;
	
	public class CombatTimeline
	{
		private int currentTurnIndex = 1;
		
		private List<CombatTurn> plannedTurns = new();
		
		private CombatTurn CurrentTurn => plannedTurns[0];

		public int CurrentTurnIndex => currentTurnIndex;
		public Unit NextUnit => CurrentTurn.PreviewUnit();

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
			var unit = CurrentTurn.GetNextUnit();
			unit.ProcessTurn();
			
			int turnsToWait = unit.AttackInterval;
			while (plannedTurns.Count <= turnsToWait)
			{
				plannedTurns.Add(new CombatTurn());
			}
			plannedTurns[turnsToWait].AddUnit(unit);
			
			while (CurrentTurn.RemainingUnits == 0)
			{
				NextTurn();
				currentTurnIndex++;
			}
		}

		private void NextTurn()
		{
			plannedTurns.RemoveAt(0);
		}
	}
}