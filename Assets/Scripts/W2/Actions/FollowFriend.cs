using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Threading;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Custom/W2")]

    public class FollowFriend : ActionTask
    {

        public BBParameter<Transform> target;
        public float moveSpeed = 5f;
        [Tooltip("Measured in degrees per second")]
        public float turnSpeed = 180f;
        public float stoppingDistance = 0.1f;
        private float timer = 0;
        public BBParameter<GameObject> otherFSM;

        private Blackboard agentBb;

        protected override string OnInit()
        {
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
            timer = 0;
        }

        protected override void OnUpdate()
        {
            Vector3 dir = target.value.position - agent.transform.position;
            Quaternion rot = Quaternion.LookRotation(dir);

            agent.transform.SetPositionAndRotation(
                agent.transform.position + moveSpeed * Time.deltaTime * agent.transform.forward,
                Quaternion.RotateTowards(agent.transform.rotation, rot, turnSpeed * Time.deltaTime)
            );

            Blackboard oFSM = otherFSM.value.GetComponent<Blackboard>();
            oFSM.SetVariableValue("friendship", oFSM.GetVariableValue<float>("friendship") + (Time.deltaTime * 0.75f));

            timer += Time.deltaTime;
            if (timer > 14)
            {
                EndAction(true);
            }
        }
    }
}