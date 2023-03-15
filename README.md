# sampleazureapp

<h1> Architecture Overview </h1>

![Training Architecture - GCP Data Analytics and AIML - v 2 0](https://user-images.githubusercontent.com/42750252/220777306-a1402a3d-d67d-4b3a-a78c-24ce0949d530.png)

<h1>Compute</h1>

<h2>Azure App Service </h2>

<p>The ASP.NET application will be deployed in Azure App Service. App Service is a fully managed service that allows you to quickly and easily create enterprise-ready web and mobile apps for any platform or device, and deploy them on a scalable and reliable cloud infrastructure. The application code will be uploaded to App Service, which will then deploy the code and the infrastructure will be maintained by Azure. </p>
<p>When uploading to App Service, it is important to update the configuration settings of the app to include the ASPNETCORE_ENVIRONMENT variable to “Development”. </p>

<h1>Data/Storage</h1>

<h2>Azure SQL</h2>

<p>The data displayed and ingested by the application will be stored on Azure SQL. Azure SQL is a fully managed database service that is build on SQL Server technology.</p>
<p>When creating this database, it is critical to set server firewall rules to only allow traffic from your IP address during the development phase. </p>
