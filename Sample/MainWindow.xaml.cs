using System;
using System.Windows;
using System.Windows.Controls;

namespace Sample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Manager.Instance.C = C;
            Manager.Instance.C1 = C1;
            Manager.Instance.C2 = C2;

            Manager.Instance.Trans = Trans;
            Manager.Instance.Trans1 = Trans1;
            Manager.Instance.Trans2 = Trans2;

            Manager.Instance.R.Add(R1);
            Manager.Instance.R.Add(R2);
            Manager.Instance.R.Add(R3);
            Manager.Instance.R.Add(R4);

            C.Text = Manager.Instance.Text1;
            C1.Text = Manager.Instance.Text1;
            C2.Text = Manager.Instance.Text2;
            Speed.ItemsSource = Enum.GetValues(typeof(Manager.AnimationSpeed));
            Combo.ItemsSource = Enum.GetValues(typeof(Manager.EasingAnimation));
            Combo.SelectedIndex = 6;


            Manager.Instance.Timer_Tick(null, null);
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            Pp.IsOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.Instance.WithColor = !Manager.Instance.WithColor;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.Instance.Hide = !Manager.Instance.Hide;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Pop.IsOpen = !Pop.IsOpen;
        }

        private void Combo_Selected(object sender, RoutedEventArgs e)
        {
            if (Combo.SelectedItem is Manager.EasingAnimation type)
            {
                Manager.Instance.EasingType = type;
                Button.Content = $"EasingType : {type}";
            }
            Pop.IsOpen = false;
        }
       
        private void Speed_Selected(object sender, RoutedEventArgs e)
        {
            if (Speed.SelectedItem is Manager.AnimationSpeed type)
            {
                switch (type)
                {
                    case Manager.AnimationSpeed.Normal:
                        Manager.Instance.Anim = 0.1;
                        Manager.Instance.Loop = 2.2;
                        break;
                    case Manager.AnimationSpeed.Slow:
                        Manager.Instance.Anim = 1;
                        Manager.Instance.Loop = 3;
                        break;
                    case Manager.AnimationSpeed.SuperSlow:
                        Manager.Instance.Anim = 3;
                        Manager.Instance.Loop = 8;
                        break;
                }
            }
            Pp.IsOpen = false;
            Manager.Instance.Timer.Interval = TimeSpan.FromSeconds(0.5);
            Manager.Instance.Timer.Start();
        }
    }
}
