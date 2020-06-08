param($installPath, $toolsPath, $package, $project)
$project = Get-Project
$controllerItem = $project.ProjectItems.Item("Areas").ProjectItems.Item("HelpPage").ProjectItems.Item("Controllers").ProjectItems.Item("HelpController.cs")
$namespace = $controllerItem.FileCodeModel.CodeElements | where Kind -eq 5 #namespace
$controller = $namespace.Members | where Name -eq "HelpController"

try
{
	$controller.ClassKind = 4 # make partial class
	Write-Host "Changed Areas.HelpPage.Controllers.HelpController to be a partial class"
}
catch
{
	Write-Host "Failed to automatically set Areas.HelpPage.Controllers.HelpController to be a partial class - please change it manually"
}