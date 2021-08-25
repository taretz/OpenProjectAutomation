# OpenProjectAutomation
An automation system for 'Open Project' software

### Introduction
This is a test automation system for 'Open Project' which is an open source project management software (https://www.openproject.org).
The system is cabable of executing both API and UI tests and provide detailed logs including screenshots of interacted web elements

### Open Project Installation
The system is based on an open project instance installed and running on an 'all-in-one' docker container. 
See installation details here - https://www.openproject.org/docs/installation-and-operations/installation/docker  
*Note that for this installation you need to have Docker Desktop installed on your Windows machine - https://www.docker.com/products/docker-desktop

### Authentication
I used 'Basic Auth' authentication but any authentication method listed here - https://www.openproject.org/docs/api/introduction/
is applicable.

### Deployment steps
1. Launch an 'Open Project' instance over a docker container as explained above.
2. Set the 'Open Project' instance URL in the appropriate field in Config.cs (default is 'http://localhost:8080/')
3. Generate an api key, copy it, paste it in the appropriate field in Config.cs

  
    
That's it, you're good to go!
