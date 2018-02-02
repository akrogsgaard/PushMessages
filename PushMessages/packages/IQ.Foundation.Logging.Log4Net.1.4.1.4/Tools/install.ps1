param($installPath, $toolsPath, $package, $project)
$configFolder = $project.ProjectItems.Item("config")

$log4netConfig = $configFolder.ProjectItems.Item("log4net.config")
$loggingConfig = $configFolder.ProjectItems.Item("Logging.config")

# set 'Copy To Output Directory' to 'Copy if newer'
$copyToOutput1 = $log4netConfig.Properties.Item("CopyToOutputDirectory")
$copyToOutput1.Value = 2

$copyToOutput2 = $loggingConfig.Properties.Item("CopyToOutputDirectory")
$copyToOutput2.Value = 2