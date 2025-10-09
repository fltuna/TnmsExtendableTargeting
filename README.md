# [TnmsExtendableTargeting](https://github.com/fltuna/TnmsExtendableTargeting)

## What is this?

This module provides extendable targeting functionality.

It offers the following types of targeting:

- `@prefix` - Target without parameters
- `@prefix=value` - Target with parameters

## Built-in Targets

The following targeting options are provided out of the box:

| Target String | Description                             | Example    |
|---------------|-----------------------------------------|------------|
| `@me`         | Targets yourself.                       | `@me`      |
| `@!me`        | Targets everyone except yourself.       | `@!me`     |
| `@aim`        | Targets the player you are aiming at.   | `@aim`     |
| `@ct`         | Targets players on the CT team.         | `@ct`      |
| `@t`          | Targets players on the T team.          | `@t`       |
| `@spec`       | Targets spectators.                     | `@spec`    |
| `@bot`        | Targets bot players.                    | `@bot`     |
| `@human`      | Targets human players.                  | `@human`   |
| `@alive`      | Targets alive players.                  | `@alive`   |
| `@dead`       | Targets dead players.                   | `@dead`    |
| `#<number>`   | Targets by SteamID or UserID.           | `#12345`   |

## Usage

### Dependencies

Install `TnmsExtendableTargeting.Shared` from NuGet:

```shell
dotnet add package TnmsExtendableTargeting.Shared
```

### Example

You can obtain `IExtendableTargeting` as follows:

```csharp
private IExtendableTargeting _extendableTargeting = null!;

public void OnAllModulesLoaded()
{
    var extendableTargeting = _sharedSystem.GetSharpModuleManager()
        .GetRequiredSharpModuleInterface<IExtendableTargeting>(IExtendableTargeting.ModSharpModuleIdentity).Instance;
    _extendableTargeting = extendableTargeting ?? throw new InvalidOperationException("TnmsExtendableTargeting is not found! Make sure TnmsExtendableTargeting is installed!");
}
```

Then, resolve targets as follows:

```csharp
if(_extendableTargeting.ResolveTarget(targetString, player, out var foundTargets))
{
    // Do something with foundTargets
}
```

## Creating Custom Targets

As the name suggests, ExtendableTargeting allows you to add and extend custom targets.

Once added, custom targets can be used anywhere `IExtendableTargeting.ResolveTarget` is used. In other words, they are available in all modules that use this functionality.

### Custom Targets Without Parameters

Register a custom target without parameters using `IExtendableTargeting.RegisterCustomTarget`.

The prefix must start with `@`. If it does not, `@` will be automatically prepended.

Examples:
- `@mytarget` -> `@mytarget`
- `mytarget` -> `@mytarget`
- `$mytarget` -> `@$mytarget`

```csharp
IExtendableTargeting.RegisterCustomTarget("@me", Me);

public static bool Me(IGameClient targetClient, IGameClient? caller)
{
    return caller?.Slot == targetClient.Slot;
}
```

### Custom Targets With Parameters

Register a custom target with parameters using `IExtendableTargeting.RegisterCustomTargetWithParam`.

The prefix must start with `@`. If it does not, `@` will be automatically prepended.

Examples:
- `@mytarget` -> `@mytarget`
- `mytarget` -> `@mytarget`
- `$mytarget` -> `@$mytarget`

```csharp
IExtendableTargeting.RegisterCustomTargetWithParam("@slot", Slot);
public static bool Slot(string param, IGameClient targetClient, IGameClient? caller)
{
    if(int.TryParse(param, out var slot))
    {
        return targetClient.Slot == slot;
    }
    return false;
}
```

Custom targets with parameters can be used in the form `@prefix=value`.
