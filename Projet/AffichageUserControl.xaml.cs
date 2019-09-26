using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Projet
{
    public sealed partial class AffichageUserControl : UserControl
    {
        public AffichageUserControl()
        {
            this.InitializeComponent();
        }



        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(string), typeof(AffichageUserControl), new PropertyMetadata(""));



        public string FirstLabel
        {
            get { return (string)GetValue(FirstLabelProperty); }
            set { SetValue(FirstLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstLabelProperty =
            DependencyProperty.Register("FirstLabel", typeof(string), typeof(AffichageUserControl), new PropertyMetadata(""));



        public string SecondLabel
        {
            get { return (string)GetValue(SecondLabelProperty); }
            set { SetValue(SecondLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SecondLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondLabelProperty =
            DependencyProperty.Register("SecondLabel", typeof(string), typeof(AffichageUserControl), new PropertyMetadata(""));
    }
}
