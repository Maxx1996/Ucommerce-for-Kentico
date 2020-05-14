param($installPath, $toolsPath, $package, $project)

Write-Host "installPath:" "${installPath}"
Write-Host "toolsPath:" "${toolsPath}"

if ($project) {
	$dateTime = Get-Date -Format yyyyMMdd-HHmmss

	# Create paths and list them
	$projectPath = (Get-Item $project.Properties.Item("FullPath").Value).FullName
Write-Host "projectPath:" "$projectPath"
	
	# Clean up old meta data files from Ucommerce modules
	Remove-Item CMS\App_Data\CMSModules\CMSInstallation\Packages\Ucommerce_* ;

	# Copy uCommerce and uCommerce_files from package to project folder
	$uCommerceFolderSource = Join-Path $installPath "uCommerceFiles"	
	robocopy $uCommerceFolderSource "CMS" /is /it /e /xf UI.xml 

	$webConfigSource = Join-Path $projectPath "Web.config"
    $webConfig = New-Object XML
    $webConfig.Load($webConfigSource)

    $uCommerceInstallerModule = $webConfig.CreateElement('add')
    $uCommerceInstallerModule.SetAttribute('name', 'UCommerceInstallationModule') 
    $uCommerceInstallerModule.SetAttribute('type', 'UCommerce.Kentico.Installer.App_Start.Installer, UCommerce.Kentico.Installer')
  
    $uCommerceInstallerRemoveModule = $webConfig.CreateElement('remove')
    $uCommerceInstallerRemoveModule.SetAttribute('name', 'UCommerceInstallationModule') 

    $modules = $webConfig.SelectSingleNode("//system.webServer//modules")
    $modules.AppendChild($uCommerceInstallerRemoveModule);
    $modules.AppendChild($uCommerceInstallerModule);

	#Remove Castle.Windsor dependency in web.config to avoid conflicts doing upgrades when castle has been upgrade. 
	$perRequestLifestyleModulesElements = $webConfig.SelectNodes("//system.webServer//modules//add[@name='PerRequestLifestyle']")
	if($perRequestLifestyleModulesElements.Count -eq 1){
	    $modules.RemoveChild($perRequestLifestyleModulesElements[0])
	}

	$perRequestLifestyleHttpModulesElement = $webConfig.SelectNodes("//system.web//httpModules//add[@name='PerRequestLifestyle']")[0]
	if($perRequestLifestyleHttpModulesElement.Count -eq 1){
	    $webConfig.SelectSingleNode("//system.web//httpModules").RemoveChild($perRequestLifestyleHttpModulesElement)
	}
    
    $webConfig.Save($webConfigSource);		
}

# Set build action of all module resx files to "Content"
$project.ProjectItems | where-object {$_.Name -eq "CMSResources"} | 
    foreach-object { $_.ProjectItems } | where-object {$_.Name -eq $package.id} | 
    foreach-object { $_.ProjectItems } | where-object {$_.Name -like "*.resx"} | 
    foreach-object {$_.Properties} | where-object {$_.Name -eq "BuildAction"} | foreach-object {$_.Value = [int]2}