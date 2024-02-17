using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pendu.Views
{
    /// <summary>
    /// Logique d'interaction pour theMan.xaml
    /// </summary>
    public partial class theMan : UserControl
    {
        public int NumberOfErrors
        {
            get { return (int)GetValue(NumberOfErrorsProperty); }
            set { SetValue(NumberOfErrorsProperty, value); }
        }
        public static readonly DependencyProperty NumberOfErrorsProperty =
            DependencyProperty.Register("NumberOfErrors", typeof(int), typeof(theMan), new PropertyMetadata(0, OnErrorsChanged));

        public bool ShowGround
        {
            get { return (bool)GetValue(ShowGroundProperty); }
            set { SetValue(ShowGroundProperty, value); }
        }
        public static readonly DependencyProperty ShowGroundProperty =
            DependencyProperty.Register("ShowGround", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowPole
        {
            get { return (bool)GetValue(ShowPoleProperty); }
            set { SetValue(ShowPoleProperty, value); }
        }
        public static readonly DependencyProperty ShowPoleProperty =
            DependencyProperty.Register("ShowPole", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowHighBar
        {
            get { return (bool)GetValue(ShowHighBarProperty); }
            set { SetValue(ShowHighBarProperty, value); }
        }
        public static readonly DependencyProperty ShowHighBarProperty =
            DependencyProperty.Register("ShowHighBar", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowCrossBar
        {
            get { return (bool)GetValue(ShowCrossBarProperty); }
            set { SetValue(ShowCrossBarProperty, value); }
        }
        public static readonly DependencyProperty ShowCrossBarProperty =
            DependencyProperty.Register("ShowCrossBar", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowRope
        {
            get { return (bool)GetValue(ShowRopeBarProperty); }
            set { SetValue(ShowRopeBarProperty, value); }
        }
        public static readonly DependencyProperty ShowRopeBarProperty =
            DependencyProperty.Register("ShowRope", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowHead
        {
            get { return (bool)GetValue(ShowHeadProperty); }
            set { SetValue(ShowHeadProperty, value); }
        }
        public static readonly DependencyProperty ShowHeadProperty =
            DependencyProperty.Register("ShowHead", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowBody
        {
            get { return (bool)GetValue(ShowBodyProperty); }
            set { SetValue(ShowBodyProperty, value); }
        }
        public static readonly DependencyProperty ShowBodyProperty =
            DependencyProperty.Register("ShowBody", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowLeftArm
        {
            get { return (bool)GetValue(ShowLeftArmProperty); }
            set { SetValue(ShowLeftArmProperty, value); }
        }
        public static readonly DependencyProperty ShowLeftArmProperty =
            DependencyProperty.Register("ShowLeftArm", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowRightArm
        {
            get { return (bool)GetValue(ShowRightArmProperty); }
            set { SetValue(ShowRightArmProperty, value); }
        }
        public static readonly DependencyProperty ShowRightArmProperty =
            DependencyProperty.Register("ShowRightArm", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowLeftLeg
        {
            get { return (bool)GetValue(ShowLeftLegProperty); }
            set { SetValue(ShowLeftLegProperty, value); }
        }
        public static readonly DependencyProperty ShowLeftLegProperty =
            DependencyProperty.Register("ShowLeftLeg", typeof(bool), typeof(theMan), new PropertyMetadata(false));

        public bool ShowRightLeg
        {
            get { return (bool)GetValue(ShowRightLegProperty); }
            set { SetValue(ShowRightLegProperty, value); }
        }
        public static readonly DependencyProperty ShowRightLegProperty =
            DependencyProperty.Register("ShowRightLeg", typeof(bool), typeof(theMan), new PropertyMetadata(false));



        public theMan()
        {
            InitializeComponent();
        }

        private static void OnErrorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int numberOfErrors = (int)e.NewValue;
            theMan theManControl = d as theMan;

            switch (numberOfErrors)
            {
                case 1:
                    theManControl.SetValue(theMan.ShowGroundProperty, true);
                    break;
                case 2:
                    theManControl.SetValue(theMan.ShowPoleProperty, true);
                    break;
                case 3:
                    theManControl.SetValue(theMan.ShowHighBarProperty, true);
                    break;
                case 4:
                    theManControl.SetValue(theMan.ShowCrossBarProperty, true);
                    break;
                case 5:
                    theManControl.SetValue(theMan.ShowRopeBarProperty, true);
                    break;
                case 6:
                    theManControl.SetValue(theMan.ShowHeadProperty, true);
                    break;
                case 7:
                    theManControl.SetValue(theMan.ShowBodyProperty, true);
                    break;
                case 8:
                    theManControl.SetValue(theMan.ShowLeftArmProperty, true);
                    break;
                case 9:
                    theManControl.SetValue(theMan.ShowRightArmProperty, true);
                    break;
                case 10:
                    theManControl.SetValue(theMan.ShowLeftLegProperty, true);
                    break;
                case 11:
                    theManControl.SetValue(theMan.ShowRightLegProperty, true);
                    break;
                case 0:
                    theManControl.SetValue(theMan.ShowGroundProperty, false);
                    theManControl.SetValue(theMan.ShowPoleProperty, false);
                    theManControl.SetValue(theMan.ShowHighBarProperty, false);
                    theManControl.SetValue(theMan.ShowCrossBarProperty, false);
                    theManControl.SetValue(theMan.ShowRopeBarProperty, false);
                    theManControl.SetValue(theMan.ShowHeadProperty, false);
                    theManControl.SetValue(theMan.ShowBodyProperty, false);
                    theManControl.SetValue(theMan.ShowLeftArmProperty, false);
                    theManControl.SetValue(theMan.ShowRightArmProperty, false);
                    theManControl.SetValue(theMan.ShowLeftLegProperty, false);
                    theManControl.SetValue(theMan.ShowRightLegProperty, false);
                    break;
            }

        }
    }
}
