using System.Collections.Generic;
using System.Globalization;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting.BuiltinTargets;

public class All: ICustomTarget
{
    private static readonly Dictionary<string, string> LangMap = new();

    static All()
    {
        LangMap["en"] = "All Players";
        LangMap["ja"] = "全てのプレイヤー";
    }
    
    public string Prefix => "@all";
    
    public string LocalizedTargetName(CultureInfo culture)
    {
        if (LangMap.TryGetValue(culture.TwoLetterISOLanguageName, out var lang))
            return lang;
        
        return Prefix;
    }

    public bool Resolve(IGameClient targetClient, IGameClient? caller)
        => true;
}