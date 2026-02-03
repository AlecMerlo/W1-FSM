using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class ReachedLocation : ConditionTask {
        public BBParameter<NavMeshAgent> nav;
        
        protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {
			return !nav.value.hasPath;
		}
	}
}