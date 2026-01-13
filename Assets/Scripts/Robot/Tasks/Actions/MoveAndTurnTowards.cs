using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

    [Category("Custom/Robot")]
    
	public class MoveAndTurnTowards : ActionTask {

        public Transform target;
        public float moveSpeed = 5f;
        [Tooltip("Measured in degrees per second")] 
		public float turnSpeed = 180f;
		public float stoppingDistance = 0.1f;

		private Blackboard agentBb;

		protected override string OnInit() {
			agentBb = agent.GetComponent<Blackboard>();

			if (agentBb != null) 
				return null;
			else 
				return $"MoveAndRotateTowards - {agent.name}: Unable to get blackboard reference!";
		}

        protected override void OnExecute()
        {
			moveSpeed = agentBb.GetVariableValue<float>("moveSpeed");
            turnSpeed = agentBb.GetVariableValue<float>("turnSpeed");
            stoppingDistance = agentBb.GetVariableValue<float>("stoppingDistance");
        }

		protected override void OnUpdate()
		{
			Vector3 dir = target.position - agent.transform.position;
			Quaternion rot = Quaternion.LookRotation(dir);

			agent.transform.SetPositionAndRotation(
				agent.transform.position + moveSpeed * Time.deltaTime * agent.transform.forward, 
				Quaternion.RotateTowards(agent.transform.rotation, rot, turnSpeed * Time.deltaTime)
			);

			if (Vector3.Distance(agent.transform.position, target.position) < stoppingDistance)
			{
				EndAction(true);
			}
		}
	}
}