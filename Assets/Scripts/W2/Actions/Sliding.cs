using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Sliding : ActionTask {
        public BBParameter<GameObject> otherFSM;
		public BBParameter<int> loc;

        protected override string OnInit() {
			return null;
		}

		protected override void OnUpdate() {
            Blackboard oFSM = otherFSM.value.GetComponent<Blackboard>();
			if (oFSM.GetVariableValue<int>("location") == loc.value) {
				oFSM.SetVariableValue("friendship", oFSM.GetVariableValue<float>("friendship") + Time.deltaTime);
			}
        }
	}
}