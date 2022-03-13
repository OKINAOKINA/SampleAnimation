using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sample
{
    public partial class Manager
    {
        private static Manager _Instance;
        public static Manager Instance => _Instance ?? (_Instance = new Manager());

        public Manager()
        {
            Timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.2) };
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }


        public double Loop = 1.2;
        public double Anim = 0.1;
        public string Text1 = "Component\nBehavior";
        public string Text2 = "Mesh\nMaterial\nMasterMaterial\nMemo\nAIMap\nFSM\nBehaviorTree\nMotion";

        public bool WithColor = false;
        public Brush BG1 = new SolidColorBrush(Colors.Blue);
        public Brush BG2 = new SolidColorBrush(Colors.Red);

        public bool Hide = true;
        public Brush BG = new SolidColorBrush(Colors.LightGray);

        public bool Expo = false;
        public EasingAnimation EasingType = EasingAnimation.None;

        public Brush T = new SolidColorBrush(Colors.Transparent);

        public DispatcherTimer Timer;

        public TextBlock C;
        public TextBlock C1;
        public TextBlock C2;

        public List<Rectangle> R = new List<Rectangle>();

        public TranslateTransform Trans;
        public TranslateTransform Trans1;
        public TranslateTransform Trans2;

        public bool Next;

        public enum EasingAnimation
        {
            None,
            BackEase,
            BounceEase,
            CircleEase,
            CubicEase,
            ElasticEase,
            ExponentialEase,
            PowerEase,
            QuadraticEase,
            QuarticEase,
            QuinticEase,
            SineEase
        }

        public enum AnimationSpeed
        {
            Normal,
            Slow,
            SuperSlow
        }
    }
}
