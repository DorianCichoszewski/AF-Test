using UnityEngine;

namespace AFSInterview.Army
{
	public class Unit : MonoBehaviour
	{
		[SerializeField] private UnitScriptable definition;

		[SerializeField] private int currentLife;

		private ArmyController assignedArmy;
		private bool isAlive = true;

		public UnitAttribute Attribute => definition.Attribute;
		public int AttackInterval => definition.AttackInterval;
		public bool IsAlive => isAlive;

		public void Init(ArmyController army)
		{
			assignedArmy = army;
			currentLife = definition.MaxHealth;
			gameObject.name = definition.name;
		}

		public void TakeDamage(int damage)
		{
			int finalDamage = Mathf.Max(1, damage - definition.Armor);
			currentLife -= finalDamage;
			if (currentLife <= 0)
			{
				Death();
			}
		}

		public void ProcessTurn()
		{
			var enemy = assignedArmy.CombatManager.GetRandomUnitFromOtherArmy(assignedArmy);
			enemy.TakeDamage(definition.GetAttackValue(enemy.Attribute));
		}

		private void Death()
		{
			isAlive = false;
			assignedArmy.RemoveUnit(this);
			gameObject.SetActive(false);
		}
	}
}