﻿using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using WDE.Common.Avalonia.Controls;

namespace WDE.SmartScriptEditor.Avalonia.Editor.Views
{
    /// <summary>
    ///     Interaction logic for SmartSelectView.xaml
    /// </summary>
    public partial class SmartSelectView : DialogViewBase
    {
        public SmartSelectView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}