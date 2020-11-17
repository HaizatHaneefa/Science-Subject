using UnityEngine;
using Lean.Localization;

[CreateAssetMenu (menuName = "Audio/Sound Data", fileName = "Sound Data")]
public class SoundData : ScriptableObject {
	[SerializeField] LocalizedSound[] localizedClips;
	[SerializeField] AudioClip[] defaultClips;
	public AudioClip randomClip => GetClips().GetRandom();

	public AudioClip[] GetClips(string language = null) {
		AudioClip[] clips = defaultClips;
		string getLanguage = string.IsNullOrEmpty(language) ? LeanLocalization.CurrentLanguage : language;
		foreach (var locale in localizedClips) {
			if (locale.language == getLanguage) {
				clips = locale.clips;
				break;
			}
		}
		if (clips == defaultClips) {
			Debug.LogWarning("Using default clips. No valid clips were found. Check if language was set up correctly", this);
		}
		return clips;
	}
}

[System.Serializable]
public class LocalizedSound {
	public string language;
	public AudioClip[] clips;
}