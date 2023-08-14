using System.Windows;
using System;

namespace OnMed.Desktop.Themes;

class AppTheme
{
    public static void ChangeTheme(Uri themeuri)
    {
        ResourceDictionary Theme = new ResourceDictionary() { Source = themeuri };

        App.Current.Resources.Clear();
        App.Current.Resources.MergedDictionaries.Add(Theme);
    }
}
