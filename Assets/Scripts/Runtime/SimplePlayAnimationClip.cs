using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Game.Runtime
{
    [RequireComponent(typeof(Animator))]
    public class SimplePlayAnimationClip : MonoBehaviour
    {
        public AnimationClip clip;
        private PlayableGraph _playableGraph;

        private void Start()
        {
            _playableGraph=PlayableGraph.Create();
            _playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
            var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "Animation",GetComponent<Animator>());
            // playable でクリップをラップします
            var clipPlayable = AnimationClipPlayable.Create(_playableGraph, clip);
            // Playable を output に接続します
            playableOutput.SetSourcePlayable(clipPlayable);
            // グラフを再生します。
            _playableGraph.Play();
        }

        private void OnDisable()
        {
            _playableGraph.Destroy();
        }
    }
}
