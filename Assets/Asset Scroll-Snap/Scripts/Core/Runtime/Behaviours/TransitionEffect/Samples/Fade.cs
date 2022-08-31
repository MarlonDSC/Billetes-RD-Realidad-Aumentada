using UnityEngine;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class Fade : TransitionEffectBase<CanvasGroup>
    {
        public override void OnTransition(CanvasGroup canvasGroup, float alpha)
        {
            canvasGroup.alpha = alpha;
        }
    }
}