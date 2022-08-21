# EHR_API

# Basic Instructions
Layered architecture is the most widely used architectural pattern. Almost every software system needs to isolate different concerns (Concern Points) through layers to cope with changes in different requirements, so that such changes can be carried out independently; In addition, the layered architecture pattern is also a powerful tool to isolate business complexity from technical complexity.

# Layered Architecture Pattern

- Presentation Layer: Receive external requests (view, app, ap, etc.), call the business layer, and convert the dto returned by the business layer into a viewmodel and send it back to the outside.

- Business Layer: Receive the request of the presentation layer, focus on processing business logic, call the data layer, and convert the model returned by the data layer into dto and send it back to the presentation layer.

- Data Layer: Focus on processing data, data sources come from databases or other services, receive business layer calls, perform data processing and return models.

- Common Layer: Put the enum and other cross-projects that each layer depends on into this layer. Because the common layer has reference relationships with other layers, the objects in this layer must be simple and must not have business logic.




So I am used to naming it in the following way.

- Presentation layer: Controller
- Business layer: Application
- Data Layer: Infrastructure
- Common layer: Shared

# Project Structure


## EHR.API
The presentation layer/Controller, in terms of .Net, is usually an MVC project or a WebApi project, with two categories of received Parameter and returned ViewModel.

## EHR.Application
The business logic layer/Service, where the business logic is placed, will define the service interface and implement the interface, so that the presentation layer depends on the interface rather than the implementation. Receive the presentation layer's parms and it will be return DTO eneity.

## EHR.Infrastructure
Data layer / Repository, where data access is placed, will define the data layer interface and implement the interface, so that the business logic layer depends on the interface rather than the implementation. Receive the business logic layer parms Entityand send back database entity.

## EHR.Database
The database player , where the EFContext is place, will define the database model and provide Respository to access Database.

## EHR.Shared
Shared layer, entity, dto, enum across layers are placed in this project.
Provides generic technical capabilities that support higher layers mostly using 3rd-party libraries.

