namespace AFSInterview.Army
{
	using UnityEngine;
	using System;
	
	public class Unit : MonoBehaviour
	{
		[SerializeField] private UnitScriptable definition;
		
		private ArmyController assignedArmy;
		private int currentLife;

		public event Action<int> onLifeChanged;
		public event Action onDeath;

		public UnitAttribute Attribute => definition.Attribute;
		public UnitScriptable Definition => definition;
		public int AttackInterval => definition.AttackInterval;
		public ArmyController AssignedArmy => assignedArmy;
		public int CurrentLife => currentLife;

		public void Init(ArmyController army)
		{
			assignedArmy = army;
			currentLife = definition.MaxHealth;
			gameObject.name = definition.name;
			Instantiate(definition.Mesh, transform);
		}

		public void TakeDamage(int damage)
		{
			int finalDamage = Mathf.Max(1, damage - definition.Armor);
			currentLife -= finalDamage;
			if (currentLife <= 0)
			{
				Death();
			}
			onLifeChanged?.Invoke(currentLife);
		}

		public void ProcessTurn()
		{
			var enemy = assignedArmy.CombatManager.GetRandomUnitFromOtherArmy(assignedArmy);
			enemy.TakeDamage(definition.GetAttackValue(enemy.Attribute));
		}

		private void Death()
		{
			assignedArmy.RemoveUnit(this);
			gameObject.SetActive(false);
			onDeath?.Invoke();
		}
	}
}