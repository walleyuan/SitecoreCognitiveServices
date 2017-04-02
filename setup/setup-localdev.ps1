<#
    This script renames and updates configuration files (matching *.localdev) which are specific for the local development environment.
#>

. "$PSScriptRoot\_log.ps1"

# Constants
$localDevPostfix = ".localdev"
$codePath =  Resolve-Path "$PSScriptRoot\..\code\"
$serializationRootPath =  Resolve-Path "$PSScriptRoot\..\serialization\Sitecore.SharedSource.CognitiveServices\"
$unicornSerializationRootFile = "UnicornSerializationRoot.config"
$unicornSerializationRootPlaceholder = "_UNICORN_SERIALIZATION_ROOT_"
$regexToExcludePaths = "\\(obj|bin)\\?"

function CopyRenameLocalDevFiles
{    
    Param(
        [Parameter(Position=0, Mandatory=$true)]
        [System.IO.FileInfo[]] $FileArray
        )

    Log "Start renaming files ..."
    $renamedFiles = New-Object System.Collections.ArrayList
    
    foreach ($file in $FileArray)
    {
        if ($file)
        {
            $fileFullPath = $file.FullName
            if ($fileFullPath.EndsWith($localDevPostfix))
            {
                $renamedFile = $file.Name.Substring(0, $file.Name.Length - $localDevPostfix.Length)
                $renamedFilePath = Join-Path $file.Directory.FullName $renamedFile
                Copy-Item -Path "$fileFullPath" -Destination "$renamedFilePath" -Force
                $renamedFiles.Add($renamedFilePath) >> null
                Log "Copied $file to $renamedFile."
            }
        }
    }

    return $renamedFiles
}

function GetLocalDevFiles
{
    Param(
        [Parameter(Position=0,Mandatory=$True)]
        $CodePath,
        [Parameter(Position=1,Mandatory=$True)]
        $Pattern
    )

    Log "Start searching files with pattern $Pattern ..."
    [System.IO.FileInfo[]] $localDevFiles = Get-ChildItem -Path $CodePath -File -Filter $Pattern -Recurse

    return $localDevFiles
}

function Update-FileContent
{
    Param(
        [Parameter(Position=0, Mandatory=$true)]
        [string] $FileName,
        [Parameter(Position=1, Mandatory=$true)]
        [string] $OldValue,
        [Parameter(Position=2, Mandatory=$true)]
        [string] $NewValue
    )

    Log "Renaming $OldValue to $NewValue for $FileName."

    $fileToUpdate = Get-ChildItem -File -Path "$codePath" -Recurse -Force -Filter $FileName | Where-Object { ( $_.FullName -notmatch "$regexToExcludePaths") } | Select-Object -First 1
    if ($fileToUpdate)
    {
        (Get-Content $fileToUpdate.Fullname) -ireplace [regex]::Escape($OldValue), "$NewValue" | Set-Content $fileToUpdate.Fullname -Force
    }
    else
    {
         throw [System.IO.FileNotFoundException] "$FileName not found in $codePath."
    }

}

function Update-UnicornSerialiationRoot
{
    Update-FileContent -FileName $unicornSerializationRootFile -OldValue $unicornSerializationRootPlaceholder -NewValue "$serializationRootPath"
}

# Main
try 
{
    if (-not (Test-Path "$codePath"))
    {
        throw [System.IO.DirectoryNotFoundException] "$codePath not found."
    }

    if (-not (Test-Path "$serializationRootPath"))
    {
        throw [System.IO.DirectoryNotFoundException] "$serializationRootPath not found."
    }

    $localDevFiles = GetLocalDevFiles -CodePath "$codePath" -Pattern "*$localDevPostfix"
    if ($localDevFiles)
    {
        $renamedFiles = CopyRenameLocalDevFiles -FileArray $localDevFiles
        Update-UnicornSerialiationRoot
        Log "Setup completed successfully!" -FontColor Green
    }
     else
    {
        Log "No files found that match *$localDevFiles." -FontColor Red
    }
}
catch [System.Exception]
{
    Write-Error $error[0]
    Write-Host "!!! Setup did not succeed. Investigate and fix the error then try again. !!!" -ForegroundColor Red
    exit
}