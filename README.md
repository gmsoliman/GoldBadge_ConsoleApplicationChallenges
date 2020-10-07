# Hey there! Thanks for checking out my repository!
---
### All of the applications in this repo were completed as a part of a final project for the Gold Badge certificate (C# Fundamentals) with [Eleven Fifty Academy](https://www.elevenfifty.org).

In short, all three applications utilize a CRUD model **(Create, Read, Update, Delete)**, but they do so in different ways, with some not even using all four operations. Per the parameters of Challenges 1 and 2, only Create, Read, and Delete were necessary, while Challenge 3 utilizes the full CRUD model.

Each application is also broken down into four parts: a **Main Class**, a **Method Repository**, a **Repository Test Class**, and the **Program/UI**.

#### Main Class
The main class is used to define the properties of the main subject of the prompt. Whether it's the menu, insurance claims, or employee badges, the properties, constructors, and fields are created here.

#### Method Repository
The method repository houses all the methods that will be used in the program. This is where the CRUD operations are defined.

#### Repository Test Class
The repository test class is used to test all the methods in the repository. This ensures that resolving errors and bugs are more manageable before the methods are implemented into the program. To test methods, a AAA pattern is used, where the objects needed for each method are first **Arranged**, then test **Acts** by using the method that's being tested, and finally an **Assertion** is made to ensure that the method produces the desired outcome.

#### Program/UI
The program/ui takes the elements created in the main class and method repository and utlizes them to fulfill the functionality that the challenge prompts.

#### Below you'll find summaries of the three challenges:

### Challenge 01 - Cafe Menu
##### A cafe manager needs a console application for their new menu. The app must be able to create new menu items, delete them, and display the full menu. Each menu item must have a meal number (so customers can say, "I'll have the #5"), a meal name, description, ingredients, and a price. You'll find these properties defined in the main class. 
---
### Challenge 02 - Insurance Claims Department
##### An insurance company needs a new application to help them process their claims. Each claim is defined in the main class by a ClaimID, ClaimType (car, home, or theft), Description, ClaimAmount, DateOfIncident, DateOfClaim, and whether or not the claim IsValid which is only true if the insurance claim is made 30 days or less after the incident took place. A claims agent should be able to see all claims in the queue, take care of the next claim, and enter a new claim. The app is centered around **Queues** where the *first item in is the first item out*. This ensures that claims are processed in the order they are received.
---
### Challenge 03 - Security Badges
##### In this challenge, a security admin needs an app that can track what employee badge numbers have access to a specific list of doors. With this, the only two properties called for in the main class are the BadgeID and a list of door names that the badge can access. A dictionary is made from this class, where the BadgeID is used as the key and the doors that it can access are used as the values. The prompt calls for the security admin to be able to *add a new badge*, *edit a badge*(whether by adding access to doors, removing access to specific doors, or revoking all door-access priveleges), and to be able to display the full dictionary of badges.
