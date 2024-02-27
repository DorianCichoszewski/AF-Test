namespace AFSInterview.Army
{
	using System;
	using System.Collections.Generic;
	
	[Serializable]
	public class CombatTurn
	{
		public List<Unit> unitsToProcess = new ();

		public int RemainingUnits => unitsToProcess.Count;

		public void AddUnit(Unit unit)
		{
			unitsToProcess.Add(unit);
		}
		
		public bool RemoveUnit(Unit unit)
		{
			List<Unit> newQueue = new();
			bool removedUnit = false;
			while (unitsToProcess.Count > 0)
			{
				var currentUnit = unitsToProcess[0];
				unitsToProcess.RemoveAt(0);
				if (currentUnit == unit)
				{
					removedUnit = true;
					continue;
				}
				newQueue.Add(currentUnit);
			}

			unitsToProcess = newQueue;
			return removedUnit;
		}

		public Unit GetNextUnit()
		{
			var unit =  unitsToProcess[0];
			unitsToProcess.RemoveAt(0);
			return unit;
		}
	}
}