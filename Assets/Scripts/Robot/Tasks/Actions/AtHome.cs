using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AtHome : ActionTask {
        public BBParameter<GameObject> otherFSM;
        private float timer = 0;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            timer = 0;
        }


        protected override void OnUpdate() {
            Blackboard oFSM = otherFSM.value.GetComponent<Blackboard>();
            oFSM.SetVariableValue("friendship", oFSM.GetVariableValue<float>("friendship") - Time.deltaTime);
			oFSM.SetVariableValue("friendship", Mathf.Clamp(oFSM.GetVariableValue<float>("friendship"), 0, 100));

            timer += Time.deltaTime;
            if (timer > 6)
            {
                EndAction(true);
            }
        }
	}
}