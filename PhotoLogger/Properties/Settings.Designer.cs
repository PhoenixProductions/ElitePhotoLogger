﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoLogger.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%HOMEPATH%\\Documents\\FlightLog")]
        public string FlightLogBaseDir {
            get {
                return ((string)(this["FlightLogBaseDir"]));
            }
            set {
                this["FlightLogBaseDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%HOMEPATH%\\Pictures\\Frontier Developments\\Elite Dangerous")]
        public string EDPhotoDir {
            get {
                return ((string)(this["EDPhotoDir"]));
            }
            set {
                this["EDPhotoDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ENPersonalToken {
            get {
                return ((string)(this["ENPersonalToken"]));
            }
            set {
                this["ENPersonalToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int ENMode {
            get {
                return ((int)(this["ENMode"]));
            }
            set {
                this["ENMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ENNoteStoreUrl {
            get {
                return ((string)(this["ENNoteStoreUrl"]));
            }
            set {
                this["ENNoteStoreUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ENEnabled {
            get {
                return ((bool)(this["ENEnabled"]));
            }
            set {
                this["ENEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ENNotebook {
            get {
                return ((string)(this["ENNotebook"]));
            }
            set {
                this["ENNotebook"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0, 0")]
        public global::System.Drawing.Point MainWindowStartLocation {
            get {
                return ((global::System.Drawing.Point)(this["MainWindowStartLocation"]));
            }
            set {
                this["MainWindowStartLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoPostTwitter {
            get {
                return ((bool)(this["AutoPostTwitter"]));
            }
            set {
                this["AutoPostTwitter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Tweetinvi.WebLogic.OAuthCredentials TwitterCredentials {
            get {
                return ((global::Tweetinvi.WebLogic.OAuthCredentials)(this["TwitterCredentials"]));
            }
            set {
                this["TwitterCredentials"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TweetText {
            get {
                return ((string)(this["TweetText"]));
            }
            set {
                this["TweetText"] = value;
            }
        }
    }
}
