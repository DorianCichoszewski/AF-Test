namespace AFSInterview.Army
{
	using UnityEngine;
	using System.Collections.Generic;
	using System.Linq;
	
	public class ArmyController : MonoBehaviour
	{
		[SerializeField] private List<Unit> units;

		private CombatManager combatManager;

		public List<Unit> Units => units;
		public CombatManager CombatManager => combatManager;

		public void Init(CombatManager manager)
		{
			combatManager = manager;
			foreach (var unit in units)
			{
				unit.Init(this);
			}
		}

		public void RemoveUnit(Unit unit)
		{
			units.Remove(unit);
			combatManager.RemoveUnit(unit);
			if (units.Count == 0)
			{
				combatManager.EndCombat(this);
			}
		}

		[ContextMenu(nameof(GetUnitsInChildren))]
		private void GetUnitsInChildren()
		{
			units = GetComponentsInChildren<Unit>().ToList();
		}
	}
}