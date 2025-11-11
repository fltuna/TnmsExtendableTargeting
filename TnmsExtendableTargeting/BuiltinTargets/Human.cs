using System.Collections.Generic;
using System.Globalization;
using Sharp.Shared;
using Sharp.Shared.Enums;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting.BuiltinTargets;

public class Human: ICustomTarget
{
    private static readonly Dictionary<string, string> LangMap = new();

    static Human()
    {
        LangMap["en"] = "Human";
        LangMap["ja"] = "人間";
    }
    
    public string Prefix => "@human";
    
    public string LocalizedTargetName(CultureInfo culture)
    {
        if (LangMap.TryGetValue(culture.TwoLetterISOLanguageName, out var lang))
            return lang;
        
        return Prefix;
    }

    public bool Resolve(IGameClient targetClient, IGameClient? caller)
    {
        return !targetClient.IsFakeClient;
    }
}