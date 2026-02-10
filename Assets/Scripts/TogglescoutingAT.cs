using NodeCanvas.Framework;
using UnityEngine;

public class TogglescoutingAT : ActionTask
{
    public BBParameter<bool> scoutingBBP;
    public AudioSource source;
    public AudioClip clip;

    protected override void OnExecute()
    {
        scoutingBBP.value = !scoutingBBP.value;

        AudioManager.Instance.PlaySoundEffect(clip, source);

        EndAction(true);
    }
}
