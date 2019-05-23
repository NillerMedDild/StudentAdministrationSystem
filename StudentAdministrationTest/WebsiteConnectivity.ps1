$here = Split-Path -Leaf $MyInvocation.MyCommand.Path

Write-Host "Now executing function PingURL" -ForegroundColor Cyan

function PingURL {
    param([string]$url)
    $HTTP_Request = [System.Net.WebRequest]::Create($url)

    # We get a response from the site.
    $HTTP_Response = $HTTP_Request.GetResponse()

    if (null -eq $HTTP_Response) {
        return "HTTP Request did not receive respone."
    }

    # We get the HTTP code as an integer.
    return [int]$HTTP_Response.StatusCode
}
