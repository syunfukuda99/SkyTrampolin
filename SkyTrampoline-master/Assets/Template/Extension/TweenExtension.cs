using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Extension.TweenExtension
{
    public static class TweenExtension 
    {        
        public static Sequence Join( this Tweener self, Tween other) 
        {
            var seq = DOTween.Sequence();
            seq.Join(self);
            seq.Join(other);
            return seq;
        }
        
        public static Sequence Append( this Tweener self, Tween other) 
        {
            var seq = DOTween.Sequence();
            seq.Append(self);
            seq.Append(other);
            return seq;
        }

        public static Tweener ToAlpha(this Graphic self, float endValue, float duration)
        {
            return DOTween.ToAlpha(() => self.color, c => self.color = c, endValue, duration);
        }
        
        public static void SetAlpha(this Graphic self, float endValue)
        {
            self.color = new Color(self.color.r, self.color.g, self.color.b, endValue);
        }

        public static TweenerCore<Vector3, Vector3, VectorOptions> ScaleToBack(
            this Transform target,
            Vector3 startValue,
            float duration)
        {
            var endValue = target.localScale;
            target.localScale = startValue;
            return target.DOScale(endValue, duration);
        }

    }
}