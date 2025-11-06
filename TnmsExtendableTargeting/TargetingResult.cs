using System.Collections.Generic;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting;

public class TargetingResult(List<IGameClient> found): ITargetingResult
{
    public bool IsSingleTarget { get; } = found.Count == 1;
    public string GetTargetName()
    {
        if (IsSingleTarget)
            return found[0].Name;

        return string.Join(", ", found);
    }

    public List<IGameClient> GetTargets() => found;
}