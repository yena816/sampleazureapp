# sampleazureapp

<h1>Introduction</h1>
<p>This web based application is an ASP.NET application that includes a Contact Form page. This Contact Form allows users to submit a message that gets stored in an Azure SQL database. The organization can then use this information in various ways. </p>
<p>There are many use cases for a website Contact Form. One example is a feedback form. The organization can allow users to submit feedback about their services or their websites, which can then allow for the organization to make any changes necessary to improve customer satisfaction. An additional example is for future clients. Users that are interested in the organization's services or products can submit a message and a method of contact so that the organization can respond and potentially acquire new clients/customers. </p>

<h1> Architecture Overview </h1>
<p>Below is the architecture overview of the application.</p>
![Training Architecture - GCP Data Analytics and AIML - v 2 0](https://user-images.githubusercontent.com/42750252/220777306-a1402a3d-d67d-4b3a-a78c-24ce0949d530.png)

<h1>Process</h1>
<h2>Visual Studio</h2>
<p>First, the ASP.NET application was created in Visual Studio. The sample template was edited to include a Contact Form page that is accessible by the "Contact" link in the navigation bar. On this page, there are 5 elements: the "Contact Form" title, three text input boxes for First Name, Last Name, and Message, and a "Submit" button. All of these items were created by the HTML code in the Contact view. </p>

![image](https://github.com/yena816/sampleazureapp/assets/42750252/0f56e587-9283-4de2-a6b6-9f1e5286d818)

<p>The Contact model is where the code behind the items lie. Here, the code for the OnPost method, which is linked to the Submit button in the view, is included. When the Submit button is pressed, the app should save the text from the input into different variables (firstName, lastName, and message). Then, the model sends those values to the view which displays all the values on the screen once the message is submitted. The following images show the filled out form and what is displayed when the submit button is clicked. </p>
![image](https://github.com/yena816/sampleazureapp/assets/42750252/9a2eac70-85c9-4acd-935a-63985f98396a)
![image](https://github.com/yena816/sampleazureapp/assets/42750252/fd734250-25d5-4fd9-b294-3c3c54e79509)



<h1>Compute</h1>

<h2>Azure App Service </h2>

<p>The ASP.NET application will be deployed in Azure App Service. App Service is a fully managed service that allows you to quickly and easily create enterprise-ready web and mobile apps for any platform or device, and deploy them on a scalable and reliable cloud infrastructure. The application code will be uploaded to App Service, which will then deploy the code and the infrastructure will be maintained by Azure. </p>
  
<p>When uploading to App Service, it is important to update the configuration settings of the app to include the ASPNETCORE_ENVIRONMENT variable to “Development”. </p>

<h1>Data/Storage</h1>

<h2>Azure SQL</h2>

<p>The data displayed and ingested by the application will be stored on Azure SQL. Azure SQL is a fully managed database service that is build on SQL Server technology.</p>
<p>When creating this database, it is critical to set server firewall rules to only allow traffic from your IP address during the development phase. </p>
<p>The following SQL query is used to create the table of contacts in the database:
CREATE TABLE contact (
id int IDENTITY(1,1) PRIMARY KEY,
firstname varchar(255),
lastname varchar(255),
msg varchar(255)
);

what - summary of the solution/service 
why - requirements, use case, why you have built it, who will use it and how they will use it 
how - explain how you built it, step by step development, configuration, process
