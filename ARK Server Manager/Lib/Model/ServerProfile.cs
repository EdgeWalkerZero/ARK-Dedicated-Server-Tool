﻿using ARK_Server_Manager.Lib.Serialization;
using ARK_Server_Manager.Lib.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml;
using System.Xml.Serialization;

namespace ARK_Server_Manager.Lib
{
    public interface ISettingsBag
    {
        object this[string propertyName] { get; set; }
    }

    [XmlRoot("ArkServerProfile")]
    [Serializable()]
    public class ServerProfile : DependencyObject
    {
        public static readonly DependencyProperty ProfileNameProperty = DependencyProperty.Register(nameof(ProfileName), typeof(string), typeof(ServerProfile), new PropertyMetadata(Config.Default.DefaultServerProfileName));
        public static readonly DependencyProperty InstallDirectoryProperty = DependencyProperty.Register(nameof(InstallDirectory), typeof(string), typeof(ServerProfile), new PropertyMetadata(String.Empty));
        public static readonly DependencyProperty LastInstalledVersionProperty = DependencyProperty.Register(nameof(LastInstalledVersion), typeof(string), typeof(ServerProfile), new PropertyMetadata(String.Empty));
        public static readonly DependencyProperty AdditionalArgsProperty = DependencyProperty.Register(nameof(AdditionalArgs), typeof(string), typeof(ServerProfile), new PropertyMetadata(String.Empty));
        public static readonly DependencyProperty RCONEnabledProperty = DependencyProperty.Register(nameof(RCONEnabled), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty RCONPortProperty = DependencyProperty.Register(nameof(RCONPort), typeof(int), typeof(ServerProfile), new PropertyMetadata(32330));
        public static readonly DependencyProperty ServerMapProperty = DependencyProperty.Register(nameof(ServerMap), typeof(string), typeof(ServerProfile), new PropertyMetadata(Config.Default.DefaultServerMap));

        public string ProfileName
        {
            get { return (string)GetValue(ProfileNameProperty); }
            set { SetValue(ProfileNameProperty, value); }
        }

        public string InstallDirectory
        {
            get { return (string)GetValue(InstallDirectoryProperty); }
            set { SetValue(InstallDirectoryProperty, value); }
        }

        public string LastInstalledVersion
        {
            get { return (string)GetValue(LastInstalledVersionProperty); }
            set { SetValue(LastInstalledVersionProperty, value); }
        }

        public string AdditionalArgs
        {
            get { return (string)GetValue(AdditionalArgsProperty); }
            set { SetValue(AdditionalArgsProperty, value); }
        }

        public bool RCONEnabled
        {
            get { return (bool)GetValue(RCONEnabledProperty); }
            set { SetValue(RCONEnabledProperty, value); }
        }

        public int RCONPort
        {
            get { return (int)GetValue(RCONPortProperty); }
            set { SetValue(RCONPortProperty, value); }
        }

        public string ServerMap
        {
            get { return (string)GetValue(ServerMapProperty); }
            set { SetValue(ServerMapProperty, value); }
        }

        #region Server properties

        public static readonly DependencyProperty EnableGlobalVoiceChatProperty = DependencyProperty.Register(nameof(EnableGlobalVoiceChat), typeof(bool), typeof(ServerProfile), new PropertyMetadata(true));
        public static readonly DependencyProperty EnableProximityChatProperty = DependencyProperty.Register(nameof(EnableProximityChat), typeof(bool), typeof(ServerProfile), new PropertyMetadata(true));
        public static readonly DependencyProperty EnableTributeDownloadsProperty = DependencyProperty.Register(nameof(EnableTributeDownloads), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty EnableFlyerCarryProperty = DependencyProperty.Register(nameof(EnableFlyerCarry), typeof(bool), typeof(ServerProfile), new PropertyMetadata(true));
        public static readonly DependencyProperty EnableStructureDecayProperty = DependencyProperty.Register(nameof(EnableStructureDecay), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty EnablePlayerLeaveNotificationsProperty = DependencyProperty.Register(nameof(EnablePlayerLeaveNotifications), typeof(bool), typeof(ServerProfile), new PropertyMetadata(true));
        public static readonly DependencyProperty EnablePlayerJoinedNotificationsProperty = DependencyProperty.Register(nameof(EnablePlayerJoinedNotifications), typeof(bool), typeof(ServerProfile), new PropertyMetadata(true));
        public static readonly DependencyProperty EnableHardcoreProperty = DependencyProperty.Register(nameof(EnableHardcore), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty EnablePVPProperty = DependencyProperty.Register(nameof(EnablePVP), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty AllowCrosshairProperty = DependencyProperty.Register(nameof(AllowCrosshair), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty AllowHUDProperty = DependencyProperty.Register(nameof(AllowHUD), typeof(bool), typeof(ServerProfile), new PropertyMetadata(true));
        public static readonly DependencyProperty AllowThirdPersonViewProperty = DependencyProperty.Register(nameof(AllowThirdPersonView), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty AllowMapPlayerLocationProperty = DependencyProperty.Register(nameof(AllowMapPlayerLocation), typeof(bool), typeof(ServerProfile), new PropertyMetadata(true));
        public static readonly DependencyProperty AllowPVPGammaProperty = DependencyProperty.Register(nameof(AllowPVPGamma), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty ServerPasswordProperty = DependencyProperty.Register(nameof(ServerPassword), typeof(string), typeof(ServerProfile), new PropertyMetadata(String.Empty));
        public static readonly DependencyProperty AdminPasswordProperty = DependencyProperty.Register(nameof(AdminPassword), typeof(string), typeof(ServerProfile), new PropertyMetadata(String.Empty));
        public static readonly DependencyProperty MaxPlayersProperty = DependencyProperty.Register(nameof(MaxPlayers), typeof(int), typeof(ServerProfile), new PropertyMetadata(5));
        public static readonly DependencyProperty DifficultyOffsetProperty = DependencyProperty.Register(nameof(DifficultyOffset), typeof(float), typeof(ServerProfile), new PropertyMetadata(0.25f));
        public static readonly DependencyProperty MaxStructuresVisibleProperty = DependencyProperty.Register(nameof(MaxStructuresVisible), typeof(float), typeof(ServerProfile), new PropertyMetadata(1300f));
        public static readonly DependencyProperty ServerNameProperty = DependencyProperty.Register(nameof(ServerName), typeof(string), typeof(ServerProfile), new PropertyMetadata(Config.Default.DefaultServerName));
        public static readonly DependencyProperty ServerPortProperty = DependencyProperty.Register(nameof(ServerPort), typeof(int), typeof(ServerProfile), new PropertyMetadata(27015));
        public static readonly DependencyProperty ServerConnectionPortProperty = DependencyProperty.Register(nameof(ServerConnectionPort), typeof(int), typeof(ServerProfile), new PropertyMetadata(7777));
        public static readonly DependencyProperty ServerIPProperty = DependencyProperty.Register(nameof(ServerIP), typeof(string), typeof(ServerProfile), new PropertyMetadata(String.Empty));
        public static readonly DependencyProperty MOTDProperty = DependencyProperty.Register(nameof(MOTD), typeof(string), typeof(ServerProfile), new PropertyMetadata(String.Empty));
        public static readonly DependencyProperty MOTDDurationProperty = DependencyProperty.Register(nameof(MOTDDuration), typeof(int), typeof(ServerProfile), new PropertyMetadata(20));
        public static readonly DependencyProperty EnableKickIdlePlayersProperty = DependencyProperty.Register(nameof(EnableKickIdlePlayers), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty KickIdlePlayersPeriodProperty = DependencyProperty.Register(nameof(KickIdlePlayersPeriod), typeof(float), typeof(ServerProfile), new PropertyMetadata(2400.0f));
        public static readonly DependencyProperty AutoSavePeriodMinutesProperty = DependencyProperty.Register(nameof(AutoSavePeriodMinutes), typeof(float), typeof(ServerProfile), new PropertyMetadata(15.0f));
        public static readonly DependencyProperty TamingSpeedMultiplierProperty = DependencyProperty.Register(nameof(TamingSpeedMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty HarvestAmountMultiplierProperty = DependencyProperty.Register(nameof(HarvestAmountMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty PlayerCharacterWaterDrainMultiplierProperty = DependencyProperty.Register(nameof(PlayerCharacterWaterDrainMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty PlayerCharacterFoodDrainMultiplierProperty = DependencyProperty.Register(nameof(PlayerCharacterFoodDrainMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty DinoCharacterFoodDrainMultiplierProperty = DependencyProperty.Register(nameof(DinoCharacterFoodDrainMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty PlayerCharacterStaminaDrainMultiplierProperty = DependencyProperty.Register(nameof(PlayerCharacterStaminaDrainMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty DinoCharacterStaminaDrainMultiplierProperty = DependencyProperty.Register(nameof(DinoCharacterStaminaDrainMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty PlayerCharacterHealthRecoveryMultiplierProperty = DependencyProperty.Register(nameof(PlayerCharacterHealthRecoveryMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty DinoCharacterHealthRecoveryMultiplierProperty = DependencyProperty.Register(nameof(DinoCharacterHealthRecoveryMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty DinoCountMultiplierProperty = DependencyProperty.Register(nameof(DinoCountMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty HarvestHealthMultiplierProperty = DependencyProperty.Register(nameof(HarvestHealthMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty PvEStructureDecayDestructionPeriodProperty = DependencyProperty.Register(nameof(PvEStructureDecayDestructionPeriod), typeof(float), typeof(ServerProfile), new PropertyMetadata(0f));
        public static readonly DependencyProperty PvEStructureDecayPeriodMultiplierProperty = DependencyProperty.Register(nameof(PvEStructureDecayPeriodMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty ResourcesRespawnPeriodMultiplierProperty = DependencyProperty.Register(nameof(ResourcesRespawnPeriodMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty ClampResourceHarvestDamageProperty = DependencyProperty.Register(nameof(ClampResourceHarvestDamage), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty DayCycleSpeedScaleProperty = DependencyProperty.Register(nameof(DayCycleSpeedScale), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty NightTimeSpeedScaleProperty = DependencyProperty.Register(nameof(NightTimeSpeedScale), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty DayTimeSpeedScaleProperty = DependencyProperty.Register(nameof(DayTimeSpeedScale), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty DinoDamageMultiplierProperty = DependencyProperty.Register(nameof(DinoDamageMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty TamedDinoDamageMultiplierProperty = DependencyProperty.Register(nameof(TamedDinoDamageMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty PlayerDamageMultiplierProperty = DependencyProperty.Register(nameof(PlayerDamageMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty StructureDamageMultiplierProperty = DependencyProperty.Register(nameof(StructureDamageMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty PlayerResistanceMultiplierProperty = DependencyProperty.Register(nameof(PlayerResistanceMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty DinoResistanceMultiplierProperty = DependencyProperty.Register(nameof(DinoResistanceMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty TamedDinoResistanceMultiplierProperty = DependencyProperty.Register(nameof(TamedDinoResistanceMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty StructureResistanceMultiplierProperty = DependencyProperty.Register(nameof(StructureResistanceMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty XPMultiplierProperty = DependencyProperty.Register(nameof(XPMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty DinoSpawnsProperty = DependencyProperty.Register(nameof(DinoSpawnWeightMultipliers), typeof(AggregateIniValueList<DinoSpawn>), typeof(ServerProfile), new PropertyMetadata(null));
        public static readonly DependencyProperty EnableLevelProgressionsProperty = DependencyProperty.Register(nameof(EnableLevelProgressions), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty PlayerLevelsProperty = DependencyProperty.Register(nameof(PlayerLevels), typeof(LevelList), typeof(ServerProfile), new PropertyMetadata());
        public static readonly DependencyProperty DinoLevelsProperty = DependencyProperty.Register(nameof(DinoLevels), typeof(LevelList), typeof(ServerProfile), new PropertyMetadata());
        public static readonly DependencyProperty IsDirtyProperty = DependencyProperty.Register(nameof(IsDirty), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));
        public static readonly DependencyProperty GlobalSpoilingTimeMultiplierProperty = DependencyProperty.Register(nameof(GlobalSpoilingTimeMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty GlobalCorpseDecompositionTimeMultiplierProperty = DependencyProperty.Register(nameof(GlobalCorpseDecompositionTimeMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));
        public static readonly DependencyProperty OverrideMaxExperiencePointsDinoProperty = DependencyProperty.Register(nameof(OverrideMaxExperiencePointsDino), typeof(int), typeof(ServerProfile), new PropertyMetadata(100000));
        public static readonly DependencyProperty OverrideMaxExperiencePointsPlayerProperty = DependencyProperty.Register(nameof(OverrideMaxExperiencePointsPlayer), typeof(int), typeof(ServerProfile), new PropertyMetadata(100000));
        public static readonly DependencyProperty GlobalItemDecompositionTimeMultiplierProperty = DependencyProperty.Register(nameof(GlobalItemDecompositionTimeMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "GlobalVoiceChat")]
        public bool EnableGlobalVoiceChat
        {
            get { return (bool)GetValue(EnableGlobalVoiceChatProperty); }
            set { SetValue(EnableGlobalVoiceChatProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "ProximityVoiceChat")]
        public bool EnableProximityChat
        {
            get { return (bool)GetValue(EnableProximityChatProperty); }
            set { SetValue(EnableProximityChatProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "NoTributeDownloads", InvertBoolean = true)]
        public bool EnableTributeDownloads
        {
            get { return (bool)GetValue(EnableTributeDownloadsProperty); }
            set { SetValue(EnableTributeDownloadsProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "bAllowFlyerCarryPVE")]
        public bool EnableFlyerCarry
        {
            get { return (bool)GetValue(EnableFlyerCarryProperty); }
            set { SetValue(EnableFlyerCarryProperty, value); }
        }


        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public bool AllowCaveBuildingPvE
        {
            get { return (bool)GetValue(AllowCaveBuildingPvEProperty); }
            set { SetValue(AllowCaveBuildingPvEProperty, value); }
        }

        public static readonly DependencyProperty AllowCaveBuildingPvEProperty = DependencyProperty.Register(nameof(AllowCaveBuildingPvE), typeof(bool), typeof(ServerProfile), new PropertyMetadata(true));


        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "bDisableStructureDecayPVE", InvertBoolean = true)]
        public bool EnableStructureDecay
        {
            get { return (bool)GetValue(EnableStructureDecayProperty); }
            set { SetValue(EnableStructureDecayProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "AlwaysNotifyPlayerLeft")]
        public bool EnablePlayerLeaveNotifications
        {
            get { return (bool)GetValue(EnablePlayerLeaveNotificationsProperty); }
            set { SetValue(EnablePlayerLeaveNotificationsProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "DontAlwaysNotifyPlayerJoined", InvertBoolean = true)]
        public bool EnablePlayerJoinedNotifications
        {
            get { return (bool)GetValue(EnablePlayerJoinedNotificationsProperty); }
            set { SetValue(EnablePlayerJoinedNotificationsProperty, value); }
        }
        
        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "ServerHardcore")]        
        public bool EnableHardcore
        {
            get { return (bool)GetValue(EnableHardcoreProperty); }
            set { SetValue(EnableHardcoreProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "ServerPVE", InvertBoolean = true)]
        public bool EnablePVP
        {
            get { return (bool)GetValue(EnablePVPProperty); }
            set { SetValue(EnablePVPProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "ServerCrosshair")]
        public bool AllowCrosshair
        {
            get { return (bool)GetValue(AllowCrosshairProperty); }
            set { SetValue(AllowCrosshairProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "ServerForceNoHud", InvertBoolean = true)]
        public bool AllowHUD
        {
            get { return (bool)GetValue(AllowHUDProperty); }
            set { SetValue(AllowHUDProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "AllowThirdPersonPlayer")]
        public bool AllowThirdPersonView
        {
            get { return (bool)GetValue(AllowThirdPersonViewProperty); }
            set { SetValue(AllowThirdPersonViewProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "ShowMapPlayerLocation")]
        public bool AllowMapPlayerLocation
        {
            get { return (bool)GetValue(AllowMapPlayerLocationProperty); }
            set { SetValue(AllowMapPlayerLocationProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "EnablePVPGamma")]
        public bool AllowPVPGamma
        {
            get { return (bool)GetValue(AllowPVPGammaProperty); }
            set { SetValue(AllowPVPGammaProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "ServerPassword")]        
        public string ServerPassword
        {
            get { return (string)GetValue(ServerPasswordProperty); }
            set { SetValue(ServerPasswordProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "ServerAdminPassword")]
        public string AdminPassword
        {
            get { return (string)GetValue(AdminPasswordProperty); }
            set { SetValue(AdminPasswordProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.GameSession, "MaxPlayers")]        
        public int MaxPlayers
        {
            get { return (int)GetValue(MaxPlayersProperty); }
            set { SetValue(MaxPlayersProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "DifficultyOffset")]
        public float DifficultyOffset
        {
            get { return (float)GetValue(DifficultyOffsetProperty); }
            set { SetValue(DifficultyOffsetProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, "MaxStructuresInRange")]
        public float MaxStructuresVisible
        {
            get { return (float)GetValue(MaxStructuresVisibleProperty); }
            set { SetValue(MaxStructuresVisibleProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.SessionSettings, "SessionName")]  
        public string ServerName
        {
            get { return (string)GetValue(ServerNameProperty); }
            set { SetValue(ServerNameProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.SessionSettings, "QueryPort")]
        public int ServerPort
        {
            get { return (int)GetValue(ServerPortProperty); }
            set { SetValue(ServerPortProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.SessionSettings, "Port")]
        public int ServerConnectionPort
        {
            get { return (int)GetValue(ServerConnectionPortProperty); }
            set { SetValue(ServerConnectionPortProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.SessionSettings, "MultiHome")]
        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.MultiHome, "MultiHome", WriteBoolValueIfNonEmpty = true)]
        public string ServerIP
        {
            get { return (string)GetValue(ServerIPProperty); }
            set { SetValue(ServerIPProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.MessageOfTheDay, "Message", ClearSection = true)]
        public string MOTD
        {
            get { return (string)GetValue(MOTDProperty); }
            set { SetValue(MOTDProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.MessageOfTheDay, "Duration")]
        public int MOTDDuration
        {
            get { return (int)GetValue(MOTDDurationProperty); }
            set { SetValue(MOTDDurationProperty, value); }
        }

        public bool EnableKickIdlePlayers
        {
            get { return (bool)GetValue(EnableKickIdlePlayersProperty); }
            set { SetValue(EnableKickIdlePlayersProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings, ConditionedOn = nameof(EnableKickIdlePlayers))]
        public float KickIdlePlayersPeriod
        {
            get { return (float)GetValue(KickIdlePlayersPeriodProperty); }
            set { SetValue(KickIdlePlayersPeriodProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float AutoSavePeriodMinutes
        {
            get { return (float)GetValue(AutoSavePeriodMinutesProperty); }
            set { SetValue(AutoSavePeriodMinutesProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float TamingSpeedMultiplier
        {
            get { return (float)GetValue(TamingSpeedMultiplierProperty); }
            set { SetValue(TamingSpeedMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float HarvestAmountMultiplier
        {
            get { return (float)GetValue(HarvestAmountMultiplierProperty); }
            set { SetValue(HarvestAmountMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float PlayerCharacterWaterDrainMultiplier
        {
            get { return (float)GetValue(PlayerCharacterWaterDrainMultiplierProperty); }
            set { SetValue(PlayerCharacterWaterDrainMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float PlayerCharacterFoodDrainMultiplier
        {
            get { return (float)GetValue(PlayerCharacterFoodDrainMultiplierProperty); }
            set { SetValue(PlayerCharacterFoodDrainMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float DinoCharacterFoodDrainMultiplier
        {
            get { return (float)GetValue(DinoCharacterFoodDrainMultiplierProperty); }
            set { SetValue(DinoCharacterFoodDrainMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float PlayerCharacterStaminaDrainMultiplier
        {
            get { return (float)GetValue(PlayerCharacterStaminaDrainMultiplierProperty); }
            set { SetValue(PlayerCharacterStaminaDrainMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float DinoCharacterStaminaDrainMultiplier
        {
            get { return (float)GetValue(DinoCharacterStaminaDrainMultiplierProperty); }
            set { SetValue(DinoCharacterStaminaDrainMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float PlayerCharacterHealthRecoveryMultiplier
        {
            get { return (float)GetValue(PlayerCharacterHealthRecoveryMultiplierProperty); }
            set { SetValue(PlayerCharacterHealthRecoveryMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float DinoCharacterHealthRecoveryMultiplier
        {
            get { return (float)GetValue(DinoCharacterHealthRecoveryMultiplierProperty); }
            set { SetValue(DinoCharacterHealthRecoveryMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float DinoCountMultiplier
        {
            get { return (float)GetValue(DinoCountMultiplierProperty); }
            set { SetValue(DinoCountMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float HarvestHealthMultiplier
        {
            get { return (float)GetValue(HarvestHealthMultiplierProperty); }
            set { SetValue(HarvestHealthMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float PvEStructureDecayDestructionPeriod
        {
            get { return (float)GetValue(PvEStructureDecayDestructionPeriodProperty); }
            set { SetValue(PvEStructureDecayDestructionPeriodProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float PvEStructureDecayPeriodMultiplier
        {
            get { return (float)GetValue(PvEStructureDecayPeriodMultiplierProperty); }
            set { SetValue(PvEStructureDecayPeriodMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float ResourcesRespawnPeriodMultiplier
        {
            get { return (float)GetValue(ResourcesRespawnPeriodMultiplierProperty); }
            set { SetValue(ResourcesRespawnPeriodMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public bool ClampResourceHarvestDamage
        {
            get { return (bool)GetValue(ClampResourceHarvestDamageProperty); }
            set { SetValue(ClampResourceHarvestDamageProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float DayCycleSpeedScale
        {
            get { return (float)GetValue(DayCycleSpeedScaleProperty); }
            set { SetValue(DayCycleSpeedScaleProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float NightTimeSpeedScale
        {
            get { return (float)GetValue(NightTimeSpeedScaleProperty); }
            set { SetValue(NightTimeSpeedScaleProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float DayTimeSpeedScale
        {
            get { return (float)GetValue(DayTimeSpeedScaleProperty); }
            set { SetValue(DayTimeSpeedScaleProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float DinoDamageMultiplier
        {
            get { return (float)GetValue(DinoDamageMultiplierProperty); }
            set { SetValue(DinoDamageMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float TamedDinoDamageMultiplier
        {
            get { return (float)GetValue(TamedDinoDamageMultiplierProperty); }
            set { SetValue(TamedDinoDamageMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float PlayerDamageMultiplier
        {
            get { return (float)GetValue(PlayerDamageMultiplierProperty); }
            set { SetValue(PlayerDamageMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float StructureDamageMultiplier
        {
            get { return (float)GetValue(StructureDamageMultiplierProperty); }
            set { SetValue(StructureDamageMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float PlayerResistanceMultiplier
        {
            get { return (float)GetValue(PlayerResistanceMultiplierProperty); }
            set { SetValue(PlayerResistanceMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float DinoResistanceMultiplier
        {
            get { return (float)GetValue(DinoResistanceMultiplierProperty); }
            set { SetValue(DinoResistanceMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float TamedDinoResistanceMultiplier
        {
            get { return (float)GetValue(TamedDinoResistanceMultiplierProperty); }
            set { SetValue(TamedDinoResistanceMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float StructureResistanceMultiplier
        {
            get { return (float)GetValue(StructureResistanceMultiplierProperty); }
            set { SetValue(StructureResistanceMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public float PvPZoneStructureDamageMultiplier
        {
            get { return (float)GetValue(PvPZoneStructureDamageMultiplierProperty); }
            set { SetValue(PvPZoneStructureDamageMultiplierProperty, value); }
        }

        public static readonly DependencyProperty PvPZoneStructureDamageMultiplierProperty = DependencyProperty.Register(nameof(PvPZoneStructureDamageMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(6.0f));


        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public bool PreventDownloadSurvivors
        {
            get { return (bool)GetValue(PreventDownloadSurvivorsProperty); }
            set { SetValue(PreventDownloadSurvivorsProperty, value); }
        }

        public static readonly DependencyProperty PreventDownloadSurvivorsProperty = DependencyProperty.Register(nameof(PreventDownloadSurvivors), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));



        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public bool PreventDownloadItems
        {
            get { return (bool)GetValue(PreventDownloadItemsProperty); }
            set { SetValue(PreventDownloadItemsProperty, value); }
        }

        public static readonly DependencyProperty PreventDownloadItemsProperty = DependencyProperty.Register(nameof(PreventDownloadItems), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));



        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public bool PreventDownloadDinos
        {
            get { return (bool)GetValue(PreventDownloadDinosProperty); }
            set { SetValue(PreventDownloadDinosProperty, value); }
        }

        public static readonly DependencyProperty PreventDownloadDinosProperty = DependencyProperty.Register(nameof(PreventDownloadDinos), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));


        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public float XPMultiplier
        {
            get { return (float)GetValue(XPMultiplierProperty); }
            set { SetValue(XPMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public float GlobalSpoilingTimeMultiplier
        {
            get { return (float)GetValue(GlobalSpoilingTimeMultiplierProperty); }
            set { SetValue(GlobalSpoilingTimeMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public float GlobalItemDecompositionTimeMultiplier
        {
            get { return (float)GetValue(GlobalItemDecompositionTimeMultiplierProperty); }
            set { SetValue(GlobalItemDecompositionTimeMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public float GlobalCorpseDecompositionTimeMultiplier
        {
            get { return (float)GetValue(GlobalCorpseDecompositionTimeMultiplierProperty); }
            set { SetValue(GlobalCorpseDecompositionTimeMultiplierProperty, value); }
        }

        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public int OverrideMaxExperiencePointsPlayer
        {
            get { return (int)GetValue(OverrideMaxExperiencePointsPlayerProperty); }
            set { SetValue(OverrideMaxExperiencePointsPlayerProperty, value); }
        }

        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public int OverrideMaxExperiencePointsDino
        {
            get { return (int)GetValue(OverrideMaxExperiencePointsDinoProperty); }
            set { SetValue(OverrideMaxExperiencePointsDinoProperty, value); }
        }


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public float ResourceNoReplenishRadiusPlayers
        {
            get { return (float)GetValue(ResourceNoReplenishRadiusPlayersProperty); }
            set { SetValue(ResourceNoReplenishRadiusPlayersProperty, value); }
        }

        public static readonly DependencyProperty ResourceNoReplenishRadiusPlayersProperty = DependencyProperty.Register(nameof(ResourceNoReplenishRadiusPlayers), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public float ResourceNoReplenishRadiusStructures
        {
            get { return (float)GetValue(ResourceNoReplenishRadiusStructuresProperty); }
            set { SetValue(ResourceNoReplenishRadiusStructuresProperty, value); }
        }

        public static readonly DependencyProperty ResourceNoReplenishRadiusStructuresProperty = DependencyProperty.Register(nameof(ResourceNoReplenishRadiusStructures), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode, Key = "bIncreasePvPRespawnInterval")]
        public bool IncreasePvPRespawnInterval
        {
            get { return (bool)GetValue(IncreasePvPRespawnIntervalProperty); }
            set { SetValue(IncreasePvPRespawnIntervalProperty, value); }
        }

        public static readonly DependencyProperty IncreasePvPRespawnIntervalProperty = DependencyProperty.Register(nameof(IncreasePvPRespawnInterval), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode, ConditionedOn = nameof(IncreasePvPRespawnInterval))]
        public int IncreasePvPRespawnIntervalCheckPeriod
        {
            get { return (int)GetValue(IncreasePvPRespawnIntervalCheckPeriodProperty); }
            set { SetValue(IncreasePvPRespawnIntervalCheckPeriodProperty, value); }
        }

        public static readonly DependencyProperty IncreasePvPRespawnIntervalCheckPeriodProperty = DependencyProperty.Register(nameof(IncreasePvPRespawnIntervalCheckPeriod), typeof(int), typeof(ServerProfile), new PropertyMetadata(300));


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode, ConditionedOn = nameof(IncreasePvPRespawnInterval))]
        public float IncreasePvPRespawnIntervalMultiplier
        {
            get { return (float)GetValue(IncreasePvPRespawnIntervalMultiplierProperty); }
            set { SetValue(IncreasePvPRespawnIntervalMultiplierProperty, value); }
        }

        public static readonly DependencyProperty IncreasePvPRespawnIntervalMultiplierProperty = DependencyProperty.Register(nameof(IncreasePvPRespawnIntervalMultiplier), typeof(float), typeof(ServerProfile), new PropertyMetadata(1.0f));


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode, ConditionedOn = nameof(IncreasePvPRespawnInterval))]
        public int IncreasePvPRespawnIntervalBaseAmount
        {
            get { return (int)GetValue(IncreasePvPRespawnIntervalBaseAmountProperty); }
            set { SetValue(IncreasePvPRespawnIntervalBaseAmountProperty, value); }
        }

        public static readonly DependencyProperty IncreasePvPRespawnIntervalBaseAmountProperty = DependencyProperty.Register(nameof(IncreasePvPRespawnIntervalBaseAmount), typeof(int), typeof(ServerProfile), new PropertyMetadata(60));


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode, Key = "bAutoPvETimer")]
        public bool AutoPvETimer
        {
            get { return (bool)GetValue(AutoPvETimerProperty); }
            set { SetValue(AutoPvETimerProperty, value); }
        }

        public static readonly DependencyProperty AutoPvETimerProperty = DependencyProperty.Register(nameof(AutoPvETimer), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode, Key = "bAutoPvEUseSystemTime", ConditionedOn = nameof(AutoPvETimer))]
        public bool AutoPvEUseSystemTime
        {
            get { return (bool)GetValue(AutoPvEUseSystemTimeProperty); }
            set { SetValue(AutoPvEUseSystemTimeProperty, value); }
        }

        public static readonly DependencyProperty AutoPvEUseSystemTimeProperty = DependencyProperty.Register(nameof(AutoPvEUseSystemTime), typeof(bool), typeof(ServerProfile), new PropertyMetadata(false));


        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode, ConditionedOn = nameof(AutoPvETimer))]
        public int AutoPvEStartTimeSeconds
        {
            get { return (int)GetValue(AutoPvEStartTimeSecondsProperty); }
            set { SetValue(AutoPvEStartTimeSecondsProperty, value); }
        }

        public static readonly DependencyProperty AutoPvEStartTimeSecondsProperty = DependencyProperty.Register(nameof(AutoPvEStartTimeSeconds), typeof(int), typeof(ServerProfile), new PropertyMetadata(0));

        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode, ConditionedOn = nameof(AutoPvETimer))]
        public int AutoPvEStopTimeSeconds
        {
            get { return (int)GetValue(AutoPvEStopTimeSecondsProperty); }
            set { SetValue(AutoPvEStopTimeSecondsProperty, value); }
        }

        public static readonly DependencyProperty AutoPvEStopTimeSecondsProperty = DependencyProperty.Register(nameof(AutoPvEStopTimeSeconds), typeof(int), typeof(ServerProfile), new PropertyMetadata(0));




        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public int MaxTamedDinos
        {
            get { return (int)GetValue(MaxTamedDinosProperty); }
            set { SetValue(MaxTamedDinosProperty, value); }
        }

        public static readonly DependencyProperty MaxTamedDinosProperty = DependencyProperty.Register(nameof(MaxTamedDinos), typeof(int), typeof(ServerProfile), new PropertyMetadata(4000));


        [IniFileEntry(IniFiles.GameUserSettings, IniFileSections.ServerSettings)]
        public string SpectatorPassword
        {
            get { return (string)GetValue(SpectatorPasswordProperty); }
            set { SetValue(SpectatorPasswordProperty, value); }
        }

        public static readonly DependencyProperty SpectatorPasswordProperty = DependencyProperty.Register(nameof(SpectatorPassword), typeof(string), typeof(ServerProfile), new PropertyMetadata(String.Empty));


        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public AggregateIniValueList<DinoSpawn> DinoSpawnWeightMultipliers
        {
            get { return (AggregateIniValueList<DinoSpawn>)GetValue(DinoSpawnsProperty); }
            set { SetValue(DinoSpawnsProperty, value); }
        }

        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]        
        public AggregateIniValueList<ClassMultiplier> TamedDinoClassDamageMultipliers
        {
            get { return (AggregateIniValueList<ClassMultiplier>)GetValue(TamedDinoClassDamageMultipliersProperty); }
            set { SetValue(TamedDinoClassDamageMultipliersProperty, value); }
        }

        public static readonly DependencyProperty TamedDinoClassDamageMultipliersProperty =
            DependencyProperty.Register(nameof(TamedDinoClassDamageMultipliers), typeof(AggregateIniValueList<ClassMultiplier>), typeof(ServerProfile), new PropertyMetadata(null));


        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public AggregateIniValueList<ClassMultiplier> TamedDinoClassResistanceMultipliers
        {
            get { return (AggregateIniValueList<ClassMultiplier>)GetValue(TamedDinoClassResistanceMultipliersProperty); }
            set { SetValue(TamedDinoClassResistanceMultipliersProperty, value); }
        }

        public static readonly DependencyProperty TamedDinoClassResistanceMultipliersProperty =
            DependencyProperty.Register(nameof(TamedDinoClassResistanceMultipliers), typeof(AggregateIniValueList<ClassMultiplier>), typeof(ServerProfile), new PropertyMetadata(null));



        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public AggregateIniValueList<ClassMultiplier> DinoClassDamageMultipliers
        {
            get { return (AggregateIniValueList<ClassMultiplier>)GetValue(DinoClassDamageMultipliersProperty); }
            set { SetValue(DinoClassDamageMultipliersProperty, value); }
        }

        public static readonly DependencyProperty DinoClassDamageMultipliersProperty =
            DependencyProperty.Register(nameof(DinoClassDamageMultipliers), typeof(AggregateIniValueList<ClassMultiplier>), typeof(ServerProfile), new PropertyMetadata(null));


        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public AggregateIniValueList<NPCReplacement> NPCReplacements
        {
            get { return (AggregateIniValueList<NPCReplacement>)GetValue(NPCReplacementsProperty); }
            set { SetValue(NPCReplacementsProperty, value); }
        }

        public static readonly DependencyProperty NPCReplacementsProperty = DependencyProperty.Register(nameof(NPCReplacements), typeof(AggregateIniValueList<NPCReplacement>), typeof(ServerProfile), new PropertyMetadata(null));

        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public AggregateIniValueList<ClassMultiplier> DinoClassResistanceMultipliers
        {
            get { return (AggregateIniValueList<ClassMultiplier>)GetValue(DinoClassResistanceMultipliersProperty); }
            set { SetValue(DinoClassResistanceMultipliersProperty, value); }
        }

        public static readonly DependencyProperty DinoClassResistanceMultipliersProperty =
            DependencyProperty.Register(nameof(DinoClassResistanceMultipliers), typeof(AggregateIniValueList<ClassMultiplier>), typeof(ServerProfile), new PropertyMetadata(null));

        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public AggregateIniValueList<ClassMultiplier> HarvestResourceItemAmountClassMultipliers
        {
            get { return (AggregateIniValueList<ClassMultiplier>)GetValue(HarvestResourceItemAmountClassMultipliersProperty); }
            set { SetValue(HarvestResourceItemAmountClassMultipliersProperty, value); }
        }

        public static readonly DependencyProperty HarvestResourceItemAmountClassMultipliersProperty =
            DependencyProperty.Register(nameof(HarvestResourceItemAmountClassMultipliers), typeof(AggregateIniValueList<ClassMultiplier>), typeof(ServerProfile), new PropertyMetadata(null));

        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public AggregateIniValueList<EngramEntry> OverrideNamedEngramEntries
        {
            get { return (AggregateIniValueList<EngramEntry>)GetValue(OverrideNamedEngramEntriesProperty); }
            set { SetValue(OverrideNamedEngramEntriesProperty, value); }
        }

        public static readonly DependencyProperty OverrideNamedEngramEntriesProperty = DependencyProperty.Register(nameof(OverrideNamedEngramEntries), typeof(AggregateIniValueList<EngramEntry>), typeof(ServerProfile), new PropertyMetadata(null));

        [XmlIgnore]
        [IniFileEntry(IniFiles.Game, IniFileSections.GameMode)]
        public StringIniValueList PreventDinoTameClassNames
        {
            get { return (StringIniValueList)GetValue(PreventDinoTameClassNamesProperty); }
            set { SetValue(PreventDinoTameClassNamesProperty, value); }
        }

        public static readonly DependencyProperty PreventDinoTameClassNamesProperty = DependencyProperty.Register(nameof(PreventDinoTameClassNames), typeof(StringIniValueList), typeof(ServerProfile), new PropertyMetadata(null));

        public bool EnableLevelProgressions
        {
            get { return (bool)GetValue(EnableLevelProgressionsProperty); }
            set { SetValue(EnableLevelProgressionsProperty, value); }
        }

        public LevelList PlayerLevels
        {
            get { return (LevelList)GetValue(PlayerLevelsProperty); }
            set { SetValue(PlayerLevelsProperty, value); }
        }

        public LevelList DinoLevels
        {
            get { return (LevelList)GetValue(DinoLevelsProperty); }
            set { SetValue(DinoLevelsProperty, value); }
        }

        [XmlIgnore]
        public DinoSettingsList DinoSettings
        {
            get { return (DinoSettingsList)GetValue(DinoSettingsProperty); }
            set { SetValue(DinoSettingsProperty, value); }
        }

        public static readonly DependencyProperty DinoSettingsProperty = DependencyProperty.Register(nameof(DinoSettings), typeof(DinoSettingsList), typeof(ServerProfile), new PropertyMetadata(null));

        #endregion

        [XmlIgnore()]
        public bool IsDirty
        {
            get { return (bool)GetValue(IsDirtyProperty); }
            set { SetValue(IsDirtyProperty, value); }
        }

        [XmlIgnore()]
        private string LastSaveLocation = String.Empty;

        private ServerProfile()
        {
            ServerPassword = PasswordUtils.GeneratePassword(16);
            AdminPassword = PasswordUtils.GeneratePassword(16);
            this.DinoSpawnWeightMultipliers = new AggregateIniValueList<DinoSpawn>(nameof(DinoSpawnWeightMultipliers), GameData.GetDinoSpawns);
            this.TamedDinoClassDamageMultipliers = new AggregateIniValueList<ClassMultiplier>(nameof(TamedDinoClassDamageMultipliers), GameData.GetStandardDinoMultipliers);
            this.TamedDinoClassResistanceMultipliers = new AggregateIniValueList<ClassMultiplier>(nameof(TamedDinoClassResistanceMultipliers), GameData.GetStandardDinoMultipliers);
            this.DinoClassDamageMultipliers = new AggregateIniValueList<ClassMultiplier>(nameof(DinoClassDamageMultipliers), GameData.GetStandardDinoMultipliers);
            this.DinoClassResistanceMultipliers = new AggregateIniValueList<ClassMultiplier>(nameof(DinoClassResistanceMultipliers), GameData.GetStandardDinoMultipliers);
            this.PreventDinoTameClassNames = new StringIniValueList(nameof(PreventDinoTameClassNames), () => new string[0] );
            this.NPCReplacements = new AggregateIniValueList<NPCReplacement>(nameof(NPCReplacements), GameData.GetNPCReplacements);
            this.HarvestResourceItemAmountClassMultipliers = new AggregateIniValueList<ClassMultiplier>(nameof(HarvestResourceItemAmountClassMultipliers), GameData.GetStandardResourceMultipliers);
            this.OverrideNamedEngramEntries = new AggregateIniValueList<EngramEntry>(nameof(OverrideNamedEngramEntries), GameData.GetStandardEngramOverrides);
            this.DinoSettings = new DinoSettingsList(this.DinoSpawnWeightMultipliers, this.PreventDinoTameClassNames, this.NPCReplacements, this.TamedDinoClassDamageMultipliers, this.TamedDinoClassResistanceMultipliers, this.DinoClassDamageMultipliers, this.DinoClassResistanceMultipliers);
            this.DinoLevels = new LevelList();
            this.PlayerLevels = new LevelList();

            GetDefaultDirectories();
        }

        public enum LevelProgression
        {
            Player,
            Dino
        };

        public void ResetLevelProgressionToDefault(LevelProgression levelProgression)
        {
            LevelList list = GetLevelList(levelProgression);

            list.Clear();
            list.AddRange(GameData.LevelProgression);
        }

        public void ClearLevelProgression(LevelProgression levelProgression)
        {
            var list = GetLevelList(levelProgression);
            list.Clear();
            list.Add(new Level { LevelIndex = 0, XPRequired = 1, EngramPoints = 0 });
            list.UpdateTotals();
        }

        private LevelList GetLevelList(LevelProgression levelProgression)
        {
            LevelList list = null;
            switch (levelProgression)
            {
                case LevelProgression.Player:
                    list = this.PlayerLevels;
                    break;

                case LevelProgression.Dino:
                    list = this.DinoLevels;
                    break;

                default:
                    throw new ArgumentException("Invalid level progression type specified.");
            }
            return list;
        }

        public static ServerProfile LoadFrom(string path)
        {            
            ServerProfile settings = null;
            if (Path.GetExtension(path) == Config.Default.ProfileExtension)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ServerProfile));
                
                using (var reader = File.OpenRead(path))
                {
                    var streamReader = new StreamReader(reader, System.Text.Encoding.UTF8);
                    settings = (ServerProfile)serializer.Deserialize(streamReader);
                    settings.IsDirty = false;
                }

                var profileIniPath = Path.Combine(Path.ChangeExtension(path, null), Config.Default.ServerGameUserSettingsFile);
                var configIniPath = Path.Combine(settings.InstallDirectory, Config.Default.ServerConfigRelativePath, Config.Default.ServerGameUserSettingsFile);
                if (File.Exists(profileIniPath))
                {
                    settings = LoadFromINIFiles(profileIniPath, settings);
                }
                else if(File.Exists(configIniPath))
                {                    
                    settings = LoadFromINIFiles(configIniPath, settings);
                }
            }
            else
            {
                settings = LoadFromINIFiles(path, settings);
                settings.InstallDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(path)))));
            }

            //
            // TODO: Refactor this out
            //
            if (settings.PlayerLevels.Count == 0)
            {
                settings.ResetLevelProgressionToDefault(LevelProgression.Player);
                settings.ResetLevelProgressionToDefault(LevelProgression.Dino);
                settings.EnableLevelProgressions = false;
            }

            //
            // Since these are not inserted the normal way, we force a recomputation here.
            //
            settings.PlayerLevels.UpdateTotals();
            settings.DinoLevels.UpdateTotals();
            settings.DinoSettings.RenderToView();
            settings.LastSaveLocation = path;
            return settings;
        }

        private static ServerProfile LoadFromINIFiles(string path, ServerProfile settings)
        {         
            SystemIniFile iniFile = new SystemIniFile(Path.GetDirectoryName(path));
            settings = settings ?? new ServerProfile();
            iniFile.Deserialize(settings);

            var strings = iniFile.IniReadSection(IniFileSections.GameMode, IniFiles.Game);

            // 
            // Levels
            //
            var levelRampOverrides = strings.Where(s => s.StartsWith("LevelExperienceRampOverrides=")).ToArray();
            var engramPointOverrides = strings.Where(s => s.StartsWith("OverridePlayerLevelEngramPoints="));
            if (levelRampOverrides.Length > 0)
            {
                settings.PlayerLevels = LevelList.FromINIValues(levelRampOverrides[0], engramPointOverrides);

                if(levelRampOverrides.Length > 1)
                {
                    settings.DinoLevels = LevelList.FromINIValues(levelRampOverrides[1], null);
                }
            }
                      
            return settings;
        }

        public void Save()
        {
            this.DinoSettings.RenderToModel();

            //
            // Save the profile
            //
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (var stream = File.Open(GetProfilePath(), FileMode.Create))
            {
                using (var writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                {
                    serializer.Serialize(writer, this);
                }
            }

            //
            // Write the INI files
            //
            SaveINIFiles();

            //
            // If this was a rename, remove the old profile after writing the new one.
            //
            if(!String.Equals(GetProfilePath(), this.LastSaveLocation))
            {
                try
                {
                    if (File.Exists(this.LastSaveLocation))
                    {
                        File.Delete(this.LastSaveLocation);
                    }

                    var iniDir = Path.ChangeExtension(this.LastSaveLocation, null);
                    if (Directory.Exists(iniDir))
                    {
                        Directory.Delete(iniDir, recursive: true);
                    }
                }
                catch(IOException)
                {
                    // We tried...
                }

                this.LastSaveLocation = GetProfilePath();
            }
        }

        public string GetProfilePath()
        {
            return Path.Combine(Config.Default.ConfigDirectory, Path.ChangeExtension(this.ProfileName, Config.Default.ProfileExtension));
        }

        public string GetProfileIniDir()
        {
            return Path.Combine(Path.GetDirectoryName(GetProfilePath()), this.ProfileName);
        }

        public void SaveINIFiles()
        {
            //
            // Save alongside the .profile
            //
            string profileIniDir = GetProfileIniDir();
            Directory.CreateDirectory(profileIniDir);
            SaveINIFile(profileIniDir);

            //
            // Save to the installation location
            //
            string configDir = Path.Combine(this.InstallDirectory, Config.Default.ServerConfigRelativePath);
            Directory.CreateDirectory(configDir);
            SaveINIFile(configDir);
        }

        private void SaveINIFile(string profileIniDir)
        {
            var iniFile = new SystemIniFile(profileIniDir);
            iniFile.Serialize(this);

            //
            // TODO: Refactor this into SystemIniFile
            //
            var values = iniFile.IniReadSection(IniFileSections.GameMode, IniFiles.Game);
            var filteredValues = values.Where(s => !s.StartsWith("LevelExperienceRampOverrides=") &&
!s.StartsWith("OverridePlayerLevelEngramPoints=")).ToList();
            if (this.EnableLevelProgressions)
            {
                //
                // These must be added in this order: Player, then Dinos, per the ARK INI file format.
                //
                filteredValues.Add(this.PlayerLevels.ToINIValueForXP());
                filteredValues.Add(this.DinoLevels.ToINIValueForXP());
                filteredValues.AddRange(this.PlayerLevels.ToINIValuesForEngramPoints());
            }

            iniFile.IniWriteSection(IniFileSections.GameMode, filteredValues.ToArray(), IniFiles.Game);
        }

        public string GetServerArgs()
        {
            var serverArgs = new StringBuilder();
            serverArgs.Append(this.ServerMap);

            // These are used to match the server to the profile.
            serverArgs.Append("?QueryPort=").Append(this.ServerPort);
            if (!String.IsNullOrEmpty(this.ServerIP))
            {
                serverArgs.Append("?MultiHome=").Append(this.ServerIP);
            }

            if(this.RCONEnabled)
            {
                serverArgs.Append("?RCONEnabled=true");
                serverArgs.Append("?RCONPort=").Append(this.RCONPort);
            }

#if false
            serverArgs.Append("?GlobalVoiceChat=").Append(this.EnableGlobalVoiceChat);
            serverArgs.Append("?ProximityChat=").Append(this.EnableProximityChat);
            serverArgs.Append("?NoTributeDownloads=").Append(!this.EnableTributeDownloads);
            serverArgs.Append("?bAllowFlyerCarryPVE=").Append(this.EnableFlyerCarry);
            serverArgs.Append("?bDisableStructureDecayPVE=").Append(!this.EnableStructureDecay);
            serverArgs.Append("?AlwaysNotifyPlayerLeft=").Append(this.EnablePlayerLeaveNotifications);
            serverArgs.Append("?DontAlwaysNotifyPlayerJoined=").Append(!this.EnablePlayerJoinedNotifications);
            serverArgs.Append("?ServerHardcore=").Append(this.EnableHardcore);           
            serverArgs.Append("?ServerPVE=").Append(!this.EnablePVP);

            serverArgs.Append("?ServerCrosshair=").Append(this.AllowCrosshair);
            serverArgs.Append("?ServerForceNoHud=").Append(!this.AllowHUD);
            serverArgs.Append("?AllowThirdPersonPlayer=").Append(this.AllowThirdPersonView);
            serverArgs.Append("?ShowMapPlayerLocation=").Append(this.AllowMapPlayerLocation);
            serverArgs.Append("?EnablePVPGamma=").Append(this.AllowPVPGamma);


            serverArgs.Append("?ServerPassword=").Append(this.ServerPassword);
            serverArgs.Append("?ServerAdminPassword=").Append(this.AdminPassword);
            serverArgs.Append("?MaxPlayers=").Append(this.MaxPlayers);
            serverArgs.Append("?DifficultyOffset=").Append(this.DifficultyOffset);
            serverArgs.Append("?MaxStructuresInRange=").Append(this.MaxStructuresVisible);
            
            serverArgs.Append("?SessionName=").Append('"').Append(this.ServerName).Append('"');
            serverArgs.Append("?QueryPort=").Append(this.ServerPort);
            if(!String.IsNullOrWhiteSpace(this.ServerIP))
            {
                serverArgs.Append("?MultiHome=").Append(this.ServerIP);
            }
            
            if(!String.IsNullOrWhiteSpace(this.SaveDirectory))
            {
                // TODO: This doesn't appear to work 
                serverArgs.Append("?\"AltSaveDirectoryName=").Append(this.SaveDirectory).Append('"');
            }

            if(!String.IsNullOrWhiteSpace(this.MOTD))
            {
                // TODO: This needs to go into the MessageOfTheDay INI file section
                serverArgs.Append("?MOTD=").Append('"').Append(this.MOTD).Append('"');
            }
#endif

            // Currently this setting does not seem to get picked up from the INI file.
            serverArgs.Append("?MaxPlayers=").Append(this.MaxPlayers);
            serverArgs.Append("?Port=").Append(this.ServerConnectionPort);

            serverArgs.Append("?listen");

            serverArgs.Append(this.AdditionalArgs);

            serverArgs.Append(' ');
            serverArgs.Append(Config.Default.ServerCommandLineStandardArgs);

            return serverArgs.ToString();
        }

        public object this[string propertyName]
        {
            get { return this.GetType().GetField(propertyName).GetValue(this); }
            set { this.GetType().GetField(propertyName).SetValue(this, value); this.IsDirty = true; }
        }

        private void GetDefaultDirectories()
        {
            if (String.IsNullOrWhiteSpace(InstallDirectory))
            {
                InstallDirectory = Path.IsPathRooted(Config.Default.ServersInstallDir) ? Path.Combine(Config.Default.ServersInstallDir)
                                                                                       : Path.Combine(Config.Default.DataDir, Config.Default.ServersInstallDir);
            }
        }

        internal static ServerProfile FromDefaults()
        {
            var settings = new ServerProfile();
            settings.DinoSpawnWeightMultipliers.Reset();
            settings.TamedDinoClassResistanceMultipliers.Reset();
            settings.TamedDinoClassDamageMultipliers.Reset();
            settings.DinoClassResistanceMultipliers.Reset();
            settings.DinoClassDamageMultipliers.Reset();
            settings.HarvestResourceItemAmountClassMultipliers.Reset();
            settings.ResetLevelProgressionToDefault(LevelProgression.Player);
            settings.ResetLevelProgressionToDefault(LevelProgression.Dino);
            return settings;
        }
    }
}
