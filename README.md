# Library Management System

This project focuses on developing a library management system in C# as a console application to enhance the concepts of object-oriented programming.

## Description

The library management system deals with books and users, and provides functionality like adding a book, fetching a book by id, and more. The goal is to structure this system using classes or interfaces as needed.

##Basic Library Setup

1. **Create base classes:**
- `Book`: Contains properties like id, title, and creation date.
- `User`: Contains id, name, and creation date.
- `Library`: Manages books and users.

2. **Implement Simple Inheritance:**
- Develop a base class for `User` and `Book` to inherit common features.
- `Id` can be a `Guid` created in the constructor. If `Date` is empty, it will default to the current date. Only `Title`/`Name` is mandatory.

## Basic Library Features

The library includes features like:
- Retrieve all books/users sorted by creation date.
- Search books by title
- Search users by name
- Add new book/user to library
- Delete book/user by ID

Use these functions in "Program.cs" using the sample code provided.

## Setting up Notification Service

1. The "INotificationService" interface is defined using "SendNotificationOnSuccess" and "SendNotificationOnFailure" methods.

2. Two distinct notification services are created:
- "EmailNotificationService":
- "SendNotificationOnSuccess": Sends a comprehensive email with action details, item summary, user feedback instructions and support contacts.
- `SendNotificationOnFailure`: Provides an error report, troubleshooting steps and a link to the FAQ or Help page.
- `SMSNotificationService`:
- `SendNotificationOnSuccess`: Sends a brief SMS confirming the action and updating the status.
- `SendNotificationOnFailure`: Provides a brief error notification and suggests contacting support.

3. Injected `INotificationService` into `Library` class to get notifications when a book/user is added or removed.

4. Created two libraries with different notification services. Use these features in `Program.cs` to show the addition/removal of books/users in each library and monitor notifications.

```csharp
class Program {
static void Main()
{
var emailService = new EmailNotificationService();
var smsService = new SMSNotificationService();

var libraryWithEmail = new Library(emailService);
var libraryWithSMS = new Library(smsService);

// Show how to add/remove books/users in each library and monitor notifications
}
}
