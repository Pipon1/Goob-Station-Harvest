using Content.Shared.Administration;
using Robust.Client.Graphics;
using Robust.Shared.Console;

namespace Content.Client._Harvest.AudioMuffle;

[AnyCommand]
public sealed class ShowAudioCommand : IConsoleCommand
{
    public string Command => "showaudiomuffle";
    public string Description => "Toggles the audio muffle debug overlay.";
    public string Help => "showaudiomuffle";

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        var overlayManager = IoCManager.Resolve<IOverlayManager>();

        if (overlayManager.HasOverlay<AudioMuffleOverlay>())
        {
            overlayManager.RemoveOverlay<AudioMuffleOverlay>();
            shell.WriteLine("Audio muffle overlay disabled.");
        }
        else
        {
            overlayManager.AddOverlay(new AudioMuffleOverlay());
            shell.WriteLine("Audio muffle overlay enabled.");
        }
    }
}
