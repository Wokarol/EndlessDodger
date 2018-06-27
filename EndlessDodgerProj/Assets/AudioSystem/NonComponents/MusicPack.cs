using UnityEngine;

namespace Wokarol.AudioSystem
{
	[CreateAssetMenu(menuName = "Audio/MusicPack")]
	public class MusicPack : ScriptableObject
	{
		public AudioClip[] musicTracks;
	}
}