# Prerequisite: Install-Module -Name PowerShellHumanizer
# Run this script from within its directory; the paths are relative

Import-Module PowerShellHumanizer

$LINE_BREAK = "`r`n"

function AddHeaderToSourceFile($fullPath) {
    $fullPath

    $fileName = [io.path]::GetFileNameWithoutExtension($fullPath)
    $firstTenLines = Get-Content -Path $fullPath -First 10
    
    $linesStartingWithH1 = $firstTenLines | where { $_.ToString().StartsWith("# ")}
    $linesStartingWithFrontmatter = $firstTenLines | where { $_ -ne $null -and $_.StartsWith("---")}
    
    $hasH1 = $linesStartingWithH1.Length -gt 0
    $hasFrontmatter = $linesStartingWithFrontmatter.Length -gt 0
    
    if (!$hasH1){
        $newH1 = $fileName.Humanize()
        "New H1 will be $newH1"
        
    }
    
}

Get-ChildItem  ..\docs**\*.md -Recurse | Select FullName | ForEach-Object { AddHeaderToSourceFile($_.FullName)} 