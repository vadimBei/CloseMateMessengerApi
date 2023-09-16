# Project CloseMate README

## Overview
This REST API service is built using C# with .NET 7.0 and follows a microservices architecture. It integrates with the OpenAI platform to provide powerful AI capabilities.


## Getting Started
To get this application up and running, follow these steps:

1. Registration: Register on the official OpenAI website by visiting https://platform.openai.com/.

2. Payment Method: Add a payment method to your OpenAI account by going to https://platform.openai.com/account/billing/payment-methods.

3. API Key: Generate a new secret API key for your application at https://platform.openai.com/account/api-keys.

4. Configuration: In the CloseMate.Api project, locate the appsettings.json file.
```
{
    "OpenAIOptions": {
        "ApiKey": "YOUR_SECRET_API_KEY_HERE"
    },
    // Other configuration settings...
}
```

Replace "YOUR_SECRET_API_KEY_HERE" with the API key you obtained in step 3.

5. Startup: Choose the docker-compose as the startup project in your development environment and run the project.


## Usage
This guide explains how to create a chat using the REST API service.

We can perform the following operations with the chat:
- Create a chat.
- Get all chats.
- Get a chat by ID.
- Delete a chat.
- Edit the chat name.

### Create a Chat
To create a chat, make a POST request to the /api/close-mate/chats endpoint.
**Endpoint: /api/close-mate/chats**
**Request example:**

```
{
  "name": "how to create record on C#?"
}
```

**Response:**
```
{
  "id": 1,
  "created": "2023-08-22T16:33:08.4771702+00:00",
  "name": "how to create record on C#?",
  "messages": []
}
```

### Send a Message to OpenAI
Once you've created a chat, you need to send your question to the OpenAI API. To do this, make a POST request. The result of the request will be the last message in the chat that contains a response from the OpenAI API.
**Endpoint: /api/close-mate/chat-messages/send**
**Request example:**

```
{
  "chatId": 1,
  "content": "how to create record on C#?"
}
```

**Response:**
```
{
  "id": 2,
  "integrationId": "chatcmpl-7mO0FLJzhPxnHdUXK2BbnNghikG0F",
  "created": "2023-08-22T16:38:36.741208",
  "content": "In C#, a record is a new feature introduced in C# 9.0 that provides a succinct way to declare a type and its properties. Records are primarily used for immutability and provide useful features such as  value - based equality, deconstruction, and robust ToString() implementation. \n\nTo create a C# record, follow these steps:\n\nStep 1: Create a new C# project or open an existing project in an integrated development environment (IDE) like Visual Studio.\n\nStep 2: Add a new class file to your project.\n\nStep 3: Inside the class file, declare a record using the `record` keyword followed by the name of the record.\n\nExample:\n```csharp\npublic record Person(string Name, int Age);\n```\n\nIn this example, we create a `Person` record with two properties - `Name` of type `string` and `Age` of type `int`.\n\nStep 4: Use the record in your program by instantiating it.\n\nExample:\n```csharp\nvar person = new Person(); \n```\n\nStep 5: Access the properties of the record using dot notation.\n\nExample:\n```csharp\nConsole.WriteLine();\n``` \n\nThis will output `Name: John Doe, Age: 25`.\n\nRecords in C# are by default immutable, meaning their properties cannot be modified after construction. If you want to modify the properties, you can use the `with` keyword to create a new record with the modified values. \n\nExample:\n```csharp\nvar modifiedPerson = person with { Age = 30 };\n```\n\nThis creates a new `Person` record with the same `Name` but a different `Age`.\n\nThat's it! You have successfully created a C# record.",
  "role": "Assistant"
}
```

### Get all chats
To retrieve all chats, make a GET request to the /api/close-mate/chats endpoint.
**Endpoint: /api/close-mate/chats**
**Response:**
```
[
  {
    "id": 2,
    "created": "2023-08-22T17:18:42.076792",
    "name": "What is artificial intelligence?",
    "messages": []
  },
  {
    "id": 1,
    "created": "2023-08-22T16:33:08.47717",
    "name": "how to create record on C#?",
    "messages": []
  }
]
```

### Get a chat by Id
To retrieve a specific chat by its ID, make a GET request to the /api/close-mate/chats/{id} endpoint.
**Endpoint: /api/close-mate/chats/{id}**
**Request example:**
```
https://localhost:57066/api/close-mate/chats/1
```

**Response:**
```
{
  "id": 1,
  "created": "2023-08-22T16:33:08.47717",
  "name": "how to create record on C#?",
  "messages": [
    {
      "id": 1,
      "integrationId": "",
      "created": "2023-08-22T16:38:36.556637",
      "content": "how to create record on C#?",
      "role": "User"
    },
    {
      "id": 2,
      "integrationId": "chatcmpl-7mO0FLJzhPxnHdUXK2BbnNghikG0F",
      "created": "2023-08-22T16:38:36.741208",
      "content": "In C#, a record is a new feature introduced in C# 9.0 that provides a succinct way to declare a type and its properties. Records are primarily used for immutability and provide useful features such as value - based equality, deconstruction, and robust ToString() implementation. \n\nTo create a C# record, follow these steps:\n\nStep 1: Create a new C# project or open an existing project in an integrated development environment (IDE) like Visual Studio.\n\nStep 2: Add a new class file to your project.\n\nStep 3: Inside the class file, declare a record using the `record` keyword followed by the name of the record.\n\nExample:\n```csharp\npublic record Person(string Name, int Age);\n```\n\nIn this example, we create a `Person` record with two properties - `Name` of type `string` and `Age` of type `int`.\n\nStep 4: Use the record in your program by instantiating it.\n\nExample:\n```csharp\nvar person = new Person(); \n```\n\nStep 5: Access the properties of the record using dot notation.\n\nExample:\n```csharp\nConsole.WriteLine();\n``` \n\nThis will output `Name: John Doe, Age: 25`.\n\nRecords in C# are by default immutable, meaning their properties cannot be modified after construction. If you want to modify the properties, you can use the `with` keyword to create a new record with the modified values. \n\nExample:\n```csharp\nvar modifiedPerson = person with { Age = 30 };\n```\n\nThis creates a new `Person` record with the same `Name` but a different `Age`.\n\nThat's it! You have successfully created a C# record.",
      "role": "Assistant"
    }
  ]
}
```

### Delete a chat
To delete a chat, make a DELETE request to the /api/close-mate/chats/{id} endpoint, replacing {id} with the chat's ID.
**Endpoint: /api/close-mate/chats/{id}**

### Edit the chat name
To update the name of a chat, make a PUT request to the /api/close-mate/chats/{id} endpoint, replacing {id} with the chat's ID.
**Endpoint: /api/close-mate/chats/{id}**
**Request example:**
```
{
  "id": 1,
  "name": "C# record"
}
```

**Response:**
```
{
  "id": 1,
  "created": "2023-08-22T16:33:08.47717",
  "name": "C# record",
  "messages": []
}
```


## Acknowledgments
- https://platform.openai.com/
- https://youtu.be/25i-Dh6U6Cw


## Contact
For questions or support, please contact bey1705@gmail.com.
