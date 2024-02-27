namespace AFSInterview.Army
{
	using System;
	using System.Collections.Generic;
	
	[Serializable]
	public class CombatTurn
	{
		public Queue<Unit> unitsToProcess = new ();

		public int RemainingUnits => unitsToProcess.Count;

		public void AddUnit(Unit unit)
		{
			unitsToProcess.Enqueue(unit);
		}
		
		public bool RemoveUnit(Unit unit)
		{
			Queue<Unit> newQueue = new();
			bool removedUnit = false;
			while (unitsToProcess.Count > 0)
			{
				var currentUnit = unitsToProcess.Dequeue();
				if (currentUnit == unit)
				{
					removedUnit = true;
					continue;
				}
				newQueue.Enqueue(currentUnit);
			}

			unitsToProcess = newQueue;
			return removedUnit;
		}

		public Unit GetNextUnit()
		{
			return unitsToProcess.Dequeue();
		}

		public Unit PreviewUnit()
		{
			return unitsToProcess.Peek();
		}
	}
}