using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class SetNavmeshPositionToFlowers : ActionTask {
		public BBParameter<NavMeshAgent> nav;
		public BBParameter<Transform> dest;
        public BBParameter<Transform> flowerSearch;
		public BBParameter<Transform> flowers;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			int randomFlowerLocation;

			randomFlowerLocation = Random.Range(0, dest.value.childCount);
			flowerSearch.value = flowers.value.GetChild(randomFlowerLocation);
            nav.value.destination = dest.value.GetChild(randomFlowerLocation).position;
            EndAction(true);
        }
	}
}