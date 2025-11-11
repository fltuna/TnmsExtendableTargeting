using System.Collections.Generic;
using Sharp.Shared.Objects;

namespace TnmsExtendableTargeting.Shared;

public interface IExtendableTargeting
{
    public const string ModSharpModuleIdentity = "TnmsExtendableTargeting";
    
    // Register custom target
    /// <summary>
    /// Register custom single targeting
    /// </summary>
    /// <param name="predicate"></param>
    public void RegisterCustomSingleTarget(ICustomSingleTarget predicate);
     
    /// <summary>
    /// Unregister custom single target from extended targeting
    /// </summary>
    /// <param name="prefix">prefix of targeting</param>
    /// <returns>true if deleted successfully, otherwise false</returns>
    public bool UnregisterCustomSingleTarget(string prefix);
    
    // Register custom target
    /// <summary>
    /// Register custom targeting
    /// </summary>
    /// <param name="predicate"></param>
    public void RegisterCustomTarget(ICustomTarget predicate);
     
    /// <summary>
    /// Unregister custom target from extended targeting
    /// </summary>
    /// <param name="prefix">prefix of targeting</param>
    /// <returns>true if deleted successfully, otherwise false</returns>
    public bool UnregisterCustomTarget(string prefix);
     
     // Register parameterized target
     /// <summary>
     /// Registers a custom parameterized targeting
     /// </summary>
     /// <param name="predicate"></param>
     public void RegisterCustomParameterizedTarget(ICustomParameterizedTarget predicate);
     
     /// <summary>
     /// Unregister custom parameterized target from extended targeting
     /// </summary>
     /// <param name="prefix">prefix of targeting</param>
     /// <returns>true if deleted successfully, otherwise false</returns>
     public bool UnregisterCustomParameterizedTarget(string prefix);

     /// <summary>
     /// Resolve extended targeting.
     /// </summary>
     /// <param name="targetString">Target string for finding targets</param>
     /// <param name="caller"></param>
     /// <param name="foundTargets">Returns filled TargetResult if found, otherwise empty TargetReuslt</param>
     /// <returns>true if at least 1 player found. otherwise false</returns>
     public bool ResolveTarget(string targetString, IGameClient? caller, out ITargetingResult? foundTargets);
}