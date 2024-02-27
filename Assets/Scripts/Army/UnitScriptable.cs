namespace AFSInterview.Army
{
	using UnityEngine;
	using System.Collections.Generic;

	[CreateAssetMenu(menuName = "AFSInterview/Unit", fileName = "Unit")]
	public class UnitScriptable : ScriptableObject
	{
		[SerializeField] private GameObject mesh;
		[SerializeField] private UnitAttribute attribute;
		[SerializeField] private int maxHealth;
		[SerializeField] private int armor;
		[SerializeField] private int attackInterval;
		[SerializeField] private int baseAttackDamage;
		[SerializeField] private List<AttackOverride> attackOverrides;

		public GameObject Mesh => mesh;
		public UnitAttribute Attribute => attribute;
		public int MaxHealth => maxHealth;
		public int Armor => armor;
		public int AttackInterval => attackInterval;

		public int GetAttackValue(UnitAttribute targetsAttribute)
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