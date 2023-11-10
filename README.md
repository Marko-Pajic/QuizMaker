# Quiz Maker Application

A simple and fun quiz maker application in C#. Create your own quizzes with different categories, questions, and answers.
Please note that this project is not finished yet and I am still working on it.
I will update the README file as I make progress on the project. If you have any questions or feedback, please let me know. 😊

## Table of Contents

- Quiz Maker Application
- Table of Contents
- Motivation
- Installation
- Usage
- Technologies
- Acknowledgements
- License
- Contact

## Motivation

I created this project as a way to practice my C# skills and learn more about file handling and serialization. I wanted to create a simple and fun application that allows me to create my own quizzes with different categories, questions, and answers. The application features a user interface, a quiz category class, a question class, and a file utility class.

## Installation

To download, install, and run this project, you will need:

- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- Windows 10 or later

You can clone this project from GitHub using the following command:

`git clone https://github.com/your-username/quiz-maker-application.git`

Alternatively, you can download the ZIP file from the GitHub repository and extract it to your desired location.

To open the project in Visual Studio, double-click on the `QuizMaker.sln` file in the root folder.

To run the project, press F5 or click on the Start button in Visual Studio.

## Usage

To use the application, follow these steps:

- Read the introduction and the rules of the application. You will be creating quizzes with different categories, questions, and answers. You can create as many categories and questions as you want.
- Enter the name of the quiz category and press Enter. You will see a message confirming the name of the category.
- Enter the question that you want to ask and press Enter. You will see a message confirming the question.
- Enter the number of answers that you want to provide and press Enter. You will see a message confirming the number of answers.
- Enter the decoy answers that you want to use and press Enter. You will see a message confirming the decoy answers.
- Enter the correct answer that you want to use and press Enter. You will see a message confirming the correct answer.
- Repeat the process until you have created all the questions that you want for the category.
- The application will save the quiz category and the questions in an XML file in the resources folder.
- You can choose to create another quiz category or quit the application.

Here are some screenshots of the application:

![Screenshot 1]
![Screenshot 2]
![Screenshot 3]

## Technologies

I used the following technologies, tools, and frameworks to create this project:

- C# as the programming language
- Visual Studio 2019 as the integrated development environment
- .NET Framework 4.7.2 as the software framework
- System.Console as the console input and output class
- System.Random as the random number generator class
- System.Collections.Generic.List as the generic list class
- System.Xml.Serialization as the XML serialization class
- System.IO.File as the file input and output class

Some of the challenges or difficulties that I faced and how I overcame them are:

- Creating a quiz category class to store the name and the questions of the category. I used a public string property for the name and a public list of question objects for the questions.
- Creating a question class to store the inquiry, the answers, and the correct answer index of the question. I used public string properties for the inquiry and the answers and a public int property for the correct answer index.
- Creating a file utility class to serialize and deserialize the quiz category and the questions to and from an XML file. I used the XmlSerializer class to create and write the XML file and the File class to read and load the XML file.
- Shuffling the answers to create a random order for each question. I used a for loop to swap the elements of the list of answers with a random index.

## Acknowledgements

I would like to thank or credit the following sources, references, or inspirations that helped me with this project:

- [Microsoft Docs] for providing the documentation and tutorials for C#, Visual Studio, .NET Framework, and System classes.
- [Rakete Mentoring] for providing the answers and solutions to various programming questions and problems.

## License

This project is licensed under the MIT License. See the [LICENSE] file for more details.

## Contact

If you want to connect with me or have any questions or feedback about this project, you can reach me at:

- Email: pajic.marko84@gmail.com
