# Task 1.1: Critique of Procedural C++ Design

## 1. Global State and Lack of Encapsulation
The system relies heavily on global arrays (e.g., `customerIds`, `productPrices`, `orderDates`) to store data. Because this data is global, it is exposed to the entire program without any access control. 
* **The Problem:** Any function can read or write to these arrays at any time. There is no way to protect the data from invalid state changes (e.g., an accidental overwrite or incorrect index access).
* **Impact on Modularity:** This design completely breaks modularity. Data and behavior are disjointed, meaning functions have hidden dependencies on the global arrays. You cannot easily extract or reuse a function like `calculateOrderTotal` elsewhere because it is deeply coupled to these global variables.

## 2. Parallel Arrays and Lack of Cohesive Types
A single entity (like a Customer or Product) is split across multiple independent arrays (e.g., `customerIds`, `customerNames`, `customerEmails`). 
* **The Problem:** Related data is not bundled together into a single logical unit (like a `class` or `struct`). If you need to sort or move a customer, you have to carefully swap elements across all five arrays perfectly. If even one swap is missed, the data becomes hopelessly corrupted (e.g., a customer ends up with someone else's email). Passing a "Customer" to a function also requires passing multiple variables or a global index, rather than a single `Customer` object.

## 3. Hardcoded Array Limits (Static Sizing)
The system uses fixed-size arrays defined by constants like `MAX_CUSTOMERS = 50` or `MAX_ORDERS = 100`.
* **The Problem:** The system cannot scale dynamically. Once 50 customers are registered, the system halts and rejects the 51st customer, meaning it can't handle real-world business growth. Conversely, if the system only ever has 5 customers, it is wasting memory by permanently allocating space for 50.

## 4. Lack of Data Validation
When adding a customer (e.g., in `addCustomer`), there is no validation for the input data. 
* **The Problem:** A customer can be created with an empty name or an invalid email format. Because the functions just blindly write strings into arrays, "garbage" data can easily infect the system, and there are no objects to enforce their own validity rules upon creation.

## 5. Premature State Mutation (Business Logic Flaw)
In the `addLineToOrder` function, the stock of a product is immediately reduced (`productStock[productIndex] -= quantity;`). 
* **The Problem:** This happens while the order is merely being drafted. If the customer never pays for the order or cancels it, those products are permanently "lost" from inventory. Stock reduction should happen only upon confirmation/payment, or at least have a mechanism to release the stock back.

## 6. Hardcoded Business Rules
In `calculateOrderTotal`, the VIP discount is hardcoded directly into the calculation (`if (customerIsVip[...]) total = total * 0.90;`). 
* **The Problem:** Mixing discount rules directly into the total calculation makes the system inflexible. If the company adds a new 15% VIP tier, or seasonal discounts, you are forced to crack open and modify the core calculation function.
