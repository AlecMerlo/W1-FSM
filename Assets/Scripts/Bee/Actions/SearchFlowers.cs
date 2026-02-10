using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SearchFlowers : ActionTask {
        public BBParameter<Transform> flowerSearch;
		public BBParameter<bool> foundFlower;
        
		protected override void OnExecute() {

			if (flowerSearch.value.GetComponentInChildren<PollenFlower>() != null)
			{
				foundFlower.SetValue(true);
			}
			else
			{
				
			}
				EndAction(true);
		}
	}
}