using System;
using System.Globalization;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting.BuiltinTargets;

public class Me: ICustomSingleTarget
{
    public string Prefix => "@me";
    
    public string LocalizedTargetName(CultureInfo culture) 
        => throw new InvalidOperationException("This target is not supports translation.");

    public IGameClient? Resolve(IGameClient? caller)
        => caller;
}