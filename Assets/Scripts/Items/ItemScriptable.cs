namespace AFSInterview.Items
{
	using UnityEngine;
#if UNITY_EDITOR
	using UnityEditor;
#endif
	
	[CreateAssetMenu(menuName = "AFSInterview/Item", fileName = "Item")]
	public class ItemScriptable : ScriptableObject
	{
		[SerializeField] private string itemName;
		[SerializeField] private int value;
		
		[Header("Consumable")]
		[SerializeField] private bool isConsumable;
		[SerializeField] private int moneyOnUse;
		[SerializeField] private ItemScriptable itemOnUse;

		public string Name => itemName;
		public int Value => value;

		public bool IsConsumable => isConsumable;

		public int MoneyOnUse => moneyOnUse;
		public ItemScriptable ItemOnUse => itemOnUse;

		private void OnValidate()
		{
			if (moneyOnUse != 0 || itemOnUse != null && !isConsumable)
			{
				SetConsumable(true);
			}

			if (moneyOnUse == 0 && itemOnUse == null && isConsumable)
			{
				SetConsumable(false);
			}
		}

		private void SetConsumable(bool newValue)
		{
			if (isConsumable != newValue)
			{
				isConsumable = newValue;
#if UNITY_EDITOR
				EditorUtility.SetDirty(this);
#endif
			}
		}
	}
}