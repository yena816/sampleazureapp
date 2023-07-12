# sampleazureapp

<h1>Introduction</h1>
<p>This web based application is an ASP.NET application that includes a Contact Form page. This Contact Form allows users to submit a message that gets stored in an Azure SQL database. The organization can then use this information in various ways. </p>
<p>There are many use cases for a website Contact Form. One example is a feedback form. The organization can allow users to submit feedback about their services or their websites, which can then allow for the organization to make any changes necessary to improve customer satisfaction. An additional example is for future clients. Users that are interested in the organization's services or products can submit a message and a method of contact so that the organization can respond and potentially acquire new clients/customers. </p>

<h1> Architecture Overview </h1>
<p>Below is the architecture overview of the application.</p>

![Training Architecture - GCP Data Analytics and AIML - v 2 0](https://user-images.githubusercontent.com/42750252/220777306-a1402a3d-d67d-4b3a-a78c-24ce0949d530.png)

<h1>Process</h1>
<h2>Visual Studio</h2>
<p>First, the ASP.NET application was created in Visual Studio. The sample template was edited to include a Contact Form page that is accessible by the "Contact" link in the navigation bar. On this page, there are 5 elements: the "Contact Form" title, three text input boxes for First Name, Last Name, and Message, and a "Submit" button. All of these items were created by the HTML code in the Contact view (Contact.cshtml). </p>

![image](https://github.com/yena816/sampleazureapp/assets/42750252/0f56e587-9283-4de2-a6b6-9f1e5286d818)

<p>The Contact model (Contact.cshtml.cs) is where the code behind the items lie. Here, the code for the OnPost method, which is linked to the Submit button in the view, is included. When the Submit button is pressed, the app should save the text from the input into different variables (firstName, lastName, and message). Then, the model sends those values to the view which displays all the values on the screen once the message is submitted. The following images show the filled out form and what is displayed when the submit button is clicked. </p>

![image](https://github.com/yena816/sampleazureapp/assets/42750252/9a2eac70-85c9-4acd-935a-63985f98396a)
![image](https://github.com/yena816/sampleazureapp/assets/42750252/fd734250-25d5-4fd9-b294-3c3c54e79509)

<p>At this point, the page has no interaction with the cloud. That will be the next step outlined in the next section. </p>

<h2>Azure App Service</h2>
<p>The next step is to publish the app to Azure App Service. App Service is a fully managed service that allows you to quickly and easily create enterprise-ready web and mobile apps for any platform or device, and deploy them on a scalable and reliable cloud infrastructure. With features like automatic scaling, continuous deployment, and built-in monitoring, Azure App Service simplifies application development and enables seamless deployment and management of web applications in the cloud.  The application code will be uploaded to App Service, which will then deploy the code and the infrastructure will be maintained by Azure. </p>

<p>Publishing the app to App Service can either be done directly from Visual Studio, or through the Azure portal. In this case, the app was published through Visual Studio (Note: When uploading to App Service, it is important to update the configuration settings of the app to include the ASPNETCORE_ENVIRONMENT variable to “Development”). Once the app is published, it can be accessed by going to the link in the "Default domain" section of the app overview page in the Azure portal. Every time updates are made to the code in Visual Studio, you can republish the app since it is now linked to App Service directly. </p> 

<h2>Azure SQL</h2>

<p>The next step is to create the Azure SQL database and connect it to the app. Azure SQL is a fully managed relational database service that is build on SQL Server technology. It enables organizations to store, manage, and secure their data with ease, while also benefiting from high availability and built-in disaster recovery capabilities. The database is created directly in the Azure portal using the default settings. When creating this database, it is critical to set server firewall rules to only allow traffic from your IP address during the development phase. Once the database is created, we create a table of contacts within it by using the Query editor on the portal.  </p>
<p>The following SQL query is used to create the table of contacts in the database: </p>

```
CREATE TABLE contact (
  id int IDENTITY(1,1) PRIMARY KEY,
  firstname varchar(255),
  lastname varchar(255),
  msg varchar(255)
); 
``` 
<p>After creating the table, a new SQL query is added to the OnPost method in the Contact model code. Now, when the Submit button is clicked, the query runs and inserts a new item into the table that includes the values of firstName, lastName, and message (Note: In the current state of the app, the login credentials for the database are hardcoded into the app's code. This is NOT recommended. The password should be stored as a key somewhere secure, but for the purpose of keeping this app simple, the values are in the code). </p>
<p>To verify that the data submission worked, the following SQL query can be run in the Azure portal Query editor: </p>

```
SELECT * FROM contact;
```

![image](https://github.com/yena816/sampleazureapp/assets/42750252/70aa40f6-2e1c-4807-a8c3-12800edf90d5)

