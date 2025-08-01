---
# OOP (Object-Oriented Programming)


OOP (Object-Oriented Programming) is a programming paradigm based on the concept of “objects,” which can contain 
- **Data** (called *properties* or *attributes*)
- **Code** (called *methods* or *functions*)

---

## What is OOP?

At its core:

- Objects are instances of classes (blueprints).
- Each object represents a real-world entity (e.g., a car, user, or bank account).
- Objects can interact, store state, and perform actions.


---

## Why Use OOP?

✅ **Organized Code**  
Modular, maintainable, and easier to debug.

✅ **Reusability**  
Use existing code via inheritance and composition.

✅ **Scalability**  
Build large systems with clear structure.

✅ **Flexibility**  
Use polymorphism and abstraction to modify/extend code easily.

✅ **Real-world Modeling**  
Code resembles real-world behavior and concepts.

---

## What is a Class?

- A **class** is a blueprint or template for creating objects.
- A **class is a datatype**.

---

## What is an Object?

✅ An object is a **specific instance** of a class.

---

## Class vs Struct in C++

|               | `class`          | `struct`                   |
| ------------- | ---------------- | -------------------------- |
| Default Access| `private`        | `public`                   |
| Use Case      | For OOP          | For plain data containers  |

---

## What is a Class Member?

✅ Any variable or function **defined inside a class**.

- **Data Members** → Variables (e.g., `brand`, `year`)
- **Member Functions** → Functions (e.g., `start()`)

---

## What are Access Specifiers (aka Access Modifiers) in C++?

Access specifiers define how accessible the members (variables and functions) of a class or struct are from outside the class.


They control the visibility and security of class members.


Types of Access Specifiers

C++ has 3 main access specifiers:


| Specifier   | Meaning          | Who can access?                                       |
| ----------- | ---------------- | ----------------------------------------------------- |
| `public`    | No restriction   | Anyone (outside or inside the class)                  |
| `private`   | Full restriction | Only from inside the class                            |
| `protected` | Semi-restricted  | Inside the class and derived classes                  |



1. **public**

Members are accessible from anywhere.



2. **private**

Members are accessible only inside the class.



Not accessible from outside or even from child classes.



3. **protected**

Like private, but accessible to child/derived classes.


---

## What are Properties?


✅ **Property** = A variable (data member) that is accessed via get and/or set functions to control access and encapsulate logic.


### Getters and Setters (Accessors and Mutators)

- ✅ **Getter** → Reads the value

- ✅ **Setter** → Writes the value (optional validation)


**To make a property read-only:** Only provide a getter, not a setter.


> **Note:** `__declspec(property)` is a Microsoft extension for simplifying getter/setter syntax.


---


## First two principles of Object-Oriented Programming (OOP): Encapsulation and Abstraction:


### ✅ Encapsulation

**Encapsulation** is the bundling of data and functions that operate on that data, within a single unit (class), and restricting direct access to some of the object's components.

🔹 **Key Points**:

    - Data is kept private.

    - Access is only through public methods (get, set).

    - It helps hide internal state and protect against unwanted changes.


🔹 **Real-world Example**:

    - A bank account:

    - Balance is private.

    - You can only deposit() or withdraw() — you can't change balance directly.


#### ✅ Benefits of Encapsulation:


- Protects data integrity

- Easier debugging and maintenance

- Prevents misuse

---

### Abstraction — "Hide the Complexity"

✅ **Abstraction** means hiding complex implementation details and showing only the essential features of an object.



🔹 Key Points:


    - Only the interface (what it does) is exposed (Reduces complexity).

    - The implementation (how it works) is hidden (Hides background details and implementation).

    - Makes code simpler to use and less error-prone.


🔹 Real-world Example:

    - When you drive a car:

    - You just use the steering wheel and pedals.

    - You don’t need to know how the engine or brakes work internally.


#### ✅ Benefits of Abstraction:

- Simplifies interface

- Reduces complexity for the user

- Encourages separation of concerns


| Concept     | Encapsulation                             | Abstraction                                 |
| ----------- | ----------------------------------------- | ------------------------------------------- |
| **Focus**   | **How data is protected**                 | **What is shown vs. what is hidden**        |
| **Goal**    | Prevent unauthorized access               | Hide internal complexity                    |
| **Tool**    | `private`, `public`, getters/setters      | Abstract classes, interfaces, functions     |
| **Example** | Making `balance` private in `BankAccount` | Exposing only `print()` method in `Printer` |


---

## Constructors & Destructors


### ✅ Constructor

A special function called when an object is created.  
- Has the same name as the class in C++ 
- No return type  
- Initializes members


🔹 Types of Constructors



1. ✅  **Default Constructor**

A constructor with no parameters.


2. ✅ **Parameterized Constructor**

A constructor that takes one or more parameters to initialize values.


3. ✅ **Copy Constructor**

- Used when creating a copy of an object.


- When is it called?

- When passing an object by value

- When returning an object by value

- When explicitly copying: Person p2 = p1;


4. ✅ Constructor with Member Initializer List


```cpp
class Person {
private:
    string name;
public:
    Person(string n) : name(n) {}  // Fast and clean
};
```


### What is a Destructor?

✅ A **destructor** is a special function called when an object goes out of scope or is deleted.

It’s used to free memory, close files, or clean up resources.


**Rules:**

- Only one destructor per class

- Cannot be overloaded

- Has the same name as the class, but with a ~ in front

- No parameters, no return type

- Dynamically allocated objects (created with 'new') must be manually deallocated using 'delete' to prevent memory leaks and ensure the destructor is called.

---


## Static Members & Methods



### What is a Static Member?

✅ A **static data member** belongs to the class itself, not to any specific object.


🔹 Key Points:

    - Shared by all objects of the class
    - Only one copy exists, no matter how many objects are created
    - Declared with the static keyword inside the class
    - Must be defined outside the class


🔹 What is a Static Method?

✅ A static method is a function that:

- Belongs to the class, not an object

- Can be called without creating an object

- Can only access static members

---

## Inheritance

### 1. What is Inheritance (3rd principle of OOP)?

✅ **Inheritance** allows one class to acquire properties and behaviors (data and methods) of another class.


- Enables code reuse

- Creates a "is-a" relationship

- Supports hierarchy in OOP


### 2. Subclass / Superclass


| Term                         | Meaning                    | Example  |
| ---------------------------- | -------------------------- | -------- |
| **Base Class** / Superclass  | Class being inherited from | `Animal` |
| **Derived Class** / Subclass | Class that inherits        | `Dog`    |


### 3. Inheriting from a Class with a Parameterized Constructor


If the base class has a parameterized constructor, the derived class must call it explicitly in its constructor using an initializer list


### 4. What is an Override Function?


✅ **Overriding** means a derived class redefines a base class function with the same name, return type, and parameters.


Use `virtual` in the base class and optionally override in the derived class.


### 5. Access Base Class Method with Scope Resolution ::



**What Is BaseClass:: Good For?**

```
✅ Explicitly accessing base class members, even if they’re not hidden or overridden.

✅ Useful when there is name hiding (e.g., derived class defines a variable or method with the same name).

✅ Helps readability by clearly showing you're referencing the base class.

✅ Allows calling non-overridden base methods directly.
```

**When to Use BaseClass::method()?**

```
✅ You overrode a method but want to reuse base logic inside the derived class.

✅ You’re doing manual control of polymorphism behavior.

✅ You want to call the base constructor, or base function hidden due to overriding.
```

### 6. Access Specifiers in Inheritance


| Access      | Base Class Access              | Access in Derived Class |
| ----------- | ------------------------------ | ----------------------- |
| `private`   | Accessible only in base class  | ❌ Not inherited         |
| `protected` | Accessible in base and derived | ✅ Good for inheritance  |
| `public`    | Fully accessible               | ✅ ✅                     |

**🔸 If you want a member private to outside but accessible to derived class → Use protected**

### 7. Inheritance Visibility Modes


| Mode        | `public` in Base | `protected` in Base | `private` in Base |
| ----------- | ---------------- | ------------------- | ----------------- |
| `public`    | public           | protected           | not inherited     |
| `protected` | protected        | protected           | not inherited     |
| `private`   | private          | private             | not inherited     |


### 8. Inheritance Types


| Type             | Example                                    |
| ---------------- | ------------------------------------------ |
| **Single**       | One base, one derived                      |
| **Multiple**     | One class inherits from **multiple** bases |
| **Multilevel**   | Class inherits from a derived class        |
| **Hierarchical** | Multiple classes inherit from one base     |
| **Hybrid**       | Mix of above types                         |


### 9. Upcasting and Downcasting

**✅ Upcasting (Safe and common)**

Converting derived object to it's base object

```
clsEmployee e1;

clsPerson\* p1 = \&e1;
```

**Used in polymorphism, especially with virtual functions**

**❌ Downcasting (Risky):**

Downcasting: Converting Base object to Derived object.

A pointer of child class cannot point to an object of parent class, because the child class members the pointer can access do not exist in memory when the object is of parent class. 

### 10. What is a Virtual Function?

✅ A function in the base class that can be overridden in a derived class and resolved at runtime.

**Enables runtime polymorphism**

**🔁 What Happens When You Use a virtual Function?**

- When a class has one or more virtual functions, the compiler builds a table (V-Table) of function pointers for that class.

- Each object of that class will have a hidden pointer called the V-Pointer pointing to that table.


**🔹 V-Table (Virtual Table)**

- A lookup table that maps virtual functions to the correct function implementation.

- There is one V-Table per class that has virtual functions.

- When a class overrides a virtual function, its V-Table replaces the base class's function pointer with its own version.


**🔸 V-Pointer (VPTR)**


- A hidden pointer inside each object of a class with virtual functions.

- It points to the class's V-Table.

**🧠 Why All This?**

Because we want runtime polymorphism — to decide which function to call at runtime, not compile time.

### 11. Static (Early) vs Dynamic (Late) Binding

| Type                | Occurs at    | Uses                  | Example                |
| ------------------- | ------------ | --------------------- | ---------------------- |
| **Static Binding**  | Compile time | Non-virtual functions | Regular function call  |
| **Dynamic Binding** | Run time     | Virtual functions     | `virtual void speak()` |


---

## Polymorphism

### 1. What is Polymorphism (4th principle of OOP)?

Word `Ploy` means "Many" and word `Morphism` means "Form" so it means "Many Forms", Polymorphism allows objects to take many forms, It enables the same interface or method to behave differently based on the object it is acting on.

**🔹 Why is Polymorphism Important?**

- Allows code reusability and flexibility.

- Promotes extensibility — new behaviors can be added with minimal changes.

- Makes code more consistent, clean, and maintainable.


### How to Achieve Polymorphism?

1. **Function Overloading (Compile-Time Polymorphism)**

   Same function name, different parameter types or number.

2. **Operator Overloading (Compile-Time Polymorphism)**
   Define custom behavior for operators like `+`, `==`, etc.


3. **Function Overriding / Virtual Functions (Runtime Polymorphism)**

🔹 **C++**

   A base class defines a virtual function.

   A derived class overrides it.

   When accessed via a base pointer/reference, the derived version runs.


4. **Interfaces (Pure Virtual Functions / Abstract Classes)**

- Abstract class with at least one pure virtual function.

- Enforces derived classes to implement specific behaviors.


### ✅ Consistency Through Polymorphism

**Write general code that works for any subclass:**

```c++
void printArea(IShape* shape) {
    cout << shape->area();
}
```

You can pass in a Rectangle, Circle, or any IShape—consistent interface, different behaviors.

---

## Friend Classes & Friend functions

### What Are Friend Classes and Friend Functions in C++?

In C++, the `friend` keyword allows non-member functions or classes from inside to access private and protected members of another class. However, this friendship is one-way only: the class that grants friendship allows access, but does not gain access in return. This means you cannot access private members of the friend from inside the original class, because friendship is granted — not reciprocated.

1. **Friend Class**

   A friend class can access all private/protected members of another class.

🔹 **Syntax Example:**

    friend class clsB;

2. **Friend Function**

   A friend function is a non-member function that is granted access to private/protected members of a class.

🔹 **Syntax Example:**

    friend void printWidth(Box b);


### Use Cases of Friend Functions & Classes

1. **Tightly Coupled Classes**

    If two classes need to share internal states often (e.g., Car and Engine, or Employee and HR).

2. **Operator Overloading**

    Sometimes operator overloading (like <<) needs access to private members.

3. **Utility Functions**

    Global helper functions (e.g., serialize() or logDetails()) that need access to private data.

### Real-world Example: Employee & HR

```c++
class Employee {
private:
    std::string name;
    double salary;

public:
    Employee(std::string n, double s) : name(n), salary(s) {}

    friend class HR;
};

class HR {
public:
    void printPaySlip(Employee& e) {
        std::cout << "Employee: " << e.name << ", Salary: " << e.salary << std::endl;
    }
};

```

✅ `HR` can access private `name` and `salary` directly because it's a friend.

###  Cautions

| Pros                                 | Cons                                |
| ------------------------------------ | ----------------------------------- |
| Useful for tight relationships       | Breaks encapsulation (violates OOP) |
| Can make operator overloading easier | Overuse leads to poor design        |
| Helps utility/logging functions      | Can expose sensitive data           |


---

## Nesting 
*Nesting* means defining one class inside another class.

### 1. Enclosure Class / Enclosing 

An enclosing class is a class that contains another class inside it, called an inner class or nested class.

🔍 Key Notes:
-Outer is the enclosing class.
-Inner is the nested (inner) class.
-The inner class does not automatically have access to private members of the outer class (unless made friend).

### 2. Nested Class / Subclass

This is the inner class that is defined inside another class.

### Why Use Nested Classes?

-Logical grouping: The inner class is used only by the outer class.

-Encapsulation: Keeps implementation details hidden and organized.

-Tighter coupling: The inner class can access private members of the outer class if declared a friend or given access.

---

## this 

### What is this in OOP?

-*this* is a keyword that refers to the current object — the object on which a member function is being called.
-It allows object methods to refer to themselves — their own properties or other methods.

### ✅ Key Usages of this (OOP-agnostic)✅ Key Usages of this (OOP-agnostic)

| Use Case                                  | Description                 |
| ----------------------------------------- | --------------------------- |
| Access instance variables                 | `this.name = "John"`        |
| Call other instance methods               | `this.doSomething()`        |
| Distinguish parameters from instance vars | `this.name = name;`         |
| Pass the object as an argument            | `someFunction(this)`        |
| Chain method calls                        | `this.setA().setB().setC()` |


### 🔹 What is the this pointer in C++?

-this is an implicit pointer available inside non-static member functions.

-It points to the calling object.

-Its type is a pointer to the class

### Usages of this Pointer in C++

| Usage                                      | Explanation                                         | Example                |
| ------------------------------------------ | --------------------------------------------------- | ---------------------- |
| 1. Access current object                   | Inside a member function to refer to calling object | `this->x = 5;`         |
| 2. Return the object itself                | Used in **method chaining**                         | `return *this;`        |
| 3. Resolve name conflicts                  | If parameter name hides a member variable           | `this->value = value;` |
| 4. Pass current object to another function | Helpful for callbacks or comparisons                | `compare(this);`       |
| 5. Inside operator overloading             | To return the modified object                       | `return *this;`        |

### 🔸 Special Notes

| Concept                     | Value                                                               |
| --------------------------- | ------------------------------------------------------------------- |
| `*this`                     | Dereferenced pointer to the current object                          |
| Why pass `*this` to static? | Because static functions don't have `this`                          |
| Static method limitations   | No access to member variables or functions unless passed explicitly |
| Pass-by-value caution       | Copy constructor used; avoid for large/complex objects              |

---

## 📦 Passing Objects to Functions in OOP

### Can objects be passed to functions?
Yes. In OOP, objects behave like basic types (`int`, `string`, etc.) and can be passed to functions in different ways.

| Type         | Description                                                   |
|--------------|---------------------------------------------------------------|
| By Value     | A **copy** of the object is passed (copy constructor is called). |
| By Reference | The original object is passed (modifications affect the original). |
| By Pointer   | Similar to reference but uses explicit pointer syntax.         |

```cpp
void ByValue(clsA obj) { /* Copy constructor called */ }
void ByReference(clsA& obj) { /* Reference, no copy */ }
void ByPointer(clsA* obj) { /* Access using obj-> */ }
```

### Temporary Objects (R-Values)

Temporary (unnamed) objects can be created directly in function calls, often using constructors.

```cpp
#include <vector>

int main() {
    std::vector<clsA> v;
    v.push_back(clsA(10)); // Temporary object
}
```

Temporary objects are automatically destroyed after the full expression ends.

### Dynamic Arrays of Objects

You can allocate dynamic arrays of objects using the new keyword.

```cpp
int n = 3;
clsA* arr = new clsA[n]; // Default constructor called for each

for (int i = 0; i < n; ++i) {
    arr[i].Print();
}

delete[] arr;

```

### Static Array of Objects with Parameterized Constructor
Initialize an array of objects using constructor calls:

```cpp
clsA obj[] = { clsA(10), clsA(20), clsA(30) };

for (int i = 0; i < 3; i++) {
    obj[i].Print();
}
```

💡 This is useful when each object requires a specific state during creation.

### Summary

| Topic                             | Notes                                                 |
| --------------------------------- | ----------------------------------------------------- |
| Pass by Value                     | Copy is made; invokes copy constructor                |
| Pass by Reference                 | Direct access to original object                      |
| Temporary Object                  | Exists for one statement or expression                |
| Dynamic Array of Objects          | Use `new[]` and `delete[]`                            |
| Parameterized Constructor + Array | Easily initialize fixed-size array with unique values |
