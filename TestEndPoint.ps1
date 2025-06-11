
# This script is used to test the endpoints
param(
    [string]$environment = "Development",
    [string]$launchProfile = "https-Development",
    [string]$connectionStringKey = "BooksDb",
    [bool]$dropDatabase = $true,
    [bool]$createDatabase = $true
)

# Get the project name
$projectName = Get-ChildItem -Recurse -Filter "*.csproj" | Select-Object -First 1 | ForEach-Object { $_.Directory.Name } # Projectname can also be set manually

# Get the base URL of the project
$launchSettings = Get-Content -LiteralPath ".\$projectName\Properties\launchSettings.json" | ConvertFrom-Json
$baseUrl = ($launchSettings.profiles.$launchProfile.applicationUrl -split ";")[0] # Can also set manually -> $baseUrl = "https://localhost:7253"

#Install module SqlServer
if (-not (Get-Module -ErrorAction Ignore -ListAvailable SqlServer)) {
    Write-Verbose "Installing SqlServer module for the current user..."
    Install-Module -Scope CurrentUser SqlServer -ErrorAction Stop
}
Import-Module SqlServer

# Set the environment variable
$env:ASPNETCORE_ENVIRONMENT = $environment



# Read the connection string from appsettings.Development.json
$appSettings = Get-Content ".\$projectName\appsettings.$environment.json" | ConvertFrom-Json
$connectionString = $appSettings.ConnectionStrings.$connectionStringKey
Write-Host "Database Connection String: $connectionString" -ForegroundColor Blue


# Get the database name from the connection string
if ($connectionString -match "Database=(?<dbName>[^;]+)")
{
    $databaseName = $matches['dbName']
    Write-Host "Database Name: $databaseName" -ForegroundColor Blue
}else{
    Write-Host "Database Name not found in connection string" -ForegroundColor Red
    exit
}


# Check if the database exists
$conStringDbExcluded = $connectionString -replace "Database=[^;]+;", ""
$queryDbExists = Invoke-Sqlcmd -ConnectionString $conStringDbExcluded -Query "Select name FROM sys.databases WHERE name='$databaseName'"
if($queryDbExists){
    if($dropDatabase -or (Read-Host "Do you want to drop the database? (y/n)").ToLower() -eq "y") { 

        # Drop the database
        Invoke-Sqlcmd -ConnectionString $connectionString -Query  "USE master;ALTER DATABASE $databaseName SET SINGLE_USER WITH ROLLBACK IMMEDIATE;DROP DATABASE $databaseName;"
        Write-Host "Database $databaseName dropped." -ForegroundColor Green
    }
}

# Create the database from the model
if(Select-String -LiteralPath ".\$projectName\Program.cs" -Pattern "EnsureCreated()"){
    Write-Host "The project uses EnsureCreated() to create the database from the model." -ForegroundColor Yellow
} else {
    if($createDatabase -or (Read-Host "Should dotnet ef migrate and update the database? (y/n)").ToLower() -eq "y") { 

        dotnet ef migrations add "UpdateModelFromScript_$(Get-Date -Format "yyyyMMdd_HHmmss")" --project ".\$projectName\$projectName.csproj"
        dotnet ef database update --project ".\$projectName\$projectName.csproj"
    }
}

# Run the application
if((Read-Host "Start the server from Visual studio? (y/n)").ToLower() -ne "y") { 
    Start-Process -FilePath "dotnet" -ArgumentList "run --launch-profile $launchProfile --project .\$projectName\$projectName.csproj" -WindowStyle Normal    
    Write-Host "Wait for the server to start..." -ForegroundColor Yellow 
}

# Continue with the rest of the script
Read-Host "Press Enter to continue when the server is started..."



### =============================================================
### =============================================================
### =============================================================

# Send requests to the API endpoint




### Copy below code to test the endpoints




###

### ------------Post a movie


Write-Host "`nCreate Authors"


$httpMethods = "Get", "Post", "Put", "Delete"

$endPointRoute = "$baseUrl/api/"

$endPoints = "Authors", "Books", "Inventories", "Loaners", "LoanCards", "Loans", "Ratings"

# Endpoints för följande funktionalitet i Webb-APIet ska finnas
# Skapa en författare
# Skapa en bok
# Skapa en ny låntagare
# Lista alla böcker
# Hämta information om en specifik bok
# Låna en bok
# Lämna tillbaka en bok
# Ta bort låntagare
# Ta bort böcker
# Ta bort författare

write-host $baseUrl

$jsonAuthors = '{ 
    "FirstName": "Tamsyn", 
    "LastName": "Muir" 
}', 
'{
    "FirstName": "J.R.R", 
    "LastName": "Tolkien" 
}', 
'{
    "FirstName": "Hans", 
    "LastName": "Rosling" 
}', 
'{
    "FirstName": "Ola", 
    "LastName": "Rosling" 
}', 
'{
    "FirstName": "Anna", 
    "LastName": "Rosling Rönnlund" 
}', 
'{
    "FirstName": "Gabriel", 
    "LastName": "Viinikka" 
}'


foreach($author in $jsonAuthors){
$localEndpoint = $endPointRoute + $endPoints[0]
$response = Invoke-RestMethod -Uri $localEndpoint -Method $httpMethods[1] -Body $author -ContentType "application/json"
$response | Format-Table

}

$jsonBooks = '{
    "Title": "Gideon The Ninth",
    "ISBN": "9781250313188",
    "PublicationYear": "2020-07-01",
    "AuthorIds": [1]
}',
'{
    "Title": "Sagan om konungens återkomst",
    "ISBN": "9120059175",
    "PublicationYear": "1961-01-01",
    "AuthorIds": [2]
}',
'{
    "Title": "Gabriels testbok med felaktigt ISBN",
    "ISBN": "12345",
    "PublicationYear": "2025-06-11",
    "AuthorIds": [6]
}',
'{
    "Title": "FACTFULNESS",
    "ISBN": "9781473637474",
    "PublicationYear": "2019-01-01",
    "AuthorIds": [3,4,5]
}',
'{
    "Title": "FACTFULNESS",
    "ISBN": "9781473637474",
    "PublicationYear": "2019-01-01",
    "AuthorIds": [3,4,5]
}'

foreach($book in $jsonBooks){
    $localEndpoint = $endPointRoute + $endPoints[1]
    $response = Invoke-RestMethod -Uri $localEndPoint -Method $httpMethods[1] -Body $book -ContentType "application/json"
    $response | Format-Table
}
Read-Host "Please review the entered Books before proceeding, press enter to proceed and see all books in the library thus far..."
$localEndpoint = $endPointRoute + $endPoints[1]
$response = Invoke-RestMethod -Uri $localEndPoint -Method $httpMethods[0] -Body $book -ContentType "application/json"
$response | Format-Table

$jsonLoaners = '{
  "firstName": "Gabriel",
  "lastName": "Viinikka"
}',
'{
  "firstName": "Benjamin",
  "lastName": "Österlund"
}',
'{
  "firstName": "Staffan",
  "lastName": "Stalledräng"
}'

foreach($loaner in $jsonLoaners){
    $localEndpoint = $endPointRoute + $endPoints[3]
    $response = Invoke-RestMethod -Uri $localEndPoint -Method $httpMethods[1] -Body $loaner -ContentType "application/json"
    $response | Format-Table
}

$localEndpoint = $endPointRoute + $endPoints[3]
    $response = Invoke-RestMethod -Uri $localEndPoint -Method $httpMethods[0] -Body $book -ContentType "application/json"
    $response | Format-Table

Read-Host "please review the entered authors and books before querying directly from the database, press enter to proceed..."
### ------------ Query Author, Books, Loaners from the database
$sqlResult = Invoke-Sqlcmd -ConnectionString $connectionString -Query "Select * FROM Authors"
$sqlResult | Format-Table

# $httpMethodGet = "Get"

$sqlResult = Invoke-Sqlcmd -ConnectionString $connectionString -Query "Select * FROM Books"
$sqlResult | Format-Table

$sqlResult = Invoke-Sqlcmd -ConnectionString $connectionString -Query "Select * FROM Loaners"
$sqlResult | Format-Table