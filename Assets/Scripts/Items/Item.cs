namespace AFSInterview.Items
{
	using System;
	using UnityEngine;

	[Serializable]
	public class Item
	{
		[SerializeField] private ItemScriptable definition;

		public string Name => definition.Name;
		public int Value => definition.Value;

		public Item(ItemScriptable definition)
		{
			this.definition = definition;
		}
		
		public bool Use(InventoryController inventoryController)
		{
			if (!definition.IsConsumable) return false;
			
			Debug.Log("Using " + Name);

			if (definition.MoneyOnUse != 0)
				inventoryController.Money += definition.MoneyOnUse;
			if (definition.ItemOnUse != null)
				inventoryController.AddItem(new Item(definition.ItemOnUse));
			
			return true;
		}
	}
}