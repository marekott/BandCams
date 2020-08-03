# BandCams

- WebUI Build: ![Build Status](
https://dev.azure.com/wilkusania/BandCams/_apis/build/status/BandCamsWebUIBuild "Build Status")
- WebUI Release: ![Release Status](
https://vsrm.dev.azure.com/wilkusania/_apis/public/Release/badge/8b414c84-d903-43da-a74b-90d6eadcc40c/3/3 "Release Status")
- Data Access Layer Build: ![Build Status](
https://dev.azure.com/wilkusania/BandCams/_apis/build/status/BandCamsDALBuild "Build Status")
- Data Access Layer Release: ![Release Status](
https://vsrm.dev.azure.com/wilkusania/_apis/public/Release/badge/8b414c84-d903-43da-a74b-90d6eadcc40c/2/2 "Release Status")
- Scheduler Build: ![Build Status](
https://dev.azure.com/wilkusania/BandCams/_apis/build/status/BandCamsSchedulerPipeline "Build Status")
- Scheduler Release: ![Release Status](
https://vsrm.dev.azure.com/wilkusania/_apis/public/Release/badge/8b414c84-d903-43da-a74b-90d6eadcc40c/4/4 "Release Status")

## Table of Contents
1. [ Overview ](#overview)<br/>
1.1 [ System Context ](#systemContext)<br/>
1.2 [ Containers ](#containers)<br/>
1.2 [ BandCamsWebUI Components ](#webuicomponents)<br/>
1.2 [ BandCamsDAL Components ](#dalcomponents)<br/>
1.2 [ BandCamsScheduler Components ](#schedulercomponents)<br/>
2. [ Infrastructure ](#infrastructure)<br/>
3. [ Running locally ](#runlocal)<br/>
4. [ FAQ ](#faq)<br/>

<a name="overview"></a>
## Overview
<p>The idea of this project came upon at the beginning of the pandemic from bands that were not able to perform concerts with the audience. They wanted to create a place where all online events that started to become popular could be grouped and watched. The BandCams website was planned as a place connecting streams from various websites (eg. YouTube or Facebook) and stores information about online concerts. Because of that, it allows to watch concerts via external services and not to stream directly through its infrastructure.</p>
<p>The project stopped at the development environment and was suspended. Because of that, code is now public on GitHub. There are minor changes comparing to the original version but they are mainly focused on making running project locally easier.</p>
<p>If you wish to examinate project on development environment please contact me on LinkedIn (www.linkedin.com/in/marek-ott-171608152) beacuse it is protected via Azure AD. After granting access follow below links:</p>

Website:<br/>
https://bandcams-d.azurewebsites.net/<br/>
Data Acces Layer Swagger:<br/>
https://bandcamsdal-d.azurewebsites.net/

<a name="systemContext"></a>
### System Context
<p>
  <img src="documentation/Level 1 System Context diagram.png" alt="System Context"/>
</p>

<a name="containers"></a>
### Containers
<p>
  <img src="documentation/Level 2 Container diagram.png" alt="Container diagram."/>
</p>

<a name="webuicomponents"></a>
### BandCamsWebUI Components
<p>
  <img src="documentation/Level 3 Component diagram for BandCamsWebUI.png" alt="Component diagram for BandCamsWebUI"/>
</p>

<a name="dalcomponents"></a>
### BandCamsDAL Components
<p>
  <img src="documentation/Level 3 Component diagram for BandCamsDAL.png" alt="Component diagram for BandCamsDAL"/>
</p>

<a name="schedulercomponents"></a>
### BandCamsScheduler Components
<p>
  <img src="documentation/Level 3 Component diagram for BandCamsScheduler.png" alt="Component diagram for BandCamsScheduler"/>
</p>

<a name="infrastructure"></a>
## Infrastructure

<p>
  <img src="documentation/Deployment diagram current.png" alt="Deployment diagram current"/>
</p>

<a name="runlocal"></a>
## Running locally
1. Install MS localdb (https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15). You can skip this part if you have Microsoft SQL Server on your locall machine.<br/>
2. Build database project.<br/>
3. Deploy database project.<br/>
4. In \test\RestAPI.IntegrationTests\appsettings.IntegrationTests.json, \src\RestAPI\appsettings.Development.json and \src\WebUI\appsettings.Development.json change value of "BandCamsDB" to connection string of created in previous step database.<br/>
5. In root directory open CMD and run:
```
dotnet build
```
6. After a successful build in the same directory run:
```
dotnet test
```
7. If all tests are passing (one should be skipped). You are ready to run the application. Go to \src\RestAPI and run in CMD:
```
dotnet run
```
8. Got to \src\WebUI and again run:
```
dotnet run
```
9. You can now examine the main website on https://localhost:44312 and Data Access Layer Swagger on https://localhost:5001.

<a name="faq"></a>
## FAQ
1. Some tests are crushing. What is the problem?<br/>
Check if all files mentioned in the fourth step of [ Running locally ](#runlocal) have valid connection strings.
2. Can I run BandCamsScheduler?<br/>
Yes, it can be run locally but requires Azure Queue and SendGrid account. For more information contact me via LinkedIn.
