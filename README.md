# Project Overview - Integrated TODO App with Logging and Docker Containerization

## Introduction

This project is an integrated TODO app that includes a server with logging capabilities and is containerized using Docker. The application allows users to manage a list of TODO items, create, update, and delete them. The server communicates with clients through HTTP requests and returns responses in JSON format. The logging facility records important events and actions for debugging and monitoring purposes. Docker containerization enables easy deployment and scaling of the server application.

## Goals

The main objectives of this project are as follows:

1. Implement an HTTP server that handles incoming requests for the TODO app.
2. Enable logging for various parts of the server code to capture important events.
3. Provide endpoints to add, update, delete, and retrieve TODO items.
4. Support filtering and sorting of TODO items based on their status.
5. Containerize the server application using Docker for easier deployment and testing.

## Functionality

The integrated TODO app with logging provides the following functionality:

1. Create a new TODO item with a unique ID, title, content, due date, and status (PENDING by default).
2. Retrieve the total number of TODO items based on their status (ALL, PENDING, LATE, DONE).
3. Get the content of TODO items based on their status, sorted by ID, due date, or title.
4. Update the status of a TODO item (PENDING, LATE, or DONE) based on its ID.
5. Delete a TODO item based on its ID.
6. Allow changing the log level for specific loggers: request-logger and todo-logger.

## Project Structure

The project is organized into three main components:

1. **Server Application**: The HTTP server that handles incoming requests and interacts with the TODO app. It is implemented using a server shell framework, and requests are processed serially.
2. **Logging Facility**: The logging system that captures and records events and actions in log files. The server code includes two loggers: request-logger and todo-logger, which log request-related and TODO management-related information, respectively.
3. **Docker Containerization**: The Docker container that encapsulates the server application, its dependencies, and the logging configuration. The container can be deployed easily on any system with Docker support.

## Installation and Usage

To run the integrated TODO app with logging and Docker containerization, follow these steps:

### 1. Clone the Repository

```bash
git clone [[repository-url]](https://github.com/GuyBenja/Web-Api-Server-with-logging-system-and-Docker.git)
```

### 2. Server Application Setup

- Review the server shell framework documentation to understand its usage and configuration.

### 3. Logging Configuration

- Configure the logging levels and outputs as specified in the exercise description.
- Ensure the logs folder is created and available in the working directory.

### 4. Build Docker Image

- Create a Dockerfile that includes all the necessary configurations, dependencies, and instructions to build the Docker image for the server application.
- Ensure that the image is built with the target platform as linux/amd64.

### 5. Run the Docker Container

```bash
docker run --name app -d -p 3769:9285 [docker-image-name]
```

### 6. Test the Application

- Use Postman or any HTTP client to send requests to the server running in the Docker container.
- Verify that the logs are generated in the specified log files inside the 'logs' folder.

## Contribution and Support

Contributions to the project are welcome through pull requests. If you encounter any issues or have suggestions for improvements, please feel free to open an issue in the repository.

For support and assistance, you can refer to the project's GitHub repository. Additionally, you can reach out to the repository owner or the community for further help.

Note: Ensure that you provide valid JSON data when submitting your Docker image details as specified in the exercise instructions.
