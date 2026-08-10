// SPDX-License-Identifier: AGPL-3.0-or-later

namespace Content.Goobstation.Shared.LightDetection;

/// <summary>
/// Event raised when the light level changes on an entity.
/// </summary>
[ByRefEvent]
public readonly record struct LightLevelUpdated(float NewLightLevel);
