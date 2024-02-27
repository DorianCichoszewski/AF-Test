namespace AFSInterview.Army
{
	using UnityEngine;
	using System.Collections.Generic;

	[CreateAssetMenu(menuName = "AFSInterview/Unit", fileName = "Unit")]
	public class UnitScriptable : ScriptableObject
	{
		[SerializeField] private UnitAttribute attribute;
		[SerializeField] private int maxHealth;
		[SerializeField] private int armor;
		[SerializeField] private int attackInterval;
		[SerializeField] private int baseAttackDamage;
		[SerializeField] private List<AttackOverride> attackOverrides;

		public int AttackValue(UnitAttribute targetsAttribute)
		{
			foreach (var attackOverride in attackOverrides)
			{
				if (attackOverride.attribute == targetsAttribute)
					return attackOverride.attackValue;
			}

			return baseAttackDamage;
		}

		private void OnValidate()
		{
			foreach (var attackOverride in attackOverrides)
			{
				attackOverride.SetName();
			}
		}
	}
}