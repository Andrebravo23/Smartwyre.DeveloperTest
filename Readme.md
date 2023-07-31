# Smartwyre Developer Test

This is my refactoring of the Smartwyre test, the instructions can be seen below.
I adhered to the SOLID principles to maintain a well-structured, readable, and easily scalable code. As you can see, the rebate calculation is being done from individual implementations of the IIncentiveCalculator interface. This interface was created to avoid excessive use of conditionals in the main function of the RebateService, which is also the main function of this small application. Furthermore, I created a mediator to take care of returning the appropriate IncentiveCalculator for each operation as required by the request. On the other hand, I used dependency injection to facilitate the execution of unit tests through mock classes.
Had I had more time, I would have liked to:

- Implement the data access layer.
- Create an error response that provides more detail about unsuccessful requests.
- Extend the application to function as an API.
- Validate requests with FluentValidation.

# Instructions

In the 'RebateService.cs' file you will find a method for calculating a rebate. At a high level the steps for calculating a rebate are:

 1. Lookup the rebate that the request is being made against.
 2. Lookup the product that the request is being made against.
 2. Check that the rebate and request are valid to calculate the incentive type rebate.
 3. Store the rebate calculation.

What we'd like you to do is refactor the code with the following things in mind:

 - Adherence to SOLID principles
 - Testability
 - Readability
 - In the future we will add many more incentive types. Determining the incentive type should be made as easy and intuitive as possible for developers who will edit this in the future.

We’d also like you to 
 - Add some unit tests to the Smartwyre.DeveloperTest.Tests project to show how you would test the code that you’ve produced 
 - Run the RebateService from the Smartwyre.DeveloperTest.Runner console application accepting inputs

The only specific 'rules' are:

- The solution should build
- The tests should all pass

You are free to use any frameworks/NuGet packages that you see fit. You should plan to spend around 1 hour completing the exercise.
