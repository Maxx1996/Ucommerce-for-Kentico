# Website root folder (website is deployed here)
$website_root = "C:\inetpub\wwwroot\Kentico11\CMS"

# Temporarily change to the correct folder containing script
$scriptPath = (Get-Variable MyInvocation -Scope Script).Value.MyCommand.Path
$currentFolder = Split-Path $scriptPath
Push-Location $currentFolder

# Set src folder based on location of script location in /tools/deploy
$src = ".\..\UCommerce.MasterClass.Website"

# Exclude files and folders from deploy, usually these are
# source code files, proj files from Visual Studio, and other
# files not required at runtime
$options = @("/E", "/S", "/xf", "*.cs", "/xf", "*.??proj", "/xf", "*.user", "/xf", "*.old", "/xf", "*.vspscc", "/xf", "xsltExtensions.config", "/xf", "uCommerce.key", "/xf", "*.tmp", "/xd", "_Resharper*", "/xd", ".svn", "/xd", "_svn", "/xf", "UCommerce.dll", "/xf", "UCommerce.Presentation.dll", "/xf", "UCommerce.Web.Api.dll", "UCommerce.Infrastructure.dll", "/xf", "UCommerce.Transactions.Payments.dll", "/xf", "UCommerce.Pipelines.dll", "/xf", "ServiceStack.*")

# Create directory
New-Item -ItemType Directory -Force -Path "$website_root\CMSTemplates\MasterClass"
New-Item -ItemType Directory -Force -Path "$website_root\CMSTemplates\MasterClass\Pages"
New-Item -ItemType Directory -Force -Path "$website_root\CMSTemplates\MasterClass\UserControls"
New-Item -ItemType Directory -Force -Path "$website_root\CMSTemplates\MasterClass\MasterPages"

# Copy all site specific files into the website
& robocopy "$src\Css" "$website_root\MasterClass\Css" $options
& robocopy "$src\Pages" "$website_root\CMSTemplates\MasterClass\Pages" $options
& robocopy "$src\UserControls" "$website_root\CMSTemplates\MasterClass\UserControls" $options
& robocopy "$src\MasterPages" "$website_root\CMSTemplates\MasterClass\MasterPages" $options
& robocopy "$src\bin" "$website_root\bin" MasterClass*.dll $options

# Now back to original directory
Pop-Location
