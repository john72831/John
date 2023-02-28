using Cupboard;

namespace John.Cupboard
{
    public class Chocolatey : Manifest
    {
        public override void Execute(ManifestContext context)
        {
            // Download
            context.Resource<Download>("https://chocolatey.org/install.ps1")
                .ToFile("~/install-chocolatey.ps1");

            // Set execution policy
            context.Resource<RegistryValue>("Set execution policy")
                .Path(@"HKLM:\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell")
                .Value("ExecutionPolicy")
                .Data("Unrestricted", RegistryValueKind.String);

            // Install
            context.Resource<PowerShell>("Install Chocolatey")
                .Script("~/install-chocolatey.ps1")
                .Flavor(PowerShellFlavor.PowerShell)
                .RequireAdministrator()
                .Unless("if (Test-Path \"$($env:ProgramData)/chocolatey/choco.exe\") { exit 1 }")
                .After<RegistryValue>("Set execution policy")
                .After<Download>("https://chocolatey.org/install.ps1");

            context.Resource<ChocolateyPackage>("vscode")
                .Ensure(PackageState.Uninstalled)
                .After<PowerShell>("Install Chocolatey");

            context.Resource<ChocolateyPackage>("visualstudio2022enterprise")
                .Ensure(PackageState.Uninstalled)
                .After<PowerShell>("Install Chocolatey");

            context.Resource<ChocolateyPackage>("ssms")
                .Ensure(PackageState.Uninstalled)
                .After<PowerShell>("Install Chocolatey");

            context.Resource<ChocolateyPackage>("adobereader")
                .Ensure(PackageState.Installed)
                .After<PowerShell>("Install Chocolatey");
        }
    }
}