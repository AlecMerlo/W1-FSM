using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class SetNavmeshPositionTo : ActionTask {
		public BBParameter<NavMeshAgent> nav;
		public Transform dest;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			nav.value.destination = dest.position;
            EndAction(true);
        }
	}
}