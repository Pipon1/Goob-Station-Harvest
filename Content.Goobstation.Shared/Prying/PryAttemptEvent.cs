// SPDX-License-Identifier: AGPL-3.0-or-later

namespace Content.Goobstation.Shared.Prying;

/// <summary>
/// Event raised on a user when they attempt to pry something.
/// Can be cancelled to prevent the prying.
/// </summary>
[ByRefEvent]
public record struct PryAttemptEvent(EntityUid Target)
{
    public bool Cancelled;

    public void Cancel()
    {
        Cancelled = true;
    }
}
