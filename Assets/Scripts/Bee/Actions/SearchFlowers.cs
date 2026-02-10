using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SearchFlowers : ActionTask {
        public BBParameter<Transform> flowerSearch;
		public BBParameter<bool> foundFlower;
        
		protected override void OnExecute() {
			for (int i = 1; i < flowerSearch.value.childCount - 1; i++)
			{
				if (flowerSearch.value.GetChild(i).GetComponent<PollenFlower>() != null)
				{
					foundFlower = true;
				}
			}
			EndAction(true);
		}
	}
}