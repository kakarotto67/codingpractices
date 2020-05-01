function Uninstall() {
    Write-Host "Uninstalling App as installation failed... Please try installation again."
    Invoke-Expression "& $PSScriptRoot\uninstall.ps1"
    Exit
}

$AppPath = "$PSScriptRoot\TestServiceFabric"
Copy-ServiceFabricApplicationPackage -ApplicationPackagePath $AppPath -ApplicationPackagePathInImageStore TestServiceFabric -ShowProgress
if (!$?) {
    Uninstall
}

Register-ServiceFabricApplicationType TestServiceFabric
if (!$?) {
    Uninstall
}

New-ServiceFabricApplication fabric:/TestServiceFabric TestServiceFabricType 1.0.0
if (!$?) {
    Uninstall
}