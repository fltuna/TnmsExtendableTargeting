using System.Collections.Generic;
using System.Globalization;
using Sharp.Shared;
using Sharp.Shared.Enums;
using Sharp.Shared.Objects;
using TnmsExtendableTargeting.Shared;

namespace TnmsExtendableTargeting.BuiltinTargets;

public class Te: ICustomTarget
{
    private static readonly Dictionary<string, string> LangMap = new();

    static Te()
    {
        LangMap["en"] = "Terrorists";
        LangMap["ja"] = "テロリスト";
    }
    
    public string Prefix => "@t";
    
    public string LocalizedTargetName(CultureInfo culture)
    {
        if (LangMap.TryGetValue(culture.TwoLetterISOLanguageName, out var lang))
            return lang;
        
        return Prefix;
    }

    public bool Resolve(IGameClient targetClient, IGameClient? caller)
    {
        return targetClient.GetPlayerController()?.GetPlayerPawn()?.Team == CStrikeTeam.TE;
    }
}