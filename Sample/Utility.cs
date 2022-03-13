using System.Windows.Media.Animation;

namespace Sample
{
    public partial class Manager
    {
        private void SetEasingFunction(DoubleAnimation anime, bool easeIn)
        {
            var mode = easeIn ? EasingMode.EaseIn : EasingMode.EaseOut;
            switch (EasingType)
            {
                case EasingAnimation.None:
                    break;
                case EasingAnimation.BackEase:
                    anime.EasingFunction = new BackEase { EasingMode = mode };
                    break;
                case EasingAnimation.BounceEase:
                    anime.EasingFunction = new BounceEase { EasingMode = mode };
                    break;
                case EasingAnimation.CircleEase:
                    anime.EasingFunction = new CircleEase { EasingMode = mode };
                    break;
                case EasingAnimation.CubicEase:
                    anime.EasingFunction = new CubicEase { EasingMode = mode };
                    break;
                case EasingAnimation.ElasticEase:
                    anime.EasingFunction = new ElasticEase { EasingMode = mode };
                    break;
                case EasingAnimation.ExponentialEase:
                    anime.EasingFunction = new ExponentialEase { EasingMode = mode };
                    break;
                case EasingAnimation.PowerEase:
                    anime.EasingFunction = new PowerEase { EasingMode = mode };
                    break;
                case EasingAnimation.QuadraticEase:
                    anime.EasingFunction = new QuadraticEase { EasingMode = mode };
                    break;
                case EasingAnimation.QuarticEase:
                    anime.EasingFunction = new QuarticEase { EasingMode = mode };
                    break;
                case EasingAnimation.QuinticEase:
                    anime.EasingFunction = new QuinticEase { EasingMode = mode };
                    break;
                case EasingAnimation.SineEase:
                    anime.EasingFunction = new SineEase { EasingMode = mode };
                    break;
            }
        }
    }
}
