using MaterialSkin;
using MaterialSkin.Controls;

public static class ThemeManager
{
    public static void Apply(MaterialForm form)
    {
        var skinManager = MaterialSkinManager.Instance;
        skinManager.AddFormToManage(form);
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        skinManager.ColorScheme = new ColorScheme(
            Primary.Blue600,        // #185FA5 - Primary (buttons, header)
            Primary.Blue700,        // #0C447C - Darker header/toolbar
            Primary.Blue200,        // #85B7EB - Light accent
            Accent.LightBlue200,    // Ripple/highlight effect
            TextShade.WHITE         // White text on primary color
        );
    }
}