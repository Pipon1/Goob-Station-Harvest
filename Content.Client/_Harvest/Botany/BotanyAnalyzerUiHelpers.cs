using Robust.Client.UserInterface.Controls;

namespace Content.Client._Harvest.Botany;

public static class BotanyAnalyzerUiHelpers
{
    public static readonly Color Good = Color.FromHex("#75E06F");
    public static readonly Color Neutral = Color.FromHex("#D8D8D8");
    public static readonly Color Warning = Color.FromHex("#F2C94C");
    public static readonly Color Bad = Color.FromHex("#EB5757");

    public static void AddRichLine(BoxContainer container, string text, Color color)
    {
        var label = new RichTextLabel { HorizontalExpand = true };
        label.SetMessage(text, color);
        container.AddChild(label);
    }
}
