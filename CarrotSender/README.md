# Carrot Sender
Simple web app that just allows to send messages to the message bus.

## Prerequisites
1. Download and install .NET Core 3.0 runtime and hosting bundle ([download link](https://dotnet.microsoft.com/download/thank-you/dotnet-runtime-3.0.0-windows-hosting-bundle-installer))
2. Download and install RabbitMq message bus ([download link](https://www.rabbitmq.com/download.html))

## Make it run
1. Download sources from this repository
2. Go to `{root}\Web` folder
3. Start powershell and run this command - `dotnet run -c Release -e "Production"`
4. Console will log endpoints that you can use to access the app

Example:
```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
```
5. Make sure `{root}\Web\appsettings.json` file is configured correctly using appropriate RabbitMq related settings
