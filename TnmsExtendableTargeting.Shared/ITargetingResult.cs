using System.Collections.Generic;
using Sharp.Shared.Objects;

namespace TnmsExtendableTargeting.Shared;

public interface ITargetingResult
{
    /// <summary>
    /// true if only found one target, otherwise false.
    /// </summary>
    public bool IsSingleTarget { get; }

    /// <summary>
    /// returns target name if single target, otherwise count of targets. <br/>
    /// e.g. => console: "CONSOLE" | player: "player name" | multiple target: "17"
    /// </summary>
    /// <returns></returns>
    public string GetTargetName();
    
    /// <summary>
    /// Results of target
    /// </summary>
    /// <returns></returns>
    public List<IGameClient> GetTargets();
}