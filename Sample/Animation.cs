using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Sample
{
    public partial class Manager
    {
        public void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Interval = TimeSpan.FromSeconds(Loop);
            Next = !Next;
            C.Text = Next ? Text1 : Text2;
            if (WithColor)
            {
                C.Background = Next ? BG1 : BG2;
                C1.Background = BG1;
                C2.Background = BG2;
            }
            else
            {
                C.Background = T;
                C1.Background = T;
                C2.Background = T;
            }
            R.ForEach(x => x.Fill = Hide ? BG : T);

            OldAnimation();
            NewAnimation();
        }

        private void OldAnimation()
        {
            var anim = new DoubleAnimation
            {
                From = Next ? 0 : -C1.ActualWidth,
                To = Next ? -C1.ActualWidth : 0,
                Duration = TimeSpan.FromSeconds(Anim * 2)
            };
            Trans1.BeginAnimation(TranslateTransform.XProperty, anim);
            Trans2.BeginAnimation(TranslateTransform.XProperty, anim);
        }

        private void NewAnimation()
        {
            var time = Anim;
            var next = Next;

            var anime1 = new DoubleAnimation
            {
                From = 0,
                To = C.ActualWidth * (next ? -1 : 1),
                Duration = TimeSpan.FromSeconds(time)
            };
            SetEasingFunction(anime1, true);

            var anime2 = new DoubleAnimation
            {
                From = C.ActualWidth * (next ? 1 : -1),
                To = 0,
                Duration = TimeSpan.FromSeconds(time)
            };
            SetEasingFunction(anime2, false);

            bool withColor = WithColor;

            anime1.Completed += (s, e) =>
            {
                C.Text = next ? Text2 : Text1;
                if (withColor)
                {
                    C.Background = next ? BG2 : BG1;
                }
                Trans.BeginAnimation(TranslateTransform.XProperty, anime2);
            };
            Trans.BeginAnimation(TranslateTransform.XProperty, anime1);
        }
    }
}
