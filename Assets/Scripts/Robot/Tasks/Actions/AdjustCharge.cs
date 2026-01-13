using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

    [Category("Custom/Robot")]
    
    public class AdjustCharge : ActionTask {

        public BBParameter<float> currentCharge;
        public float adjustmentValue = 0.1f;

        private Blackboard agentBb;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            agentBb = agent.GetComponent<Blackboard>();

            if (agentBb != null)
                return null;
            else
                return $"MoveAndRotateTowards - {agent.name}: Unable to get blackboard reference!";
        }

        protected override void OnUpdate()
        {
            currentCharge.value += adjustmentValue * Time.deltaTime;
        }
    }
}