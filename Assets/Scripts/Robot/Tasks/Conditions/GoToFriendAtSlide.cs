using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class GoToFriendAtSlide : ConditionTask {
        public BBParameter<float> friendshipValue;
        public BBParameter<GameObject> otherFSM;

		protected override bool OnCheck() {
            Blackboard oFSM = otherFSM.value.GetComponent<Blackboard>();
            return (friendshipValue.value > 50f && oFSM.GetVariableValue<int>("location") == 1);
		}
	}
}