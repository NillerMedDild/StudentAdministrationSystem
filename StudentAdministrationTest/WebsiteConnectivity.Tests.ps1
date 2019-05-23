$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path).Replace(".Tests.", ".")
$file = Get-ChildItem "$here\$sut"

. .\WebsiteConnectivity.ps1

Describe "Testing website connectivity" {

	$url = "https://localhost:44304"

    It "The script is valid" {

        $contents = Get-Content -Path $file -ErrorAction Stop
        $errors = $null
        $null = [System.Management.Automation.PSParser]::Tokenize($contents, [ref]$errors)
        $errors | Should -HaveCount 0
    }

    It "The website should be reachable" {
        PingURL $url| Should -Be 200
    }
}