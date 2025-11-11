using System.Collections.Generic;
using System.Globalization;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting;

public class TargetingResult(List<IGameClient> found, ICustomTargetBase targetBase): ITargetingResult
{
    private static readonly CultureInfo Info =  new("en-US");
    public bool IsSingleTarget { get; } = found.Count == 1;

    public string GetTargetName(CultureInfo? culture = null)
    {
        if (IsSingleTarget)
            return found[0].Name;
        
        if (culture != null)
            return targetBase.LocalizedTargetName(culture);

        return targetBase.LocalizedTargetName(Info);
    }

    public List<IGameClient> GetTargets() => found;
}