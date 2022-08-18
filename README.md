# 🫡 Welcome to sk-big-oven-grpc Using .NET 6 🤖 
Fifth task on my internship at [SilverKey](https://www.silverkeytech.com/).

<details>
<summary>🚨 Day One - "August 16"</summary>

# Welcome to [sk-big-oven-grpc](https://github.com/ZiadMansourM/sk-big-oven-grpc) Using .NET 6 🤖 / EX-5
```Console
*** After working for 39 hours on a single bug...
-------------------------------------------------
- I studied/followed:
$ practical-aspnetcore/grpc.
$ Microsoft docs on how to "Create a gRPC client and server in ASP.NET Core"
$ Docs on how to "Configure endpoints for the ASP.NET Core Kestrel web server"
$ Docs on how to "Start ASP.NET Core gRPC app on macOS"
$ Other Microsoft docs related to gRPCs...
$ Using Docker...
$ Nearly all the StackOverflow questions, I thought related to the bug.
$ Good amount of Articles.
$ Every single line Bassel and Younes wrote!
```

### The bug:
On Mac OS,  Kestrel doesn't support HTTP/2 with TLS. The solution was mentioned in the [docs](https://docs.microsoft.com/en-us/aspnet/core/grpc/troubleshoot?view=aspnetcore-6.0#unable-to-start-aspnet-core-grpc-app-on-macos). But, that solution made me get "This site can’t be reached; localhost refused to connect;" when I navigate to "/". Instead of getting "This server contains a gRPC service".

> The above error made me doubt every single line in the code.

While the cause of the bug was that, the solution proposed by the [docs](https://docs.microsoft.com/en-us/aspnet/core/grpc/troubleshoot?view=aspnetcore-6.0#unable-to-start-aspnet-core-grpc-app-on-macos) enforces HTTP/2 and prevents the fall back to HTTP/1.1. Consequently, that explains why I was getting "This site can’t be reached; localhost refused to connect;" because chrome was using "HTTP/1.1". The "/" root was my way to determine if the backend gRPC service running or not, that is why I haven't tested the backend with a client or else I would have discovered the bug earlier.

### How I discovered the bug?
> Went for a walk today at 01:00 AM to get some fresh air, as soon as I returned and opened my laptop, Vola! 

It was not even a bug, I just choose the wrong metrics to determine if my gRPC server is running!

![WhatsApp Image 2022-08-17 at 4 23 39 AM](https://user-images.githubusercontent.com/64917739/185020841-e9c6a46a-4d91-4547-a982-45f1212f7774.jpeg)

</details>

<details>
<summary>🚨 Day Two - "August 17"</summary>

# Welcome to [sk-big-oven-grpc](https://github.com/ZiadMansourM/sk-big-oven-grpc) Using .NET 6 🤖 / EX-5
```Console
*** My goal for today was to:
-----------------------------
$ Connect client to the server after knowing the problem I struggled with for two days.
$ Category "List, Get, Create, Update, Delete".
$ Recipe "List, Get, Create, Update, Delete".
```

# 🦦 Checklist of the day
- [X] Connect Client to the Server.
- [X] Category "List, Get, Create, Update, Delete".
- [X] Recipe "List".

# ➕ ToDo
- [ ] Recipe "List".
- [ ] Validation "Client, Server".
- [ ] Add status codes.
- [ ] Deploy gRPC exercise.
</details>
