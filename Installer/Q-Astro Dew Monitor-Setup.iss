;
; Script generated by the ASCOM Driver Installer Script Generator 6.0.0
; Generated by Quidne IT Ltd on 12/03/2017 (UTC)
; Last Updated on 05/02/2019 (UTC)
;
#define AppVersion = "4.0.1"
#define AppName = "Q-Astro Dew Monitor"

;Used for Icon and Registration
#define MainFile    = "ASCOM.QAstroDew.MonitorApp.exe"
#define MainDLLFile = "ASCOM.QAstroDew.ObservingConditions.dll"
#define ServerFile  = "ASCOM.QAstroDew.exe"

;#define ReleaseType = "Release"
#define ReleaseType = "Debug"

#define SourcePath = "<Path to Source Code>"

[Setup]
AppId={{EF44ADC1-04BD-46A5-8419-EA33F1381022}
AppName={#AppName}
AppVerName={#AppName} {#AppVersion}
AppVersion={#AppVersion}
AppPublisher=Quidne IT Ltd.
AppPublisherURL=http://www.q-astro.com
AppSupportURL=mailto:Support@Quidne-IT.com
AppUpdatesURL=http://www.q-astro.com/
VersionInfoVersion=1.5.0
; MinVersion=0,5.0.2195sp4
DefaultDirName="{cf}\ASCOM\{#AppName}"
DisableDirPage=yes
DisableProgramGroupPage=yes
OutputDir="."
OutputBaseFilename="{#AppName} ASCOM - {#ReleaseType} ({#AppVersion})"
Compression=lzma
SolidCompression=yes
; Put there by Platform if Driver Installer Support selected
WizardImageFile="{#SourcePath}\Development\Q-Astro\{#AppName}\{#AppVersion}\Installer\WizardImage.bmp"
LicenseFile=    "{#SourcePath}\Development\Q-Astro\{#AppName}\{#AppVersion}\Installer\CreativeCommons.txt"
; {cf}\ASCOM\Uninstall\FilterWheel folder created by Platform, always
UninstallFilesDir="{cf}\ASCOM\Uninstall\{#AppName}"
UninstallDisplayIcon="{app}\{#MainFile}"

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Dirs]
Name: "{cf}\ASCOM\Uninstall\{#AppName}"

[Files]
Source: "{#SourcePath}\Development\Q-Astro\{#AppName}\{#AppVersion}\QAstroDew\bin\{#ReleaseType}\{#MainDLLFile}"; DestDir: "{app}" ;Flags: ignoreversion
Source: "{#SourcePath}\Development\Q-Astro\{#AppName}\{#AppVersion}\QAstroDew\bin\{#ReleaseType}\MetroFramework.dll"; DestDir: "{app}" ;Flags: ignoreversion
Source: "{#SourcePath}\Development\Q-Astro\{#AppName}\{#AppVersion}\QAstroDew\bin\{#ReleaseType}\LBIndustrialCtrls.dll"; DestDir: "{app}" ;Flags: ignoreversion
Source: "{#SourcePath}\Development\Q-Astro\{#AppName}\{#AppVersion}\QAstroDew\bin\{#ReleaseType}\{#ServerFile}"; DestDir: "{app}"  ; Flags: ignoreversion
Source: "{#SourcePath}\Development\Q-Astro\{#AppName}\{#AppVersion}\QAstroDew\bin\{#ReleaseType}\{#MainFile}"; DestDir: "{app}" ;Flags: ignoreversion

;AfterInstall: RegASCOM()

Source: "{#SourcePath}\Development\Q-Astro\{#AppName}\{#AppVersion}\VersionHistory.txt"; DestDir: "{app}" ;Flags: isreadme

[Icons]
Name: "{commondesktop}\{#AppName}"; Filename: "{app}\{#MainFile}"

; Only if driver is .NET
;Only if COM Local Server
[Run]
Filename: "{app}\{#ServerFile}"; Parameters: "/register"

;Only if COM Local Server
[UninstallRun]
Filename: "{app}\{#ServerFile}"; Parameters: "/unregister"

[CODE]
//
// Before the installer UI appears, verify that the (prerequisite)
// ASCOM Platform 6.0 or great is installed, including both Helper
// components. Utility is required for all types (COM and .NET)!
//
function InitializeSetup(): Boolean;
var
   U : Variant;
   H : Variant;
begin
   Result := TRUE;  // Assume failure
end;

//procedure RegASCOM();
//var
//   P: Variant;
//begin
//   P := CreateOleObject('ASCOM.Utilities.Profile');
//   P.DeviceType := 'ObservingConditions';
//   P.Register('ASCOM.QA.DewServer', 'Q-Astro Dew Server - DO NOT USE!!!');
//end;

//procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
//var
//   P: Variant;
//begin
//   if CurUninstallStep = usUninstall then
//   begin
//     P := CreateOleObject('ASCOM.Utilities.Profile');
//     P.DeviceType := 'ObservingConditions';
//     P.Unregister('ASCOM.QA.DewServer');
//  end;
//end;

// Code to enable the installer to uninstall previous versions of itself when a new version is installed
procedure CurStepChanged(CurStep: TSetupStep);
var
  ResultCode: Integer;
  UninstallExe: String;
  UninstallRegistry: String;
begin
  if (CurStep = ssInstall) then // Install step has started
	begin
      // Create the correct registry location name, which is based on the AppId
      UninstallRegistry := ExpandConstant('Software\Microsoft\Windows\CurrentVersion\Uninstall\{#SetupSetting("AppId")}' + '_is1');
      // Check whether an extry exists
      if RegQueryStringValue(HKLM, UninstallRegistry, 'UninstallString', UninstallExe) then
        begin // Entry exists and previous version is installed so run its uninstaller quietly after informing the user
          MsgBox('Setup will now remove the previous version.', mbInformation, MB_OK);
          Exec(RemoveQuotes(UninstallExe), ' /SILENT', '', SW_SHOWNORMAL, ewWaitUntilTerminated, ResultCode);
          sleep(1000);    //Give enough time for the install screen to be repainted before continuing
        end
  end;
end;

