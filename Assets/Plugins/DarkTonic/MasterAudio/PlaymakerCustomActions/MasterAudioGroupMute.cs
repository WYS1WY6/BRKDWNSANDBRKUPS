using DarkTonic.MasterAudio;
using UnityEngine;
using HutongGames.PlayMaker;
using TooltipAttribute = HutongGames.PlayMaker.TooltipAttribute;

[ActionCategory(ActionCategory.Audio)]
[Tooltip("Mute a Sound Group in Master Audio")]
public class MasterAudioGroupMute : FsmStateAction {
	[Tooltip("Check this to perform action on all Sound Groups")]
	public FsmBool allGroups;	

    [Tooltip("Name of Master Audio Sound Group")]
	public FsmString soundGroupName;
	
	public override void OnEnter() {
		if (!allGroups.Value && string.IsNullOrEmpty(soundGroupName.Value)) {
			Debug.LogError("You must either check 'All Groups' or enter the Sound Group Name");
			return;
		}

		if (allGroups.Value) {
			var groupNames = MasterAudio.RuntimeSoundGroupNames;
			for (var i = 0; i < groupNames.Count; i++) {
				MasterAudio.MuteGroup(groupNames[i]);
			}
		} else {
			MasterAudio.MuteGroup(soundGroupName.Value);
		}
		
		Finish();
	}
	
	public override void Reset() {
		allGroups = new FsmBool(false);
		soundGroupName = new FsmString(string.Empty);
	}
}
