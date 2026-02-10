using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class ReturnActionTask : ActionTask{
		public BBParameter<Vector3> startingPosition;
        public float arrivalDistance;

        private NavMeshAgent navmeshAgent;
        
        protected override string OnInit(){
            navmeshAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		protected override void OnExecute(){
            if (!NavMesh.SamplePosition(startingPosition.value, out NavMeshHit navMeshHit, 2, NavMesh.AllAreas))
            {
                Debug.Log("Could not generate a path.");
            }
            else
            {
                //Set the path
                navmeshAgent.SetDestination(navMeshHit.position);
            }
        }

		protected override void OnUpdate(){
            float distanceToTarget = Vector3.Distance(startingPosition.value, agent.transform.position);
            if (navmeshAgent.pathStatus == NavMeshPathStatus.PathComplete &&
                 distanceToTarget < arrivalDistance)
            { 
                EndAction(true);
            }
        }
	}
}