using System.Collections.Generic;
using System.Globalization;
using Sharp.Shared.Objects;

namespace TnmsExtendableTargeting.Shared;

public interface ITargetingResult
{
    /// <summary>
    /// true if only found one target, otherwise false.
    /// </summary>
    public bool IsSingleTarget { get; }

    /// <summary>
    /// returns name of target if single target, otherwise custom target name. <br/>
    /// e.g. => console: "CONSOLE" | player: "player name" | multiple target: "Zombie", "Human", "Custom Target Name"
    /// </summary>
    /// <param name="culture">used to translating custom target name. if not specified, it will use en-US as default culture</param>
    /// <returns></returns>
    public string GetTargetName(CultureInfo? culture = null);
    
    /// <summary>
    /// Results of target
    /// </summary>
    /// <returns></returns>
    public List<IGameClient> GetTargets();
}