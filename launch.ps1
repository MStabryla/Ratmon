$CertData = (dotnet dev-certs https -c --trust) | Out-String

if ($CertData.Contains("none of them is trusted")) {
    dotnet dev-certs https --trust
}
else {
    dotnet dev-certs https -v
}

dotnet run --launch-profile https