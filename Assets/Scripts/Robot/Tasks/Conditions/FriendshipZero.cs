using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class FriendshipZero : ConditionTask {
        public BBParameter<GameObject> otherFSM;

		protected override bool OnCheck() {
            Blackboard oFSM = otherFSM.value.GetComponent<Blackboard>();
            if (oFSM.GetVariableValue<float>("friendship") <= 0.1f)
            {
                return true;
            }
            return false;
		}
	}
}