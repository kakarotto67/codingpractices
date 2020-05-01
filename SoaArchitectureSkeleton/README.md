# SoaArchitectureSkeleton
Contains ASP.NET client and WCF service.

Basic ASP.NET app plays role of SOA consumer.
I use Separated Interface pattern to bind client with DAL via interface.
I've found a way to do this without direct reference to DAL project in client project using DI container plus MEF.

Service plays role of SOA provider.
It is built using WCF self-hosted mode.

HomeworkWebsite_UML.txt contains pseudocode of UML diagram. Use codeuml.com site to parse it.
