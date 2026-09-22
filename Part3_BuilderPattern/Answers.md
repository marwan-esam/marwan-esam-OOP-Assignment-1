# Task 3.1: The 20-Parameter Constructor Problem

## Question 1: Why is a single 20-parameter constructor a problem in practice?
Having 20 parameters in a single constructor completely ruins **call-site readability**. When a developer looks at the constructor call, they will just see a massive wall of strings and numbers. They will have no idea what each value represents without navigating to the constructor's definition. 

Furthermore, this introduces a massive risk of **mistakenly interchanging parameters**. Because many of the fields share the same data type (e.g., `BillingCity` and `ShippingCity` are both strings), the compiler will not catch the error if you pass them in the wrong order. Finally, if the business needs to add an **optional property**, it adds even more clutter, forcing developers to pass `null` or empty strings, or forcing the creation of multiple confusing constructor overloads (the "telescoping constructor" anti-pattern).

## Question 2: Is this purely a "constructor is too long" problem, or a deeper design issue?
This is a deeper design issue known as the **"Data Clumps"** or **"Primitive Obsession"** code smell. Putting 20 loosely related properties directly onto a single `Invoice` class violates the Single Responsibility Principle. A much better architectural approach is to group related fields into their own cohesive classes (for example, extracting the street, city, state, and zip code into a dedicated `Address` class), and then composing the `Invoice` out of those smaller classes.
