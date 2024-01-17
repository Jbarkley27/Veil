using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioLibrary
{
    public static string Test = "event:/TestEvent";
    public static string Dash = "event:/Player/Dash";
    public static string ZoomIn = "event:/Player/Focus In";
    public static string ZoomOut = "event:/Player/Focus Out";
    public static string Jump = "event:/Player/Jump";
    public static string Lock = "event:/Player/Lock";
    public static string Unlock = "event:/Player/Unlock";
    public static string Recharged = "event:/Player/DashRecharged";
    public static string SwapBlasters = "event:/Player/Swap Blasters";
    public static string Damaged = "event:/Player/Damaged";
    public static string InitiateThruster = "event:/Player/InitiateThruster";
    public static string Thrusting = "event:/Player/Thrusting";

    // Blasters ----------------------------------------------------------------
    public enum WeaponSound { Weapon_A, PHOTON_RAVENGER, CHRONO_CANNON, DISRUPTOR, ION_FLUX, SONIC_CARBINE, NEUTRON_BLASTER };
    private static readonly Dictionary<WeaponSound, string> WeaponAudioLibrary = new Dictionary<WeaponSound, string>
    {
        { WeaponSound.Weapon_A,  "event:/Player/Lock"},
        { WeaponSound.PHOTON_RAVENGER, "event:/Blasters/Photon Ravenger" },
        { WeaponSound.CHRONO_CANNON, "event:/Blasters/Chrono Cannon"},
        { WeaponSound.DISRUPTOR, "event:/Blasters/Disruptor" },
        { WeaponSound.ION_FLUX, "event:/Blasters/Ion Flux"},
        { WeaponSound.SONIC_CARBINE, "event:/Blasters/Sonic Carbine"},
        { WeaponSound.NEUTRON_BLASTER, "event:/Blasters/Neutron Blaster"}
    };

    public static string GetWeaponSound(WeaponSound weapon)
    {
        return WeaponAudioLibrary[weapon];
    }


    // UI ----------------------------------------------------------------------
    public static string Hover = "event:/UI/Hover";
    public static string Select = "event:/UI/Select";
    public static string Console = "event:/UI/Console";
    public static string Equip = "event:/UI/Equip";
    public static string Unequip = "event:/UI/Unequip";
    public static string OpenInventory = "event:/UI/Open Inventory";
    public static string CloseInventory = "event:/UI/Close Inventory";


}
