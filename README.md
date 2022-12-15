# TaskTracker1

System Requirements

    Operating Systems:

        Windows 7 SP1 and later,
        Windows 8.1,
        Windows 10 Version 1607 and later,
        Windows Server 2008 R2 SP1 (Full Server or Server Core),
        Windows Server 2012 SP1 (Full Server or Server Core),
        Windows Server 2012 R2 (Full Server or Server Core),
        Windows Server 2016 (Full Server, Server Core, or Nano Server),
        Mac OS X 10.11, 10.12*,
        Red Hat Enterprise Linux 7,
        Ubuntu 14.04, 16.04, 17

    Hardware Environment:

        Processor: x86 or x64
        RAM : 512 MB (minimum), 1 GB (recommended)
        Hard disc: up to 3 GB of free space may be required

    Development Environment

        Dotnet Core 6.0
        SQL Server 2022


Startup process

Before running the application, you must specify the connection string to the
database server in the TaskTracker1/appsettings.json file. You should write
the connection string in quotes opposite ""ConnectionString":".

To run the application, go to the TaskTracker1 folder, open console and run
the "dotnet build" command. After that run the TaskTracker.dll file from the
TaskTracker1/bin/Debug/net6.0/ directory using the "dotnet TaskTracker.dll"
console command.

After that, you can go to http://localhost:5000/swagger/index.html or
https://localhost:5001/swagger/index.html in your browser and test
http-requests by using Swagger.