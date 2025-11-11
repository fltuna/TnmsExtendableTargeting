using System;
using System.Globalization;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting.BuiltinTargets.SpecialImpl;

public class NameContainedPlayer: ICustomParameterizedTarget
{
    public string Prefix => "";
    
    public string LocalizedTargetName(CultureInfo culture)
        => throw new InvalidOperationException("This target is not supports translation.");

    public bool Resolve(string param, IGameClient targetClient, IGameClient? caller)
    {
        return targetClient.Name.Contains(param, StringComparison.OrdinalIgnoreCase);
    }
}